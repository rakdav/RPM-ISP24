using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson24.Model
{
    public class Person:IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        {
                            if (Name == null) error = "Поле пустое";
                            else
                            if (!Name!.All(c => char.IsLetter(c) || c == ' '))
                                error = "Должны быть только буквы";
                        }
                        break;
                    case "SurName":
                        {
                            if (SurName == null) error = "Поле пустое";
                            else
                            if (!SurName!.All(c => char.IsLetter(c) || c == ' '))
                                error = "Должны быть только буквы";
                        }
                        break;
                    case "Email":
                        {
                            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                            if (Email == null) error = "Поле пустое";
                            else
                            if (!Regex.IsMatch(Email!, pattern, RegexOptions.IgnoreCase))
                                error = "Неверный email";
                        }
                        break;

                }
                return error;
            }
        }

        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string Error => throw new NotImplementedException();
    }
}
