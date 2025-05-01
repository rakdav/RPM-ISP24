using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal interface IFigure
    {
        string Name { get; set; }
        double Area();
        double Perimetr();
    }
}
