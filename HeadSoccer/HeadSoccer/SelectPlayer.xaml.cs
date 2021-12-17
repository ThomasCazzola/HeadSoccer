using System;
using System.Collections.Generic;
using System.IO;
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

namespace HeadSoccer
{
    /// <summary>
    /// Logica di interazione per SelectPlayer.xaml
    /// </summary>
    public partial class SelectPlayer : Window
    {
        public SelectPlayer()
        {
            InitializeComponent();
        }

        private void btnClown_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(1);
            mw.Show();
            Close();
        }

        private void btnPlayer1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(2);
            mw.Show();
            Close();
        }
    }
}
