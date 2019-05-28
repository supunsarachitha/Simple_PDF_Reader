using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Simple_PDF_Reader
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public string currrentUrl;
        public MainPage()
        {
            InitializeComponent();
            try
            {
                var current = Connectivity.NetworkAccess;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (current == NetworkAccess.Internet)
                    {
                        Browser.Source = "https://drive.google.com/viewerng/viewer?embedded=true&url="+"http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf";

                    }
                    else
                    {
                        bool result = await DisplayAlert("", "No Internet Connction. Please Try Again", "Ok", "Cancel");
                        if (result == true || result == false)
                        {
                            if (Device.OS == TargetPlatform.Android)
                            {
                                System.Environment.Exit(0);
                            }
                            else if (Device.OS == TargetPlatform.iOS)
                            {
                                Thread.CurrentThread.Abort();
                            }
                        }
                    }
                });
            }
            catch (Exception)
            {

                return;
            }


        }

        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            currrentUrl = e.Url;
            AGrid.IsVisible = true;
            Browser.IsVisible = false;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {


            AGrid.IsVisible = false;
            Browser.IsVisible = true;
        }

        protected override bool OnBackButtonPressed()
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool result = await DisplayAlert("", "Do you want to exit?", "Ok", "Cancel");
                if (result == true)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        System.Environment.Exit(0);

                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        Thread.CurrentThread.Abort();
                    }
                }
            });

            return true;
        }


        private void Exit_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool result = await DisplayAlert("", "Do you want to exit?", "Ok", "Cancel");
                if (result == true)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        System.Environment.Exit(0);

                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        Thread.CurrentThread.Abort();
                    }
                }
            });
        }

        private void Browser_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}
