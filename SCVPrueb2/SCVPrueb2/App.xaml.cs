using System;
using Xamarin.Forms;
using SCVPrueb2.View;
using System.IO;
using Xamarin.Essentials;

namespace SCVPrueb2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new frmPruebaFTP());
        }

        protected override void OnStart()
        {
            string strPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PromoIMG");
            Preferences.Set("imgPath", strPath);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
