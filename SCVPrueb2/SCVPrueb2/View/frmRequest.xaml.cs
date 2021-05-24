using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCVPrueb2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmRequest : ContentPage
    {
        public frmRequest()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}