using System;
using System.Linq;
using System.Windows;

namespace Sorter
{
    /// <summary>
    /// Provide methods for checking if data matches the given data types. 
    /// </summary>
    public static class DataChecker
    {
        private const string AlphabetEnglish = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string AlphabetUkrainian = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгдеєжзиіїйклмнопрстуфхцчшщьюя";
        private const string NumbersBinary = "01";
        private const string NumbersDecimal = "-0123456789";
        private const string NumbersHexadecimal = "0123456789AaBbCcDdEeFf";

        public static bool CheckForCorrect(string data, Enum dataType, string separator)
        {
            if (data is not {Length: > 0})
            {
                MessageBox.Show("Please, enter data in the field.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            var dataArray = data.Split(new[] {separator}, StringSplitOptions.None);
            return dataType switch
            {
                DataType.StringEnglish => CheckIfElementsIsCorrect(dataArray, AlphabetEnglish),
                DataType.StringUkrainian => CheckIfElementsIsCorrect(dataArray, AlphabetUkrainian),
                DataType.NumberBinary => CheckIfElementsIsCorrect(dataArray, NumbersBinary),
                DataType.NumberDecimal => CheckIfElementsIsCorrect(dataArray, NumbersDecimal),
                DataType.NumberHexadecimal => CheckIfElementsIsCorrect(dataArray, NumbersHexadecimal),
                DataType.Length => true,
                _ => false
            };
        }

        private static bool CheckIfElementsIsCorrect(string[] strings, string constant) =>
            strings.All(element =>
                element.ToCharArray().All(constant.Contains));
    }
}