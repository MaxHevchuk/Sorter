using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Sorter
{
    public static class FileData
    {
        private const string Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static string OpenFile()
        {
            var data = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = Filter,
                InitialDirectory = Path
            };
            if (openFileDialog.ShowDialog() == true)
                data = File.ReadAllText(openFileDialog.FileName);


            if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data)) return data;
            
            MessageBox.Show("Select the file with the corresponding data.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return string.Empty;

        }

        public static void SaveFile(string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Select the file with the corresponding data.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = Filter,
                    InitialDirectory = Path
                };
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, data);
            }
        }

        public static string OpenSample(string path)
        {
            string data;

            try
            {
                data = File.ReadAllText(path);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException or FileNotFoundException)
            {
                MessageBox.Show("Can't find the file for the specified path.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }

            return data;
        }
    }
}