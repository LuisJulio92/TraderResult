using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TraderResult.Datos;
using TraderResult.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TraderResult.ViewModels
{
    public class ResultPageViewModel : BaseViewModel
    {
        public ResultPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
             ShowOperation();
        }



        private List<Operation> operationList;
        public List<Operation> OperationList
        {
            get { return operationList; }
            set { SetValue(ref operationList, value); }
        }


        public async Task ShowOperation()
        {
            var funtion = new DOperation();
            OperationList = await funtion.ShowOperation();
        }
    }
}
