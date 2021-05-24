using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SCVPrueb2.View;

namespace SCVPrueb2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new frmAddStudent();
 
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
