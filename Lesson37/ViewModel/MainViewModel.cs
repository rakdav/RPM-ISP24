
using Lesson37.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson37.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged(nameof(SelectedPhone));
            }
        }
        public MainViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone
                {
                    Title="Samsung Galaxy",
                    Company="Samsung",
                    Price=30000
                },
                new Phone
                {
                    Title="NX400",
                    Company="Xiaomi",
                    Price=30000
                },
                new Phone
                {
                    Title="IPhone 15",
                    Company="Apple",
                    Price=150000
                }
            };
        }

        public ObservableCollection<Phone> Phones { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
