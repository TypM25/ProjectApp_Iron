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
using System.Windows.Shapes;

namespace App_Iron
{
    /// <summary>
    /// Interaction logic for Machine_page.xaml
    /// </summary>
    public partial class Machine_page : Window
    {
        public Machine_page()
        {
            InitializeComponent();
        }

        private void btnCreateproduct_Click(object sender, RoutedEventArgs e)
        {
            Createproduct_page letopen1 = new Createproduct_page();
            this.Visibility = Visibility.Hidden;
            letopen1.Show();
        }

  
    }
}
