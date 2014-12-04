using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace TotalTabata
{
    public partial class ExerciseList : PhoneApplicationPage
    {

        const string constDefaultInterval = "00 : 00 : 00 : 000";

        

       

        public ExerciseList()
        {

            InitializeComponent();
           
           
          
        }

        
        

        private void appBarAddBtn_Click(object sender, EventArgs e)
        {

            if (roundsTbx.Text.Length == 0)
            {
                MessageBox.Show("Please enter number of rounds..");
                roundsTbx.Focus();
                return;
            }
            else
            {
                string url = "/MainPage.xaml" +
                "?workTimeSpanPkr=" + System.Net.WebUtility.UrlEncode(workTimeSpanPkr.ValueString) +
                "&restTimeSpanPkr=" + System.Net.WebUtility.UrlEncode(restTimeSpanPkr.ValueString) +
                "&roundsTbx=" + System.Net.WebUtility.UrlEncode(roundsTbx.Text);

                NavigationService.Navigate(new Uri(url, UriKind.Relative));


            }
            
                

        
            
        }

       

        private void appBarAboutBtn_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        
    }
}