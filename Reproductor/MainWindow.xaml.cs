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

        public MainWindow()
        {
            InitializeComponent();
            pbCancion.Visibility = Visibility.Hidden;
            txtLetra.Visibility = Visibility.Hidden;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pbCancion.Value = reader.CurrentTime.Seconds;
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            btnReproducir.Visibility = Visibility.Hidden;
            pbCancion.Visibility = Visibility.Visible;
            txtLetra.Visibility = Visibility.Visible;
            reader = new AudioFileReader("Reproductor/cancionKaraoke.mp3");
            output = new WaveOut();
            output.Init(reader);
            output.Play();

            pbCancion.Maximum = reader.TotalTime.TotalSeconds;

            timer.Start();
        }
    }
}