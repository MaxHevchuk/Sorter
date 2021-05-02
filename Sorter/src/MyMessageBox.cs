using System.Windows;

namespace Sorter
{
    /// <summary>
    /// Provides methods that displays a specific error message.
    /// </summary>
    public static class MyMessageBox
    {
        public static void IncorrectData()
        {
            MessageBox.Show("The entered data does not match the selected type.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EmptyField()
        {
            MessageBox.Show("Please, enter data in the field.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void EmptyFile()
        {
            MessageBox.Show("Select the file with the corresponding data.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EmptySaveField()
        {
            MessageBox.Show("The field is empty. Input some data if you want to save it.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void IncorrectPath()
        {
            MessageBox.Show("Can't find the file for the specified path.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}