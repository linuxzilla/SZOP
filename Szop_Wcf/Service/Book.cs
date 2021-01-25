using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class Book
    {
        private uint id, like, dislike, price;
        private string title, author, originalTitle;

        [DataMember]
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DataMember]
        public string OriginalTitle
        {
            get { return originalTitle; }
            set { originalTitle = value; }
        }

        [DataMember]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        [DataMember]
        public uint Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public uint Like
        {
            get { return like; }
            set { like = value; }
        }

        [DataMember]
        public uint Dislike
        {
            get { return dislike; }
            set { dislike = value; }
        }

        private Book()
        {
            Id = 0;
            Title = "UNDEFINED";
            OriginalTitle = "UNDEFINED";
            Author = "UNDEFINED";
            Price = 0;
            Like = 0;
            Dislike = 0;
        }

        public Book(string title, string originalTitle, string author, uint price) : this()
        {
            Title = title;
            OriginalTitle = originalTitle;
            Author = author;
            Price = price;
        }

        public Book(uint id, string title, string originalTitle, string author, uint price) 
            : this(title, originalTitle, author, price)
        {
            Id = id;
        }

        public Book(uint id, string title, string originalTitle, string author, uint price, uint like, uint dislike) 
            : this(id, title, originalTitle, author, price)
        {
            Like = like;
            Dislike = dislike;
        }
    }
}
