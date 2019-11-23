using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Research_App
{
    public class QuoteModel
    {
        //This is what we want to extract from the JSON code
        //The vairables must be exactly the same name as the properties in the JSON code
        public string companyname;

        public string price;

        public string description;

        public string image;

        public string website;
    }
}
