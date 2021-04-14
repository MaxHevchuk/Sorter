using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            InitializeComponent();
        }

        private void AddHandlersToButtons()
        {
            // LeftControlMenu.AddHandler(Button.Click, new RoutedEventHandler(ControlMenuEvents)));
        }

        private void ChangeLocalization(object sender, RoutedEventArgs e)
        {
            new MenuWindow((Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "uk") ? "en" : "uk")
                .Show();
            Close();
        }

        private void ControlMenuEvents(object sender, RoutedEventArgs e)
        {
            object id = e.OriginalSource;
            object tag = ((Button) id).Tag;
            // switch (tag)
            // {
            //     case "Clear":
            //         if (id.Equals(ClearButtonLeft))
            //         {
            //             InputText.Text = "";
            //         }
            //
            //         if (id.Equals(ClearButtonRight))
            //         {
            //             OutputText.Text = "";
            //         }
            //
            //         break;
            //     case "Copy":
            //         if (id.Equals(CopyButtonLeft))
            //         {
            //             Clipboard.SetText(InputText.Text);
            //         }
            //
            //         if (id.Equals(CopyButtonRight))
            //         {
            //             Clipboard.SetText(OutputText.Text);
            //         }
            //
            //         MessageBox.Show(localization.resources.CopyClipboardMessage);
            //         
            //         
            //         break;
            // }
        }
    }
}