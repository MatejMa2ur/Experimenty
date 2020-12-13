using Microsoft.Win32;
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

namespace Experimenty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Skryte { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            HidWidth.Text = Divne.Width.ToString();
            HidWidthSet.Value = Divne.Width;
            ul13ItemCircle.Visibility = Visibility.Hidden;
            ul13ItemRect.Visibility = Visibility.Hidden;

            zvacsi.Click += (sender, e) => ahoj.FontSize = ahoj.FontSize * 1.1; //2
            zmensi.Click += (sender, e) => ahoj.FontSize = ahoj.FontSize * 0.9; //2

            left.Click += (sender, e) => Canvas.SetLeft(kruh,Canvas.GetLeft(kruh) - 2); //3
            right.Click += (sender, e) => Canvas.SetLeft(kruh, Canvas.GetLeft(kruh) + 2); //3

            duha.Click += (sender,e) => rectang.Fill = new LinearGradientBrush(Color.FromRgb(255,0,0),Color.FromRgb(255,255,0),90.0); //4

            pick1.ValueChanged += (sender, e) => //5
            {
                var a = Convert.ToByte(pick1.Value);
                farebnyKruh.Fill = new SolidColorBrush(Color.FromRgb(a,a,a));
            };
            pick2.ValueChanged += (sender, e) =>
            {
                var a = Convert.ToByte(pick2.Value);
                farebnyKruh.Stroke = new SolidColorBrush(Color.FromRgb(a,a,a));
            };

            Divne.Click += (sender, e) => //6
            {
                if (meno.Text == "admin" && heslo.Password == "password")
                    if (Skryte)
                    {
                        Skryte = false;
                        Divne.Content = "Skryť";
                    }

                    else
                    {
                        Skryte = true;
                        Divne.Content = "Odkryť";
                    }
                 
                if (Skryte)
                    uloha2.Visibility = Visibility.Hidden;
                else
                    uloha2.Visibility = Visibility.Visible;

                meno.Text = "";
                heslo.Password = "";
            };

            Strelba.Click += async (sender, e) => //7
            {
                naboj.Visibility = Visibility.Visible;
                for (int i = 0; i < 220; i++)
                {
                    Canvas.SetLeft(naboj, i);
                    var a = Convert.ToByte(i);
                    await Task.Delay(1);
                    naboj.Fill = new SolidColorBrush(Color.FromRgb(a, a, a));
                }
                naboj.Visibility = Visibility.Hidden;
            };

            HidWidthSet.ValueChanged += (sender, e) => //10
            {
                Canvas.SetLeft(Divne, (220 - Divne.Width) / 2);
                Divne.Width = HidWidthSet.Value;
                HidWidth.Text = Divne.Width.ToString();
            };

            ul11Kruh.SizeChanged += (sender, e) => //11
            {
                ul11Entry2.Text = $"L:{Math.Round(ul11Entry1.ActualWidth,0)}\nR:{Math.Round(ul11Kruh.ActualWidth,0)}";
                ul11Kruh.Height = ul11Kruh.ActualWidth;
            };

            NavodHeader.Click += (sender, e) => 
            {
                Navod a = new Navod();
                a.Show();
            };

        }

        private void Duha_Checked(object sender, RoutedEventArgs e)
        {
            uloha4.Visibility = Visibility.Visible;
        }
        private void Duha_Unchecked(object sender, RoutedEventArgs e)
        {
            uloha4.Visibility = Visibility.Hidden;
        }

        private void Kruh_Checked(object sender, RoutedEventArgs e)
        {
            uloha3.Visibility = Visibility.Visible;
        }
        private void Kruh_Unchecked(object sender, RoutedEventArgs e)
        {
            uloha3.Visibility = Visibility.Hidden;
        }

        
        private void Obrazok_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg)|*.jpg|Png (*.png)|*.png";
            ofd.InitialDirectory = "c:\\";
            var a = ofd.ShowDialog();
            if (a == true)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri(ofd.FileName);
                bmp.EndInit();
                ul12Obrazok.Source = bmp;
            }
        }

        private void ul13Circle_Selected(object sender, RoutedEventArgs e)
        {
            ul13ItemRect.Visibility = Visibility.Hidden;
            ul13ItemCircle.Visibility = Visibility.Visible;
        }

        private void ul13Rectangle_Selected(object sender, RoutedEventArgs e)
        {
            ul13ItemRect.Visibility = Visibility.Visible;
            ul13ItemCircle.Visibility = Visibility.Hidden;
        }


    }
}
