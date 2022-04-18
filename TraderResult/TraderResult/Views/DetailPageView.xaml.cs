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
    public partial class DetailPageView : ContentPage
    {
        DetailPageViewModel vm;
        public DetailPageView()
        {
            InitializeComponent();
            vm = new DetailPageViewModel(Navigation);
            BindingContext = vm;
            this.Appearing += DetailPageView_Appearing;
        }

        private async void DetailPageView_Appearing(object sender, EventArgs e)
        {
            await vm.OperationCountLosser();
            await vm.OperationCount();
            await vm.SumSp();
        }
    }
}