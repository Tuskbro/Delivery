using Delivery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Delivery.Utilities
{
    public class FloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float floatValue)
            {
                return floatValue.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                if (float.TryParse(text, out float result))
                {
                    return result;
                }
            }

            return value;
        }
    }

    public class LettersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                // Удаление всех символов, кроме букв
                string lettersOnly = Regex.Replace(text, "[^a-zA-Zа-яА-Я]", "");
                return lettersOnly;
            }

            return value;
        }

        
    }
    public class DateOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.DateOnly date)
            {
                return date.ToString("d");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                // Удаление всех символов, кроме цифр
                string cleanedText = new string(text.Where(char.IsDigit).ToArray());

                
                if (!string.IsNullOrEmpty(cleanedText))
                {
                    
                    return int.Parse(cleanedText);
                }
            }

            return null; 
        }
    }

    public class RegNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return FormatRegNumber(text);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return ClearRegNumber(text);
            }

            return value;
        }

        private string FormatRegNumber(string regNumber)
        {

            string cleanedNumber = Regex.Replace(regNumber, "[^0-9А-Яа-я]", "");


            cleanedNumber = cleanedNumber.Substring(0, Math.Min(cleanedNumber.Length, 6));

            if (Regex.IsMatch(cleanedNumber, "^[А-Яа-я]{2}[0-9]{3}[А-Яа-я]$"))
            {

                if (cleanedNumber.Length >= 5)
                {

                    return $"{cleanedNumber.Substring(0, 2)}{cleanedNumber.Substring(2, 3)}{cleanedNumber.Substring(5)}";
                }
                
            }


            return cleanedNumber;
        }

        private string ClearRegNumber(string formattedRegNumber)
        {

            return Regex.Replace(formattedRegNumber, "[^0-9А-Яа-я]", "");
        }
    }


}
