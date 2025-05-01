using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab12_13.Model
{
    public class ClassMoto:IDataErrorInfo, INotifyPropertyChanged
    {
        private string? marka;
        public string? Marka 
        {
            get { return marka; }
            set 
            {
                marka = value;
                OnPropertyChanged(nameof(Marka));
            } 
        }
        private Color? color;
        public Color? Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private string? serial;
        public string? Serial
        {
            get { return serial; }
            set
            {
                serial = value;
                OnPropertyChanged(nameof(Serial));
            }
        }
        private string? regNumber;        
        public string? RegNumber
        {
            get { return regNumber; }
            set
            {
                regNumber = value;
                OnPropertyChanged(nameof(RegNumber));
            }
        }
        private int year;
        public int Year 
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }
        private int yearTech;

        public int YearTech
        {
            get { return yearTech; }
            set
            {
                yearTech = value;
                OnPropertyChanged(nameof(YearTech));
            }
        }
        private decimal price;
        public decimal Price 
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public ClassMoto(string? marka, Color? color, string? serial, string? regNumber, int year, int yearTech, decimal price)
        {
            this.marka = marka;
            this.color = color;
            this.serial = serial;
            this.regNumber = regNumber;
            this.year = year;
            this.yearTech = yearTech;
            this.price = price;
        }

        public ClassMoto()
        {
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Marka":
                        if (Marka != null)
                        {
                            if (!Regex.IsMatch(Marka!, @"[A-Za-z0-9]+$"))
                                error = "Имя не должно содержать вспомогательных символов";
                        }
                        else
                        {
                            error = "Имя не должно быть пустым";
                        }
                        break;
                    case "Serial":
                        if (Serial != null)
                        {
                            if (!Regex.IsMatch(Serial!, @"[A-Za-z0-9]+$"))
                                error = "Серия не должна содержать вспомогательных символов";
                        }
                        else
                        {
                            error = "Имя не должно быть пустым";
                        }
                        break;
                    case "RegNumber":
                        if (RegNumber != null)
                        {
                            if (!Regex.IsMatch(RegNumber!, @"[A-Za-z0-9]+$"))
                                error = "Рег.номер не должен содержать вспомогательных символов";
                        }
                        else
                        {
                            error = "Имя не должно быть пустым";
                        }
                        break;
                    case "Year":
                        if (Year<=0)
                            error = "Поле не должно быть равно нулю или отрицательным";
                        break;
                    case "YearTech":
                        if (YearTech <= 0)
                            error = "Поле не должно быть равно нулю или отрицательным";
                        break;
                    case "Price":
                        if (Price <= 0)
                            error = "Поле не должно быть равно нулю или отрицательным";
                        break;
                    case "Color":break;
                }
                return error;
            }
        }

        public override string? ToString()
        {
            return Marka+" "+Color+" "+Serial+" "+RegNumber+" "+Year+" "+YearTech+" "+Price;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
