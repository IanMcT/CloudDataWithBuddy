using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace onlineData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string apiKey = "REPLACE_WITH_YOUR_OWN_KEY";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadFromBuddy_Click(object sender, RoutedEventArgs e)
        {
            //This program has no user interaction, it will simply run when the program opens.

            //webClient allows you to make http requests
            System.Net.WebClient webClient = new System.Net.WebClient();

            
            //The base address allows you to create relative uris
            webClient.BaseAddress = "https://parse.buddy.com/parse/classes/keyValue";

            //You need to add this header to be authorized to access the data
            webClient.Headers.Add("X-Parse-Application-Id:REPLACE_WITH_THE_APPLICATION_ID");
            webClient.Headers.Add("X-Parse-REST-API-Key: undefined");
            webClient.Headers.Add("X-Parse-Session-Token: REPLACE_WITH_THE_SESSIONTOKEN");

            

            //The StreamReader class allows you to read from a data stream - in this case the http response.
            System.IO.StreamReader streamReader = new System.IO.StreamReader(webClient.OpenRead("https://parse.buddy.com/parse/classes/keyValue/?where={\"theKey\":\""+txtKey.Text + "\"}"));

            //We will write to a file - this file will be in the same location as the .exe when this is run. Since this project is called BlueAlliance it is found in BlueAlliance\BlueAlliance\bin\Debug
            //System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("teams.txt");
            //Reading and writing files can cause errors - always use a try-catch statement
            try
            {

                MessageBox.Show(streamReader.ReadToEnd());
                //Flush forces that data to be written
                //streamWriter.Flush();
                //Always close when done.
                //streamWriter.Close();
                streamReader.Close();
                MessageBox.Show("All read");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnWriteToBuddy_Click(object sender, RoutedEventArgs e)
        {
            //This program has no user interaction, it will simply run when the program opens.

            //webClient allows you to make http requests
            System.Net.WebClient webClient = new System.Net.WebClient();


            //The base address allows you to create relative uris
            webClient.BaseAddress = "https://parse.buddy.com/parse/classes/keyValue";

            //You need to add this header to be authorized to access the data
            webClient.Headers.Add("X-Parse-Application-Id:REPLACE_WITH_THE_APPLICATION_ID");
            webClient.Headers.Add("X-Parse-REST-API-Key: undefined");
            webClient.Headers.Add("X-Parse-Session-Token: REPLACE_WITH_THE_SESSIONTOKEN");
            webClient.QueryString.Add("theKey", txtKey.Text);
            webClient.QueryString.Add("theValue", txtValue.Text);
            var data = webClient.UploadValues("https://parse.buddy.com/parse/classes/keyValue/?where={\"theKey\":\"robot\"}", "POST", webClient.QueryString);
            string responseString = UnicodeEncoding.UTF8.GetString(data);
            MessageBox.Show(responseString);

            //The StreamReader class allows you to read from a data stream - in this case the http response.
          //  System.IO.StreamReader streamReader = new System.IO.StreamReader(webClient.OpenRead("https://parse.buddy.com/parse/classes/keyValue/?where={\"theKey\":\"robot\"}"));

            //We will write to a file - this file will be in the same location as the .exe when this is run. Since this project is called BlueAlliance it is found in BlueAlliance\BlueAlliance\bin\Debug
            //System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("teams.txt");
            //Reading and writing files can cause errors - always use a try-catch statement
            

        }
    }
}

