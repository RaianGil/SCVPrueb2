using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace SCVPrueb2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmPruebaFTP : ContentPage
    {
        string strRoute = Preferences.Get("imgPath", "");
        string[] listPic;
        int intCount = 0;
        public frmPruebaFTP()
        {
            InitializeComponent();
            entPrueba1.Focus();
            loadPic();
            changePic();

        }

        private void entPrueba1_Completed(object sender, EventArgs e)
        {
            
        }
        public void loadLabel()
        {
            lblTitulo.Text = entPrueba1.Text;
            entPrueba1.Focus();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //GetFilesFTP();
            changePic();

        }
        public bool downloadFTP(string strFileName)
        {
            Uri serverUri = new Uri("ftp://ftp.cbbtransfers.com/prueba/" + strFileName);
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous@cbbtransfers.com", "");
            try
            {
                byte[] newFileData = request.DownloadData(serverUri.ToString());
                downloadImg(newFileData);
            }
            catch (WebException e)
            {
                Debug.WriteLine(e.ToString());
            }
            return true;
        }
        public void GetFilesFTP()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://ftp.cbbtransfers.com/prueba/");
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential("anonymous@cbbtransfers.com", "");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
                downloadFTP(line.Trim());
        }
        public void downloadImg(byte[] inImgByte)
        {
            string promoIMGs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PromoIMG");
            
            if (!Directory.Exists(promoIMGs))
                Directory.CreateDirectory(promoIMGs);

            string strFileName = setNamePhoto(promoIMGs, ".jpg");
            string routeImg = Path.Combine(promoIMGs, strFileName);
            var fs = new FileStream(routeImg, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            fs.Write(inImgByte, 0, inImgByte.Length);
        }
        private string setNamePhoto(string inPathIMG, string inExtention) 
        {
            bool boFileExist = false;
            string outFileName = "";
            string strDateNow = DateTime.Now.ToString("MMdd");
            int intLastDigit = 1;
            while (!boFileExist)
            {
                string FileName = strDateNow + intLastDigit.ToString().PadLeft(4, '0') + inExtention;
                string strFileName = inPathIMG + "/" + FileName;
                if (!File.Exists(strFileName))
                {
                    outFileName = FileName;
                    boFileExist = true;
                }
                intLastDigit += 1;
            }
            return outFileName;
        }
        private void loadPic() 
        {
           listPic = Directory.GetFiles(strRoute);
        }
        private async void changePic()
        {
            if (intCount == listPic.Length)
                intCount = 0;
            
            string strRoutePic = listPic[intCount];
            if (File.Exists(strRoutePic))
            {
                await imgPromo.FadeTo(0, 300, Easing.Linear);
                imgPromo.Source = strRoutePic;
                await imgPromo.FadeTo(1, 300, Easing.Linear);
            }

            intCount++;
        }
    }
}