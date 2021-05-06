using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;

namespace Sorter
{
    /// <summary>
    /// Provides the methods for working with text files.
    /// </summary>
    public static class FileData
    {
        private const string Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// Creates a window that provide possibility to open a text file.
        /// </summary>
        /// <returns>Returns data string.</returns>
        public static string OpenFile()
        {
            var data = string.Empty;

            var openFileDialog = new OpenFileDialog
            {
                Filter = Filter,
                InitialDirectory = Path
            };
            if (openFileDialog.ShowDialog() == true)
                data = File.ReadAllText(openFileDialog.FileName);


            if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data)) return data;

            MyMessageBox.EmptyFile();
            return string.Empty;
        }

        /// <summary>
        /// Creates a window that provide possibility to save a text file in any dirrectory.
        /// </summary>
        /// <param name="data">Data string.</param>
        public static bool SaveFile(string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                MyMessageBox.EmptySaveField();
                return false;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Filter,
                InitialDirectory = Path
            };
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, data);
            return true;
        }

        /// <summary>
        /// Opens a file and reads the data from it.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Returns sample data string.</returns>
        public static string OpenSample(string path)
        {
            string data;

            try
            {
                data = File.ReadAllText(path);
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException or FileNotFoundException)
            {
                MyMessageBox.IncorrectPath();
                return string.Empty;
            }

            return data;
        }
    }
}