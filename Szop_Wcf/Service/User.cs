using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class User
    {
        private uint id;
        private string username, password;

        [DataMember]
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private User()
        {
            Id = 0;
            Username = "UNDEFINED";
            Password = string.Empty;
        }

        public User(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        public User(uint id, string username) : this(username, string.Empty)
        {
            Id = id;
        }
    }
}
