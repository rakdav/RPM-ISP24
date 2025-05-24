using Lab12_13.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab12_13.Converters
{
    public class EnumToDescriptionConverter : IValueConverter
    {
        public IDictionary Dict { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = value?.ToString();
            return Dict.Contains(key) ? Dict[key] : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return Dict.Cast<DictionaryEntry>().FirstOrDefault(p => p.Value == value).Key;
        }
    }
}
