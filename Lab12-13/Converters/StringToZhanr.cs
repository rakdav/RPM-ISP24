using Lab12_13.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab12_13.Converters
{
    class StringToZhanr : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Zhanr zhanr=Zhanr.Children;
            if (value == null) value = "Для детей";
            switch (value.ToString())
            {
                case "Для детей": zhanr = Zhanr.Children; break;
                case "Для взрослых": zhanr = Zhanr.Adult; break;
                case "Для влюбленных": zhanr = Zhanr.Enamored; break;
                case "Для отчаявшихся": zhanr = Zhanr.Desperate; break;
            }
            return zhanr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextBlock text = value as TextBlock;
            
            return text!.Text;
        }
    }
}
