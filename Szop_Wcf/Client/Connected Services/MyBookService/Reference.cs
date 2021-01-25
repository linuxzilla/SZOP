﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.MyBookService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class BookShopException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private uint DislikeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private uint IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private uint LikeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OriginalTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private uint PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint Dislike {
            get {
                return this.DislikeField;
            }
            set {
                if ((this.DislikeField.Equals(value) != true)) {
                    this.DislikeField = value;
                    this.RaisePropertyChanged("Dislike");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint Like {
            get {
                return this.LikeField;
            }
            set {
                if ((this.LikeField.Equals(value) != true)) {
                    this.LikeField = value;
                    this.RaisePropertyChanged("Like");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OriginalTitle {
            get {
                return this.OriginalTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginalTitleField, value) != true)) {
                    this.OriginalTitleField = value;
                    this.RaisePropertyChanged("OriginalTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyBookService.IBookShop")]
    public interface IBookShop {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Login", ReplyAction="http://tempuri.org/IBookShop/LoginResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/LoginBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        string Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Login", ReplyAction="http://tempuri.org/IBookShop/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Logout", ReplyAction="http://tempuri.org/IBookShop/LogoutResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/LogoutBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool Logout(string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Logout", ReplyAction="http://tempuri.org/IBookShop/LogoutResponse")]
        System.Threading.Tasks.Task<bool> LogoutAsync(string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AddBook", ReplyAction="http://tempuri.org/IBookShop/AddBookResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/AddBookBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool AddBook(string title, string originalTitle, string author, uint price, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AddBook", ReplyAction="http://tempuri.org/IBookShop/AddBookResponse")]
        System.Threading.Tasks.Task<bool> AddBookAsync(string title, string originalTitle, string author, uint price, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/List", ReplyAction="http://tempuri.org/IBookShop/ListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/ListBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        Client.MyBookService.Book[] List(string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/List", ReplyAction="http://tempuri.org/IBookShop/ListResponse")]
        System.Threading.Tasks.Task<Client.MyBookService.Book[]> ListAsync(string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/DeleteBook", ReplyAction="http://tempuri.org/IBookShop/DeleteBookResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/DeleteBookBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool DeleteBook(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/DeleteBook", ReplyAction="http://tempuri.org/IBookShop/DeleteBookResponse")]
        System.Threading.Tasks.Task<bool> DeleteBookAsync(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Like", ReplyAction="http://tempuri.org/IBookShop/LikeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/LikeBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool Like(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Like", ReplyAction="http://tempuri.org/IBookShop/LikeResponse")]
        System.Threading.Tasks.Task<bool> LikeAsync(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Dislike", ReplyAction="http://tempuri.org/IBookShop/DislikeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/DislikeBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool Dislike(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/Dislike", ReplyAction="http://tempuri.org/IBookShop/DislikeResponse")]
        System.Threading.Tasks.Task<bool> DislikeAsync(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AlreadyLiked", ReplyAction="http://tempuri.org/IBookShop/AlreadyLikedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/AlreadyLikedBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool AlreadyLiked(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AlreadyLiked", ReplyAction="http://tempuri.org/IBookShop/AlreadyLikedResponse")]
        System.Threading.Tasks.Task<bool> AlreadyLikedAsync(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AlreadyDisliked", ReplyAction="http://tempuri.org/IBookShop/AlreadyDislikedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.MyBookService.BookShopException), Action="http://tempuri.org/IBookShop/AlreadyDislikedBookShopExceptionFault", Name="BookShopException", Namespace="http://schemas.datacontract.org/2004/07/Service")]
        bool AlreadyDisliked(uint bookID, string uID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookShop/AlreadyDisliked", ReplyAction="http://tempuri.org/IBookShop/AlreadyDislikedResponse")]
        System.Threading.Tasks.Task<bool> AlreadyDislikedAsync(uint bookID, string uID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookShopChannel : Client.MyBookService.IBookShop, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookShopClient : System.ServiceModel.ClientBase<Client.MyBookService.IBookShop>, Client.MyBookService.IBookShop {
        
        public BookShopClient() {
        }
        
        public BookShopClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookShopClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookShopClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookShopClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public bool Logout(string uID) {
            return base.Channel.Logout(uID);
        }
        
        public System.Threading.Tasks.Task<bool> LogoutAsync(string uID) {
            return base.Channel.LogoutAsync(uID);
        }
        
        public bool AddBook(string title, string originalTitle, string author, uint price, string uID) {
            return base.Channel.AddBook(title, originalTitle, author, price, uID);
        }
        
        public System.Threading.Tasks.Task<bool> AddBookAsync(string title, string originalTitle, string author, uint price, string uID) {
            return base.Channel.AddBookAsync(title, originalTitle, author, price, uID);
        }
        
        public Client.MyBookService.Book[] List(string uID) {
            return base.Channel.List(uID);
        }
        
        public System.Threading.Tasks.Task<Client.MyBookService.Book[]> ListAsync(string uID) {
            return base.Channel.ListAsync(uID);
        }
        
        public bool DeleteBook(uint bookID, string uID) {
            return base.Channel.DeleteBook(bookID, uID);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBookAsync(uint bookID, string uID) {
            return base.Channel.DeleteBookAsync(bookID, uID);
        }
        
        public bool Like(uint bookID, string uID) {
            return base.Channel.Like(bookID, uID);
        }
        
        public System.Threading.Tasks.Task<bool> LikeAsync(uint bookID, string uID) {
            return base.Channel.LikeAsync(bookID, uID);
        }
        
        public bool Dislike(uint bookID, string uID) {
            return base.Channel.Dislike(bookID, uID);
        }
        
        public System.Threading.Tasks.Task<bool> DislikeAsync(uint bookID, string uID) {
            return base.Channel.DislikeAsync(bookID, uID);
        }
        
        public bool AlreadyLiked(uint bookID, string uID) {
            return base.Channel.AlreadyLiked(bookID, uID);
        }
        
        public System.Threading.Tasks.Task<bool> AlreadyLikedAsync(uint bookID, string uID) {
            return base.Channel.AlreadyLikedAsync(bookID, uID);
        }
        
        public bool AlreadyDisliked(uint bookID, string uID) {
            return base.Channel.AlreadyDisliked(bookID, uID);
        }
        
        public System.Threading.Tasks.Task<bool> AlreadyDislikedAsync(uint bookID, string uID) {
            return base.Channel.AlreadyDislikedAsync(bookID, uID);
        }
    }
}