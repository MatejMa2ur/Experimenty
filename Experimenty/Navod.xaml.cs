using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Experimenty
{
    /// <summary>
    /// Interaction logic for Navod.xaml
    /// </summary>
    public partial class Navod : Window
    {
        public Navod()
        {
            InitializeComponent();
            NavodText.Text = File.ReadAllText("ReadMe.txt");
        }
    }
}
;