using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWithContext;
using System.Collections.ObjectModel;

namespace WPFUI
{
    class MathViewModel : INotifyPropertyChanged
    {
        

        public MathViewModel()
        {
            Variables = new ObservableCollection<intVariable>();
            LastEquation = "";
        }



        public ObservableCollection<intVariable> variables;
        public ObservableCollection<intVariable> Variables
        {
            get
            {
                return variables;
            }
            set
            {
                this.variables = value;
                OnPropertyChanged("Variables");
            }
        }

        public String lastEquation;
        public String LastEquation
        {
            get
            {
                return lastEquation;
            }
            set
            {
                lastEquation = value;
                OnPropertyChanged("LastEquation");
            }
        }

        public void handleEquationSubmit(String s)
        {
            LastEquation = s;
            List<intVariable>  allComputed = Program.ParseAndAttemptComputeEquations(s);
            ObservableCollection<intVariable> addedList = Variables;
            foreach(intVariable computed in allComputed)
            {
                addedList.Add(computed);
            }
            Variables = addedList;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }

    }
}
