using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace Delivery.Utilities
{
    public class PhoneMaskConverter : IValueConverter
    {
        private const int MaxPhoneNumberLength = 11; // Максимальная длина номера телефона

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return FormatPhoneNumber(text);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return ClearPhoneNumber(text);
            }

            return value;
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            // Удаление всех символов, кроме цифр
            string cleanedNumber = Regex.Replace(phoneNumber, "[^0-9]", "");

            // Ограничение длины номера телефона
            cleanedNumber = cleanedNumber.Substring(0, Math.Min(cleanedNumber.Length, MaxPhoneNumberLength));

            // Применение маски для телефонного номера
            if (cleanedNumber.Length >= 10)
            {
                return $"+7 ({cleanedNumber.Substring(1, 3)}) {cleanedNumber.Substring(4, 3)}-{cleanedNumber.Substring(7, 2)}-{cleanedNumber.Substring(9)}";
            }

            return cleanedNumber;
        }

        private string ClearPhoneNumber(string formattedPhoneNumber)
        {
            // Удаление всех символов, кроме цифр
            return Regex.Replace(formattedPhoneNumber, "[^0-9]", "");
        }
    }
}

