using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Research_App
{
    public class QuoteProcessor
    {
        //Async Task that returns a QuoteModel 
        public static async Task<QuoteModel> LoadQuote(string usrWntTxt)
        {
            string url = "";

            //Url maker
            url = "https://financialmodelingprep.com/api/v3/company/profile/" + usrWntTxt;

            //using statement are used to execute code that you want to immediately dispose of from memory after ran

            //HttpResponseMessage can hold the response from the api call
            //GetAsync() sends the get request to the api to recieve info 
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                //response.IsSuccessStatusCode finds out if the Http call was succesful
                if (response.IsSuccessStatusCode) 
                {
                    //Use a parent ProfileQuoteModel which will allow us to assign the response content
                    //We await the aysnc method Read as Async which takes the JSON from the api call, parses it and puts into the fields of the ProfileQuoteModel Object
                    ProfileQuoteModel stockQuote = await response.Content.ReadAsAsync<ProfileQuoteModel>();

                    //We then take the field in ProfileQuoteModel and return only the field
                    return stockQuote.profile;
                }
                //runs this if response.IsSuccessStatusCode is false
                else
                {
                    //Put cursor on ReasonPhrase for info
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
