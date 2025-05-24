using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Lab12_13.Model
{
    public class EnumExtension: MarkupExtension
    {
        public IValueConverter Converter { get; set; }
        public Type EnumType { get; set; }
        public EnumExtension() { }
        public EnumExtension(Type enumType) => EnumType = enumType;
        public override object ProvideValue(IServiceProvider serviceProvider)
            => Enum.GetValues(EnumType).Cast<ValueType>()
                   .Select(t => Converter?.Convert(t, EnumType, null, Thread.CurrentThread.CurrentUICulture) ?? t);
    }
}
