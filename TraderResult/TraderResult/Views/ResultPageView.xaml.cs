using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderResult.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TraderResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPageView : ContentPage
    {
        ResultPageViewModel vm;
        public ResultPageView()
        {
            InitializeComponent();
            vm = new ResultPageViewModel(Navigation);
            BindingContext = vm;
            this.Appearing += ResultPageView_Appearing;
           
        }

        private async void ResultPageView_Appearing(object sender, EventArgs e)
        {
            await vm.ShowOperation();
        }
    }
}