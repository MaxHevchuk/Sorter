using System.Windows;

namespace Sorter
{
    public partial class LanguageWindow : Window
    {
        public LanguageWindow()
        {
            InitializeComponent();
        }

        public void ChangeToUaLanguage(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow("uk");
            menuWindow.Show();
            Close();
        }
        public void ChangeToEnLanguage(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow("en");
            menuWindow.Show();
            Close();
        }
    }
}