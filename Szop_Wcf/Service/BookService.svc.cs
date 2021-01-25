using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookShop
    {
        private static DatabaseManager Database = DatabaseManager.Instance();
        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static List<Book> Books = new List<Book>();

        public string Login(string username, string password)
        {
            try
            {
                string uID = string.Empty;
                Database = DatabaseManager.Instance();
                if (Database.Connect())
                {
                    MySqlDataReader dataReader
                        = Database.MyqlReader(string.Format("SELECT id, username FROM users WHERE username ='{0}' && password = '{1}'", username, password));
                    if (dataReader.HasRows)
                    {
                        User tmpUser = null;
                        while (dataReader.Read())
                        {
                            tmpUser = new User(uint.Parse(dataReader.GetString(0)), dataReader.GetString(1));
                        }
                        uID = Guid.NewGuid().ToString();
                        Users.Add(uID, tmpUser);
                    }
                    else
                        uID = "INVALID_USER_CREDENTIALS";
                    dataReader.Close();
                    Database.Close();
                }
                else
                    throw new Exception("Can not connect to database!");
                return uID;
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool Logout(string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                    return Users.Remove(uID);
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public List<Book> List(string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    if (Database.Connect())
                    {
                        lock (typeof(MySqlDataReader))
                        {
                            MySqlDataReader reader = Database.MyqlReader(string.Format(
                                    "SELECT books.*," +
                                    "(SELECT COUNT(bookId) FROM user_likes INNER JOIN szop.users ON users.id = user_likes.userId where bookId = books.id)" +
                                    "As 'likes'," +
                                    "(SELECT COUNT(bookId) FROM user_dislikes INNER JOIN szop.users ON users.id = user_dislikes.userId where bookId = books.id)" +
                                    "AS 'dislikes' " +
                                    "from books;"
                                ));
                            if (reader.HasRows)
                            {
                                lock (Books)
                                {
                                    Books = new List<Book>();
                                    while (reader.Read())
                                    {
                                        Books.Add(new Book(reader.GetUInt32(0), reader.GetString(1), reader.GetString(2),
                                            reader.GetString(3), reader.GetUInt32(4), reader.GetUInt32(5), reader.GetUInt32(6)));
                                    }
                                }
                            }
                            reader.Close();
                            Database.Close();
                        }
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
                return Books;
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool AddBook(string title, string originalTitle, string author, uint price, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    if (Database.Connect())
                    {
                        int rows = Database.ExecuteNonQuery(string.Format(
                            "insert into books SET title = '{0}', originalTitle = '{1}', author = '{2}', price = {3};", title, originalTitle, author, price
                            ));
                        Database.Close();
                        return rows == 1;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool DeleteBook(uint bookID, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    if (Database.Connect())
                    {
                        int rows = Database.ExecuteNonQuery(string.Format("DELETE from books where id = {0} ;", bookID));
                        Database.ExecuteNonQuery(string.Format("DELETE from user_likes where bookId = {0} ;", bookID));
                        Database.ExecuteNonQuery(string.Format("DELETE from user_dislikes where bookId = {0} ;", bookID));
                        Database.Close();
                        return rows == 1;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool Like(uint bookID, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    int rows = 0;
                    bool bookLiked = AlreadyLiked(bookID, uID);
                    bool bookDisliked = AlreadyDisliked(bookID, uID);
                    if (Database.Connect())
                    {
                        if (bookLiked)
                            rows = Database.ExecuteNonQuery(string.Format("DELETE from user_likes where userId = {0} ;", Users[uID].Id));
                        else
                        {
                            if (bookDisliked)
                                Database.ExecuteNonQuery(string.Format("DELETE from user_dislikes where userId = {0} ;", Users[uID].Id));
                            rows = Database.ExecuteNonQuery(string.Format("INSERT INTO user_likes SET bookId = {0}, userId = {1} ;", bookID, Users[uID].Id));
                        }
                        Database.Close();
                        return rows == 1;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool Dislike(uint bookID, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    int rows = 0;
                    bool bookLiked = AlreadyLiked(bookID, uID);
                    bool bookDisliked = AlreadyDisliked(bookID, uID);
                    if (Database.Connect())
                    {
                        if (bookDisliked)
                            rows = Database.ExecuteNonQuery(string.Format("DELETE from user_dislikes where userId = {0} ;", Users[uID].Id));
                        else
                        {
                            if (bookLiked)
                                Database.ExecuteNonQuery(string.Format("DELETE from user_likes where userId = {0} ;", Users[uID].Id));
                            rows = Database.ExecuteNonQuery(string.Format("INSERT INTO user_dislikes SET bookId = {0}, userId = {1} ;", bookID, Users[uID].Id));
                        }
                        Database.Close();
                        return rows == 1;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool AlreadyLiked(uint bookID, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    if (Database.Connect())
                    {
                        bool liked;
                        lock (typeof(MySqlDataReader))
                        {
                            MySqlDataReader reader = Database.MyqlReader(string.Format(
                                "SELECT id FROM user_likes where bookId = {0} AND userId = {1} ;", bookID, Users[uID].Id
                                ));
                            liked = reader.HasRows;
                            reader.Close();
                            Database.Close();
                        }
                        return liked;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }

        public bool AlreadyDisliked(uint bookID, string uID)
        {
            try
            {
                if (Users.ContainsKey(uID))
                {
                    if (Database.Connect())
                    {
                        bool liked;
                        lock (typeof(MySqlDataReader))
                        {
                            MySqlDataReader reader = Database.MyqlReader(string.Format(
                                "SELECT id FROM user_dislikes where bookId = {0} AND userId = {1} ;", bookID, Users[uID].Id
                                ));
                            liked = reader.HasRows;
                            reader.Close();
                            Database.Close();
                        }
                        return liked;
                    }
                    else
                        throw new Exception("Can not connect to database!");
                }
                else
                    throw new Exception("Invalid login credentials!");
            }
            catch (Exception e)
            {
                throw new FaultException<BookShopException>(new BookShopException(e.Message));
            }
        }
    }
}
