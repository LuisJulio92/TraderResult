using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TraderResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class InitialPage : Xamarin.Forms.TabbedPage
    {
        public InitialPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}