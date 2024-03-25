using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_Mvvm
{
    public class Tovar : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropCh("Title");
            }
        }
        private string company;
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropCh("Company");
            }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropCh("Price");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropCh([CallerMemberName] string prop_str = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop_str));
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private object selectTovar;

        public object SelectTovar { get => selectTovar; set => SetProperty(ref selectTovar, value); }



    }
}
