using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sorter
{
    public partial class MenuWindow
    {
        private string _inputData;
        private string _outputData;
        private string[] _tempArray;
        private DataType? _dataType;
        private SortingMethods _sortingMethod;
        private bool _isInAscendingOrder;
        private bool _isIgnoreDuplicate;
        private string _inputSeparator;
        private string _outputSeparator;
        private long _time;
        private int _permutation;
        private IMethods _sorter;

        private bool _isFullscreen;

        private static Method<int> _methodInt;
        private static Method<string> _methodStr;

        private delegate int Method<T>(ref T[] data, out long time) where T : IComparable<T>;


        public MenuWindow()
        {
            InitializeComponent();
        }

        private MenuWindow(String culture, string data)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            InitializeComponent();
            InputText.Text = data;
        }

        private void BtnSort(object sender, RoutedEventArgs e)
        {
            _inputData = InputText.Text;
            _inputSeparator = (InputSeparatorText.Text.Length == 0) ? " " : InputSeparatorText.Text;
            _outputSeparator = (OutputSeparatorText.Text.Length == 0) ? " " : OutputSeparatorText.Text;


            if (!DataChecker.CheckForCorrect(_inputData, _dataType, _inputSeparator))
            {
                MessageBox.Show("The entered data does not match the selected type.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _isInAscendingOrder = (bool) AscendingRadioButt.IsChecked;
            _isIgnoreDuplicate = (bool) IgnoreDuplicateCheckBox.IsChecked;

            if (_sorter != null)
            {
                if (_sorter.GetType() == typeof(MethodsDesc) && _isInAscendingOrder)
                {
                    _sorter = new MethodsAsc();
                }
                else if (_sorter.GetType() == typeof(MethodsAsc) && !_isInAscendingOrder)
                {
                    _sorter = new MethodsDesc();
                }
            }
            else _sorter = _isInAscendingOrder ? new MethodsAsc() : new MethodsDesc();

            ChooseSortingMethod();

            _tempArray = _inputData.Split(new[] {_inputSeparator}, StringSplitOptions.None);
            if (_isIgnoreDuplicate) _tempArray = _tempArray.Distinct().ToArray();
            if (_dataType is DataType.StrEng or DataType.StrUa)
            {
                _permutation = _methodStr(ref _tempArray, out _time);
                _outputData = string.Join(_outputSeparator, _tempArray);
            }
            else
            {
                var tempArrayInt = _Convert.ToIntArray(_tempArray, _dataType);
                _permutation = _methodInt(ref tempArrayInt, out _time);
                _outputData = _Convert.ToString(tempArrayInt, _dataType, _outputSeparator);
            }


            OutputText.Text = _outputData;
            PermutationNumberText.Content = _permutation.ToString();
            LenghtNumberText.Content = _tempArray.Length;
            TimeNumberText.Content = $"{_time} ticks";
        }

        private void ChooseSortingMethod()
        {
            switch (_sortingMethod)
            {
                case SortingMethods.Cocktail:
                    _methodInt = _sorter.CocktailSort;
                    _methodStr = _sorter.CocktailSort;
                    break;
                case SortingMethods.Insertion:
                    _methodInt = _sorter.InsertionSort;
                    _methodStr = _sorter.InsertionSort;
                    break;
                case SortingMethods.Merge:
                    _methodInt = _sorter.MergeSort;
                    _methodStr = _sorter.MergeSort;
                    break;
                case SortingMethods.Selection:
                    _methodInt = _sorter.SelectionSort;
                    _methodStr = _sorter.SelectionSort;
                    break;
                default:
                    _methodInt = _sorter.BubbleSort;
                    _methodStr = _sorter.BubbleSort;
                    break;
            }
        }

        private void BtnChangeLocalization(object sender, RoutedEventArgs e)
        {
            new MenuWindow((Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "uk") ? "en" : "uk",
                    InputText.Text)
                .Show();
            Close();
        }

        private void BtnOpenFile(object sender, RoutedEventArgs e)
        {
            InputText.Text = FileData.OpenFile();
        }

        private async void BtnSaveFile(object sender, RoutedEventArgs e)
        {
            string name = ((Button) sender).Name;
            TextBox textBox = (name == "LeftSaveButt") ? InputText : OutputText;
            FileData.SaveFile(textBox.Text);

            TextBlock textBlock = SaveFileText;
            textBlock.Visibility = Visibility.Visible;
            textBlock.Background = Brushes.Red;
            await Task.Delay(3000);
            textBlock.Visibility = Visibility.Collapsed;
        }

        private void BtnClearText(object sender, RoutedEventArgs e)
        {
            string name = ((Button) sender).Name;
            TextBox textBox = (name == "LeftClearButt") ? InputText : OutputText;
            textBox.Text = String.Empty;
        }

        private async void BtnCopyText(object sender, RoutedEventArgs e)
        {
            string name = ((Button) sender).Name;
            TextBox textBox = (name == "LeftCopyButt") ? InputText : OutputText;
            Clipboard.SetText(textBox.Text);

            TextBlock textBlock = CopyToClipboardText;
            textBlock.Visibility = Visibility.Visible;
            textBlock.Background = Brushes.Green;
            await Task.Delay(3000);
            textBlock.Visibility = Visibility.Collapsed;
        }

        private void BtnFullscreen(object sender, RoutedEventArgs e)
        {
            var columnDefinition = ((Button) sender).Name == "LeftFullScreenButt" ? LeftCol : RightCol;
            Button button = (Button) sender;

            if (!_isFullscreen)
            {
                foreach (var column in Base.ColumnDefinitions)
                {
                    if (column.Name != columnDefinition.Name)
                    {
                        column.Width = new GridLength(0, GridUnitType.Star);
                    }
                }

                button.Content = FindResource("FullscreenOut");
                _isFullscreen = true;
            }
            else
            {
                foreach (var column in Base.ColumnDefinitions)
                {
                    string columnName = column.Name;
                    if (columnName != columnDefinition.Name)
                    {
                        column.Width = (columnName == CenterCol.Name)
                            ? new GridLength(1.5, GridUnitType.Star)
                            : new GridLength(2, GridUnitType.Star);
                    }
                }

                button.Content = FindResource("FullscreenIn");
                _isFullscreen = false;
            }
        }

        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeComboBox.SelectedItem != null)
            {
                ComboBoxItem cbi = (ComboBoxItem) TypeComboBox.SelectedItem;
                if (cbi == UaComboBox) _dataType = DataType.StrUa;
                else if (cbi == BinComboBox) _dataType = DataType.IntTwo;
                else if (cbi == DecComboBox) _dataType = DataType.IntTen;
                else if (cbi == HexComboBox) _dataType = DataType.IntSixteen;
                else _dataType = DataType.StrEng;
            }
        }

        private void MethodComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MethodComboBox.SelectedItem != null)
            {
                ComboBoxItem cbi = (ComboBoxItem) MethodComboBox.SelectedItem;
                if (cbi == CocktailComboBox) _sortingMethod = SortingMethods.Cocktail;
                else if (cbi == InsertionComboBox) _sortingMethod = SortingMethods.Insertion;
                else if (cbi == MergeComboBox) _sortingMethod = SortingMethods.Merge;
                else if (cbi == SelectionComboBox) _sortingMethod = SortingMethods.Merge;
                else _sortingMethod = SortingMethods.Bubble;
            }
        }

        private void BtnSample(object sender, RoutedEventArgs e)
        {
            string path;
            path = _dataType is DataType.StrEng or DataType.StrUa
                ? @"..\..\..\res\sample_str.txt"
                : @"..\..\..\res\sample_num.txt";

            InputText.Text = File.ReadAllText(path);
        }
    }
}