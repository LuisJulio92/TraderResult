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
    public partial class RegisterPageView : ContentPage
    {
        public RegisterPageView()
        {
            InitializeComponent();
            BindingContext = new OperationViewModel(Navigation);
        }

        
    }
}