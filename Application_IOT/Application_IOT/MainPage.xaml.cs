using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Application_IOT
{
    

    public partial class MainPage : ContentPage
    {
        static readonly HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        static async Task HttpGet(string target)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://iot-bram.000webhostapp.com/Request.php?api_key=admin" +
                    "&action=UPDATE&TARGET="+ target +"&VALUE=1");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch
            {
                Console.WriteLine("\nException!");
            }
        }


        private void BramaClicked(object sender, EventArgs e)
        {
            HttpGet("BRAMA");
        }   

        private void Light1licked(object sender, EventArgs e)
        {
            HttpGet("Swiatlo1");
        }

        private void Light2Clicked(object sender, EventArgs e)
        {
            HttpGet("Swiatlo2");
        }

        private void Light3Clicked(object sender, EventArgs e)
        {
            HttpGet("Swiatlo3");
        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            (sender as Button).BackgroundColor = Color.LightGreen;
        }

        private void ButtonReleased(object sender, EventArgs e)
        {
            (sender as Button).BackgroundColor = Color.Red;
        }
    }
}
