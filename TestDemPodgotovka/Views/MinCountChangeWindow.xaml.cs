using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace TestDemPodgotovka.Views
{
    /// <summary>
    /// Логика взаимодействия для MinCostChangeWindow.xaml
    /// </summary>
    public partial class MinCountChangeWindow : Window, INotifyPropertyChanged
    {
        private double count;
        public MinCountChangeWindow(double _count)
        {
            InitializeComponent();
            count = _count;
            DataContext = this;
        }
        public double Count { get => count; set { count = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
