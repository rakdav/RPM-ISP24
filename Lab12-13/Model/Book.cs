using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab12_13.Model
{
    public enum Zhanr
    {
        Children,
        Adult,
        Enamored,
        Desperate
    }
    public class Book : IDataErrorInfo, INotifyPropertyChanged
    {
        private string? title;
        public string? Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private Zhanr? bookZhanr;
        public Zhanr? BookZhanr
        {
            get { return bookZhanr; }
            set
            {
                bookZhanr = value;
                OnPropertyChanged(nameof(BookZhanr));
            }
        }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Title":
                        if (Title != null)
                        {
                            if (!Regex.IsMatch(Title!, @"[A-Za-z]+$"))
                                error = "Имя не должно содержать вспомогательных символов";
                        }
                        else
                        {
                            error = "Имя не должно быть пустым";
                        }
                        break;
                    case "BookZhanr":
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
