using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Sorter
{
    public static class FileData
    {
        public static string OpenFile()
        {
            string data = null;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (openFileDialog.ShowDialog() == true)
                data = File.ReadAllText(openFileDialog.FileName);


            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Select the file with the corresponding data.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

            return data;
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
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, data);
            }
        }

        public static string OpenSample(string path)
        {
            string data = "";

            try
            {
                data = File.ReadAllText(path);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is FileNotFoundException)
            {
                MessageBox.Show("Can't find the file for the specified path.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

            return data;
        }
    }
}