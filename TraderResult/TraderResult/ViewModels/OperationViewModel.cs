using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TraderResult.Datos;
using TraderResult.Models;
using Xamarin.Forms;

namespace TraderResult.ViewModels
{
    public class OperationViewModel : BaseViewModel
    {
        public OperationViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CurrentDate = DateTime.Now.ToString();
        }

        #region Propertys
        private string idOperation;
        public string IdOperation
        {
            get { return idOperation; }
            set { SetValue(ref idOperation, value);  }
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set 
            {
                date = value;
                OnPropertyChanged(Date.ToString());
            }
        }
        

        private string currentDate;
        public string CurrentDate
        {
            get { return currentDate; }
            set { SetValue(ref currentDate, value);  }
        }



        private string operationType;
        public string OperationType
        {
            get { return operationType; }
            set { SetValue(ref operationType, value);}
        }

        private string selecOperation;
        public string SelectOperation
        {
            get { return selecOperation; }
            set{SetProperty(ref selecOperation, value);
                OperationType = operationType;}
        }

        private string market;
        public string Market
        {
            get { return market; }
            set { SetValue(ref market, value); }
        }

        private string selectionMarket;
        public string SelectionMarket
        {
            get { return selectionMarket; }
            set { SetProperty(ref selectionMarket, value); 
                Market = market;}
        }

        private string entry;
        public string Entry
        {
            get { return entry; }
            set { SetValue( ref entry, value); }
        }

        private string target;
        public string Target
        {
            get { return target; }
            set { SetValue(ref target, value); }
        }

        private string typeResult;
        public string TypeResult
        {
            get { return typeResult; }
            set { SetValue(ref typeResult , value); }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { SetValue(ref result, value); }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { SetValue(ref total, value); }
        }

        #endregion

        #region Methods
        public void Operator()
        {
            if (SelectOperation == "Venta")
            {
                Total = Convert.ToDecimal(Entry) - Convert.ToDecimal(Target);
                Result = Total.ToString("N2");
            }
            else
            {
                Total = Convert.ToDecimal(Target) - Convert.ToDecimal(Entry);
                Result = Total.ToString("N2");
            }
            valid();
        }
        public decimal valid()
        {
            if (Total < 0)
            {
                TypeResult = "Perdida";
            }
            else
            {
                TypeResult = "Ganada";
            }
            return Total;
        }
        public async Task SaveOperator()
        {
            var fun = new DOperation();
            var parameter = new Operation();
            parameter.Date = Date.ToString("dd/MM/yyyy");
            parameter.OperationType = SelectOperation;
            parameter.Market = SelectionMarket;
            parameter.Entry = Entry;
            parameter.Target = Target;
            parameter.TypeResult = TypeResult;
            parameter.Result = Result.ToString();
            await fun.InsertOperation(parameter);
            await DisplayAlert("Comentario", "Operacion Guardada", "OK");
            
        }
        #endregion


        #region Commands
        public ICommand OperatorCommand => new Command(() => Operator());
        public ICommand SaveCommand => new Command(async () => await SaveOperator());
        #endregion
    }
}
