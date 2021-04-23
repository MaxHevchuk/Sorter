using System;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Sorter
{
    /// <summary>
    /// Provide methods for checking if data matches the given data types. 
    /// </summary>
    public static class DataChecker
    {
        public static bool CheckForCorrect(string data, Enum dataType, string separator)
        {
            if (data is not {Length: > 0})
            {
                MessageBox.Show("Please, enter data in the field.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            string[] dataArray = data.Split(new[] {separator}, StringSplitOptions.None);
            switch (dataType)
            {
                case DataType.StrEng: return CheckIfElemIsEng(dataArray);

                case DataType.StrUa: return CheckIfElemIsUa(dataArray);

                case DataType.IntTwo: return CheckIfElemIsBinary(dataArray);

                case DataType.IntTen: return CheckIfElemIsDecimal(dataArray);

                case DataType.IntSixteen: return CheckIfElemIsHex(dataArray);

                default:
                    return false;

                // case DataType.Size:
                //     return CheckIfElemIsSize(data);
                //     break;
            }
        }

        private static bool CheckIfElemIsEng(string[] data) => CheckIfElemIsLetters(data, Eng.A);

        private static bool CheckIfElemIsUa(string[] data) => CheckIfElemIsLetters(data, Ua.А);

        private static bool CheckIfElemIsLetters(string[] data, Enum nameOfEnum) =>
            data.All(word =>
                word.ToCharArray().All(letter =>
                    Enum.IsDefined(nameOfEnum.GetType(), letter.ToString())));

        private static bool CheckIfElemIsBinary(string[] data) =>
            data.All(word =>
                word.ToCharArray().All(c =>
                    c is '0' or '1'));

        private static bool CheckIfElemIsDecimal(string[] data) =>
            data.All(word => int.TryParse(word, out _));

        private static bool CheckIfElemIsHex(string[] data) =>
            data.All(word =>
                int.TryParse(word, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out _));
    }
}