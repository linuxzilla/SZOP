using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using Client.MyBookService;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopClient client;
        string userId = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            GridLogin.Visibility = Visibility.Visible;
            GridMain.Visibility = Visibility.Hidden;
            GridAdd.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new BookShopClient();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (CheckLoginState() && userId != "INVALID_USER_CREDENTIALS")
                {
                    userId = string.Empty;
                    client.Logout(userId);
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ListAllBook()
        {
            try
            {
                if (CheckLoginState())
                {
                    List<Book> Books = client.List(userId).ToList<Book>();
                    dgListBooks.ItemsSource = Books;
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool CheckLoginState()
        {
            return userId != string.Empty;
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    userId = string.Empty;
                    client.Logout(userId);
                    GridMain.Visibility = Visibility.Hidden;
                    GridLogin.Visibility = Visibility.Visible;
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    Book book = (Book)dgListBooks.SelectedItem;
                    if (book != null)
                    {
                        if (client.DeleteBook(book.Id, userId))
                            ListAllBook();
                        else
                            MessageBox.Show("Something went wrong");
                    }
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                    ListAllBook();
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    GridMain.Visibility = Visibility.Hidden;
                    GridAdd.Visibility = Visibility.Visible;
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btLike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    Book book = (Book)dgListBooks.SelectedItem;
                    if (book != null)
                        client.Like(book.Id, userId);
                    ListAllBook();
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btDislike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    Book book = (Book)dgListBooks.SelectedItem;
                    if (book != null)
                        client.Dislike(book.Id, userId);
                    ListAllBook();
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckLoginState())
                {
                    userId = client.Login(tbUsername.Text, tbPassword.Password);
                    if (userId != "INVALID_USER_CREDENTIALS")
                    {
                        GridLogin.Visibility = Visibility.Hidden;
                        GridMain.Visibility = Visibility.Visible;
                        ListAllBook();
                    }
                    else
                    {
                        userId = string.Empty;
                        MessageBox.Show("Wrong username or password!");
                    }
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    tbBookTitle.Text = "";
                    tbBookOriginalTitle.Text = "";
                    tbAuthor.Text = "";
                    tbPrice.Text = "0";
                    ListAllBook();
                    GridAdd.Visibility = Visibility.Hidden;
                    GridMain.Visibility = Visibility.Visible;
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginState())
                {
                    string bookTitle = tbBookTitle.Text, bookOrginalTitle = tbBookOriginalTitle.Text, bookAuthor = tbAuthor.Text;
                    uint bookPrice = 0;
                    if (!UInt32.TryParse((string)tbPrice.Text, out bookPrice))
                        MessageBox.Show("Only positive integer number, please!");
                    else
                    {
                        if (bookTitle.Length > 0 && bookOrginalTitle.Length > 0 && bookAuthor.Length > 0)
                        {
                            if (client.AddBook(bookTitle, bookOrginalTitle, bookAuthor, bookPrice, userId))
                            {
                                tbBookTitle.Text = "";
                                tbBookOriginalTitle.Text = "";
                                tbAuthor.Text = "";
                                tbPrice.Text = "0";
                                ListAllBook();
                                GridAdd.Visibility = Visibility.Hidden;
                                GridMain.Visibility = Visibility.Visible;
                            }
                            else
                                MessageBox.Show("Something went wrong");
                        }
                        else
                            MessageBox.Show("Please fill in all fields!");
                    }
                }
            }
            catch (FaultException<BookShopException> exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
