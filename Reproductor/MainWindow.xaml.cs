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

using Microsoft.Win32;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using System.Windows.Threading;

namespace Reproductor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        // Lector de archivos
        AudioFileReader reader;
        // Comunicación con la tarjeta de audio exclusivo para salidas
        WaveOut output;
        double progress;

        public MainWindow()
        {
            InitializeComponent();
            pbCancion.Visibility = Visibility.Hidden;
            txtLetra.Visibility = Visibility.Hidden;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progress += 1;
            pbCancion.Value = progress;

            if (pbCancion.Value < 7)
            {
                txtLetra.Text = "A mi me gusta el tangananica \n" +
                    "Y yo prefiero el tangananá \n" +
                    "El mejor verso es tangananica \n" +
                    "El mejor verso es tangananá.";
            }
            if (pbCancion.Value > 14 && pbCancion.Value < 28)
            {
                txtLetra.Text = "Tangananica nica nica nica \n" +
                    "Tanganana. \n" +
                    "Todo lo explica, no explica na \n";
            }
            if (pbCancion.Value > 28 && pbCancion.Value < 43)
            {
                txtLetra.Text = "Para alegrarme digo tangananica \n" +
                    "Para reírme digo tanganana \n" +
                    "Comí un rico tangananica \n" +
                    "A mí me dieron tanganana.";
            }
            if (pbCancion.Value > 43 && pbCancion.Value < 55)
            {
                txtLetra.Text = "Tangananica nica nica nica \n" +
                    "Tanganana. \n" +
                    "Me tienes pica pica, no pasa na \n";
            }
            if (pbCancion.Value > 55 && pbCancion.Value < 68)
            {
                txtLetra.Text = "Cómo voy a perder mi palabra es tan buena \n" +
                    "Tu palabra es tan mala, no hay nada qué hacer \n" +
                    "Cómo vas a ganar \n" +
                    "Si la mejor palabra es tanganana.";
            }
            if (pbCancion.Value > 70 && pbCancion.Value < 85)
            {
                txtLetra.Text = "Tú siempre dices tangananica \n" +
                    "Tú siempre gritas tanganana \n" +
                    "Ya no soporto el tangananica \n" +
                    "Y yo detesto tu tanganana.";
            }
            if (pbCancion.Value > 85 && pbCancion.Value < 99)
            {
                txtLetra.Text = "Tangananica nica nica nica \n" +
                    "Tanganana. \n" +
                    "Nuestra mamá nos va a retar... \n";
            }
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            btnReproducir.Visibility = Visibility.Hidden;
            pbCancion.Visibility = Visibility.Visible;
            txtLetra.Visibility = Visibility.Visible;
            reader = new AudioFileReader("cancionKaraoke.mp3");
            output = new WaveOut();
            output.Init(reader);
            output.Play();

            pbCancion.Maximum = reader.TotalTime.TotalSeconds;

            timer.Start();
        }
    }
}
