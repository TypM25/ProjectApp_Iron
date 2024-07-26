using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;



namespace App_Iron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //string un = "";
        //string pw = "";

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void btnlogin_Click(object sender, RoutedEventArgs e)
        //{
        //    un = txtusername.Text;
        //    pw = pwbpassword.Password;

        //    if (un == "admin" && pw == "1")
        //    {

        //    }
        //    else
        //    {
        //        MessageBox.Show("Please try again !");
        //    }
        //}

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Test_page letopen1 = new Test_page();
            //this.Visibility = Visibility.Hidden;
            letopen1.Show();
        }


        private void btnMachsetting_Click(object sender, RoutedEventArgs e)
        {
            Machine_page letopen1 = new Machine_page();
            //this.Visibility = Visibility.Hidden;
            letopen1.Show();
        }

    }
}

//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace App_Iron
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        private bool isLoggedIn = false;

//        public MainWindow()
//        {
//            InitializeComponent();
//            btnTest.IsEnabled = false;
//            btnMachsetting.IsEnabled = false;
//        }

//        private string un = "";
//        private string pw = "";

//        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
//        {
//            // You can add code here to handle text changes if needed
//        }

//        private void btnlogin_Click(object sender, RoutedEventArgs e)
//        {
//            un = txtusername.Text;
//            pw = pwbpassword.Password;

//            if (IsValidCredentials(un, pw))
//            {
//                isLoggedIn = true;
//                btnTest.IsEnabled = true;
//                btnMachsetting.IsEnabled = true;
//                MessageBox.Show("Login successful!");
//            }
//            else
//            {
//                MessageBox.Show("Please try again!");
//                btnTest.IsEnabled = false;
//                btnMachsetting.IsEnabled = false;
//            }
//        }

//        private bool IsValidCredentials(string username, string password)
//        {
//            // Replace with actual validation logic, such as hashing passwords and checking against a database
//            return username == "admin" && password == "1";
//        }

//        private void btnTest_Click(object sender, RoutedEventArgs e)
//        {
//            if (isLoggedIn)
//            {
//                try
//                {
//                    Test_page letopen1 = new Test_page();
//                    this.Visibility = Visibility.Hidden;
//                    letopen1.Show();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Failed to open Test Page: {ex.Message}");
//                }
//            }
//            else
//            {
//                MessageBox.Show("You must log in first!");
//            }
//        }

//        private void btnMachsetting_Click(object sender, RoutedEventArgs e)
//        {
//            if (isLoggedIn)
//            {
//                try
//                {
//                    Machine_page letopen1 = new Machine_page();
//                    this.Visibility = Visibility.Hidden;
//                    letopen1.Show();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Failed to open Machine Page: {ex.Message}");
//                }
//            }
//            else
//            {
//                MessageBox.Show("You must log in first!");
//            }
//        }
//    }
//}
