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

namespace HeadSoccer
{
    /// <summary>
    /// Interaction logic for Comunicazione.xaml
    /// </summary>
    public partial class Comunicazione : Window
    {
        ComunicazionePlayer comPlayer = null;
        string ipDest = string.Empty;
        public Comunicazione()
        {
            InitializeComponent();
            ipDest = txtIp.Text;
        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
           comPlayer = new ComunicazionePlayer();
           comPlayer.Send("c;" + txtNome.Text, ipDest);
        }
    }
}
