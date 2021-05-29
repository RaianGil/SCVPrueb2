using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCVPrueb2.View
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();            
        }

        private void btnAddstudent_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmAddStudent());
        }

        private void btnConsulta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new frmRequest());
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
