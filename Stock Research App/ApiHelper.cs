using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Research_App
{
    public static class ApiHelper
    {
        //Open a Tcp/Ip port to the internet
        //Should be instantiated once per application
        public static HttpClient apiClient;

        public static void InitClient()
        {
            //Assignment of the HttpClient 
            apiClient = new HttpClient();

            //In my testing you dont actually need this
            //But header give information about the website
            //Just put it anyway
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
