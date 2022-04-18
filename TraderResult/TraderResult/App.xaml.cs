using System;
using TraderResult.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TraderResult
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjE0MTEzQDMyMzAyZTMxMmUzMFZGdVZVT0ZkdFFRc3MzcUFsK0NEQU9DUFk4NFlWZlN0bkpGcFo2YWdTLzQ9");
            DevExpress.XamarinForms.DataGrid.Initializer.Init();
            InitializeComponent();
            MainPage = new InitialPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
