using System;

namespace Sorter
{
    public static class _Convert
    {
        public static int[] ToIntArray(string[] data, Enum dataType)
        {
            switch (dataType)
            {
                case DataType.IntTwo: return BinToInt(data);

                case DataType.IntTen: return DecimalToInt(data);

                case DataType.IntSixteen: return HexToInt(data);

                default:
                    return null;
            }
        }

        public static string ToString(int[] data, Enum dataType, string separator)
        {
            switch (dataType)
            {
                case DataType.IntTwo: return BinToString(data, separator);

                case DataType.IntTen: return DecimalToString(data, separator);

                case DataType.IntSixteen: return HexToString(data, separator);

                default:
                    return null;
            }
        }

        // private static int[] EngToInt(string[] strings)
        // {
        //     return FromAlphabet(strings, Eng.a);
        // }
        //
        // private static int[] UaToInt(string[] strings)
        // {
        //     return FromAlphabet(strings, Ua.а);
        // }
        //
        // private static int[] FromAlphabet(string[] strings, Enum nameOfEnum)
        // {
        //     Type typeOfEnum = nameOfEnum.GetType();
        //     int[] resArray = new int[strings.Length];
        //
        //     for (int word = 0; word < strings.Length; word++)
        //     {
        //         int wordLenght = strings[word].Length;
        //         for (int letter = 0; letter < wordLenght; letter++)
        //         {
        //             int value = (int) Enum.Parse(typeOfEnum, strings[word][letter].ToString());
        //             int power = wordLenght - letter - 1;
        //             resArray[word] += value * (int) Math.Pow(10, power);
        //         }
        //     }
        //
        //     return resArray;
        // }

        private static int[] BinToInt(string[] strings)
        {
            return FromNumbers(strings, 2);
        }

        private static int[] DecimalToInt(string[] strings)
        {
            return FromNumbers(strings, 10);
        }

        private static int[] HexToInt(string[] strings)
        {
            return FromNumbers(strings, 16);
        }

        private static int[] FromNumbers(string[] strings, int toBase)
        {
            int[] resArray = new int[strings.Length];

            for (int number = 0; number < strings.Length; number++)
            {
                resArray[number] = Convert.ToInt32(strings[number], toBase);
            }

            return resArray;
        }

        // private static string EngToString(int[] data, string separator)
        // {
        //     return AlphabetToString(data, separator, Eng.a);
        // }
        //
        // private static string UaToString(int[] data, string separator)
        // {
        //     return AlphabetToString(data, separator, Ua.а);
        // }
        //
        // private static string AlphabetToString(int[] data, string separator, Enum nameOfEnum)
        // {
        //     Type typeOfEnum = nameOfEnum.GetType();
        //     string[] strings = new string[data.Length];
        //
        //     for (int word = 0; word < data.Length; word++)
        //     {
        //         int wordLength = (int) Math.Floor(Math.Log10(data[word] + 1));
        //         string text = string.Empty;
        //         for (int letter = 0; letter < wordLength; letter++)
        //         {
        //             int num = data[word] / (int) Math.Pow(10, wordLength - letter + 1) % 10;
        //             text += Enum.GetName(typeOfEnum, num);
        //         }
        //
        //         strings[word] = text;
        //     }
        //
        //     return string.Join(separator, strings);
        // }

        private static string BinToString(int[] data, string separator)
        {
            return NumToString(data, separator, 2);
        }

        private static string DecimalToString(int[] data, string separator)
        {
            return NumToString(data, separator, 10);
        }

        private static string HexToString(int[] data, string separator)
        {
            return NumToString(data, separator, 16);
        }

        private static string NumToString(int[] data, string separator, int toBase)
        {
            string[] strings = new string[data.Length];
            for (int word = 0; word < data.Length; word++)
            {
                strings[word] = Convert.ToString(data[word], toBase);
            }

            return string.Join(separator, strings);
        }
    }
}