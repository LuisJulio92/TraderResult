using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TraderResult.Datos;
using TraderResult.Models;
using Xamarin.Forms;

namespace TraderResult.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _ = OperationCount();
            _ = OperationCountLosser();
            _ = SumSp();
            _ = TopThreg();
        }

        #region Propertys
        private int countOpGan;
        public int CountOpGan
        {
            get { return countOpGan; }
            set { SetValue(ref countOpGan, value); }
        }

        private int countOpLosser;
        public int CountOpLosser
        {
            get { return countOpLosser; }
            set { SetValue(ref countOpLosser, value); }
        }

        private decimal promedio;
        public decimal Promedio
        {
            get { return promedio; }
            set { SetValue(ref promedio, value); }
        }


        private List<Operation> topThreeG;
        public List<Operation> TopThreeG
        {
            get { return topThreeG; }
            set { SetValue(ref topThreeG, value); }
        }

        public async Task TopThreg()
        {
            var funtion = new DOperation();
            TopThreeG = await funtion.TopOperation();
        }
        #endregion



        #region Methods

        public async Task<int> OperationCountLosser()
        {
            var funcion = new DOperation();
            CountOpLosser = await funcion.CountOperationP();
            return CountOpLosser;
        }
        public async Task<int> OperationCount()
        {
            var funcion = new DOperation();
            CountOpGan = await funcion.CountOperationG();
            return CountOpGan;
        }
        
        public async Task<decimal> SumSp()
        {
            var funcion = new DOperation();
            Promedio = await funcion.SumOperationSp();
            return Promedio;
        }
        
        
       

        #endregion




    }
}
