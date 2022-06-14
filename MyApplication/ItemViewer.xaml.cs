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

namespace MyApplication
{
    /// <summary>
    /// Interaction logic for ItemViewer.xaml
    /// </summary>
    public partial class ItemViewer : Window
    {
        public ItemViewer()
        {
            InitializeComponent();
        }

        private void bttnAdd_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Add(txtName.Text);
            txtName.Clear();
        }
    }
}
