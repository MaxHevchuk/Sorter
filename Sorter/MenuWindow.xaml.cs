using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        public MenuWindow(String culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            InitializeComponent();
        }

        private void ChangeLanguage(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            if (currentCulture.TwoLetterISOLanguageName == "uk")
            {
                menuWindow = new MenuWindow("en");
            }
            else
            {
                menuWindow = new MenuWindow("uk");
            }

            menuWindow.Show();
            Close();
        }
    }
}