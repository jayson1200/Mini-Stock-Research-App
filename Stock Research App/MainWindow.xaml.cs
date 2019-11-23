using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stock_Research_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Initializes the API client for the whole project
            ApiHelper.InitClient();
        }

        //QuoteModel that we are going to use to store are actual call each time the User actually call the internet
        public QuoteModel myStockQuote;

        // In order use an await the parent method must an async method
        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsrWntTckerSym != null)
            {
                //Uses QuoteProcessor method LoadQuote plugs in the users ticker symbol
                myStockQuote = await QuoteProcessor.LoadQuote(UsrWntTckerSym.Text.ToUpper());

                //Spit out the value to the infoBox textbox
                infoBox.Text = "Company Name: \n"+ myStockQuote.companyname + "\n" + "\n" + "Price: \n" + myStockQuote.price + "\n" + "\n" + "Description: \n" + myStockQuote.description;
            }
            else 
            {
                infoBox.Text = "There is nothing in the box";
            }

            //gets the stockQuote image address 
            //UriKind.Absolute tell the URI constructor that we want the whole url not just an ending
            var uriSource = new Uri(myStockQuote.image, UriKind.Absolute);

            //Creates a new image
            companyImg.Source = new BitmapImage(uriSource);
        }

        private void GoToWebsite_Click(object sender, RoutedEventArgs e)
        {
            //Loads a website
            Process.Start(myStockQuote.website);
        }


    }
}
