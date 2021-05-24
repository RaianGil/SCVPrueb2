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
    public partial class Request : ContentPage
    {
        public Request()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}