using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Comunicazione.xaml
    /// </summary>
    public partial class Comunicazione : Window
    {
        ComunicazionePlayer cm = new ComunicazionePlayer();
        public Comunicazione()
        {
            InitializeComponent();
            cm.ipDest = txtIp.Text;
            Thread t = new Thread(new ThreadStart(cm.ThreadReceive));
            t.Start();
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            cm.SendPacketWithData("c;", txtNome.Text);
        }
    }
}
