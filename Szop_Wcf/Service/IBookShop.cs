using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBookShop
    {

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        string Login(string username, string password);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool Logout(string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool AddBook(string title, string originalTitle, string author, uint price, string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        List<Book> List(string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool DeleteBook(uint bookID, string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool Like(uint bookID, string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool Dislike(uint bookID, string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool AlreadyLiked(uint bookID, string uID);

        [OperationContract]
        [FaultContract(typeof(BookShopException))]
        bool AlreadyDisliked(uint bookID, string uID);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class BookShopException
    {
        [DataMember]
        public string Message { get; set; }

        private BookShopException()
        {
            Message = string.Empty;
        }

        public BookShopException(string message) : this()
        {
            Message = message;
        }
    }
}
