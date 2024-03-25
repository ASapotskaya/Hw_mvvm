using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_Mvvm
{
    public class ViewModelTovar : INotifyPropertyChanged
    {
        public ObservableCollection<Tovar> Tovares { get; set; }

        public Tovar selectTovar;
        public Tovar SelectTovar
        {
            get { return selectTovar; }
            set
            {
                selectTovar = value;
                OnPropCh("SelectTovar");
            }
        }
        private void OnPropCh([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

        }

        public ViewModelTovar()
        {
            Tovares = new ObservableCollection<Tovar>
            {
             new Tovar {Title="Молоко", Company="Ферма", Price=560 },
             new Tovar {Title="Хлеб", Company="Пончик", Price =100},
             new Tovar {Title="Масло", Company="Ферма", Price=300  },
             new Tovar {Title="Мандарин", Company="Сад", Price=350}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        My_Command add_command;
        public My_Command ADD_command
        {
            get
            {
                return add_command ??
                    (
                        add_command = new My_Command(obj =>
                        {
                            Tovar t_new = new Tovar();
                            Tovares.Insert(0, t_new);
                            SelectTovar = t_new;
                        }
                    ));
            }
        }

        My_Command remove_command;
        public My_Command Remove_command
        {
            get
            {
                return remove_command ??
                    (
                        remove_command = new My_Command(obj =>
                        {
                            Tovar t = obj as Tovar;
                            if (t != null)
                            {
                                Tovares.Remove(t);
                            }
                        },
                        (obj) => Tovares.Count > 0)
                    );
            }
        }

    }
}
