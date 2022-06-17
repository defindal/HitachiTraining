using HitachiTraining;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace MyWPF
{
    /// <summary>
    /// Interaction logic for DataViewer.xaml
    /// </summary>
    public partial class DataViewer : Window
    {
        public DataViewer()
        {
            InitializeComponent();
            // LinqViewer.ItemsSource = new LINQPractice().fromJSON();

            ListDictionary listDictionary = new ListDictionary();
            listDictionary.Add(62, "Indonesia");
            listDictionary.Add(63, "Philippine");
            listDictionary.Add(60, "Malaysia");

            LinqViewer.ItemsSource = listDictionary;
        }
    }
}
