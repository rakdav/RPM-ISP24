using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lesson29
{
    [MarkupExtensionReturnType(typeof(string))]
    public class SumExtension : MarkupExtension
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SumExtension(){}
        public SumExtension(int x)
        {
            X = x;
            Y = 10;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (X + Y).ToString();
        }
    }
}
