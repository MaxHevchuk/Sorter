using System;
using System.Globalization;
using System.Windows;

namespace Sorter
{
    public static class DataChecker
    {
        public static bool CheckForCorrect(string data, Enum dataType, string separator)
        {
            if (data == null || data.Length <= 0)
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

        private static bool CheckIfElemIsEng(string[] data)
        {
            return CheckIfElemIsLetters(data, Eng.a);
        }

        private static bool CheckIfElemIsUa(string[] data)
        {
            return CheckIfElemIsLetters(data, Ua.а);
        }

        private static bool CheckIfElemIsLetters(string[] data, Enum nameOfEnum)
        {
            bool isOk = true;
            Type typeOfEnum = nameOfEnum.GetType();
            foreach (string word in data)
            {
                if (word.Length <= 1)
                    isOk &= Enum.IsDefined(typeOfEnum, word);

                else
                {
                    foreach (char element in word)
                    {
                        isOk &= Enum.IsDefined(typeOfEnum, element.ToString());
                    }
                }
            }

            return isOk;
        }

        private static bool CheckIfElemIsBinary(string[] data)
        {
            bool isOk = true;
            foreach (string number in data)
            {
                isOk &= IsBin(number);
            }

            return isOk;
        }

        private static bool IsBin(string s)
        {
            foreach (var c in s)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }

        private static bool CheckIfElemIsDecimal(string[] data)
        {
            bool isOk = true;
            foreach (var number in data)
            {
                isOk &= IsDecimal(number);
            }

            return isOk;
        }

        private static bool IsDecimal(string s) => int.TryParse(s, out _);

        private static bool CheckIfElemIsHex(string[] data)
        {
            bool isOk = true;
            foreach (var number in data)
            {
                isOk &= IsHex(number);
            }

            return isOk;
        }

        private static bool IsHex(string s) =>
            int.TryParse(s, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out _);

        // private void CheckIfElemIsSize(string data)
        // {
        //     throw new NotImplementedException();
        // }
    }
}