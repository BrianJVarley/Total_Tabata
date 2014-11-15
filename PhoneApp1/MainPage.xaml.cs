using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TotalTabata.Resources;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Threading;
using Microsoft.Phone.Controls.Primitives;
using System.Globalization;

namespace TotalTabata
{
    public partial class MainPage : PhoneApplicationPage
    {
        Stopwatch myStopwatch = new Stopwatch();
        DispatcherTimer myTimer;

        TimeSpan workTm;
        TimeSpan restTm;

        const string constDefaultInterval = "00 : 00 : 00 : 000";
        string wrkString;
        string rstString;


        long hh, mm, ss, ms;
        string roundMax;

        //counter variable
        int i = 0;
        ////max rounds constant
        

        
        

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            

            if (NavigationContext.QueryString.ContainsKey("workTimeSpanPkr"))
            {
                wrkString = NavigationContext.QueryString["workTimeSpanPkr"];
                //Assign text box string value to a test time span variable.
                workTm = TimeSpan.ParseExact(wrkString, @"hh\:mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None);
                
            }

            if (NavigationContext.QueryString.ContainsKey("restTimeSpanPkr"))
            {
                rstString = NavigationContext.QueryString["restTimeSpanPkr"];
                //Assign text box string value to a test time span variable.
                restTm = TimeSpan.ParseExact(rstString, @"hh\:mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None);

            }


            if (NavigationContext.QueryString.ContainsKey("roundsTbx"))
            {
                //Assign text box string value to a roundMaxFlag variable.
                roundMax = NavigationContext.QueryString["roundsTbx"];
                
            }

            
            


        }


        
      
        
        void myTimer_Tick(object sender, EventArgs e)
        {

         
                // update the textblock on the display
                // with hh, mm, ss, ms
                ms = myStopwatch.ElapsedMilliseconds;

                ss = ms / 1000;
                ms = ms % 1000;

                mm = ss / 60;
                ss = ss % 60;

                hh = mm / 60;
                mm = mm % 60;


                tblDisplay.Text = hh.ToString("00") + " : " +
                                  mm.ToString("00") + " : " +
                                  ss.ToString("00") + " : " +
                                  ms.ToString("000");



                //method to trigger timer stop and start at user input intervals
                intervalTrigger(ref workTm, ref restTm);

                
          
            
           
        }

        //interval method to signal interval changes.
        private void intervalTrigger(ref TimeSpan workTm, ref TimeSpan restTm)
        {



            //convert double string value from slider to an int for processing
            int roundMaxFlag = Convert.ToInt32(Math.Round(Convert.ToDouble(roundMax)));

         

            if (myStopwatch.Elapsed >= workTm)
            {


                //set background color to red to signify rest period
                StopGoCvs.Background = new SolidColorBrush(Colors.Red);


                //stop timer to signafy end of rest interval.
                if (myStopwatch.Elapsed >= restTm + workTm)
                {
                    ////increment counter
                    i++;
                    myStopwatch.Reset();
                    myTimer.Stop();
                    //set background to green to signify end of rest period
                    StopGoCvs.Background = new SolidColorBrush(Colors.Green);
                    tblDisplay.Text = constDefaultInterval;
                    

                }



                //if number of iterations is less than the max, 
                //start the timer and continue the looping
                if (i <= roundMaxFlag)
                {

                
                    myStopwatch.Start();
                    myTimer.Start();      

                }
                //if number of iterations reaches limit,reset/stop
                else
                {
                    myStopwatch.Reset();
                    myTimer.Stop();

                }

            }
                      
            
        }


       
        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void stopBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            try
            {

                StopGoCvs.Background = new SolidColorBrush(Colors.Red);

                //stopSoundElmt.Play();


                myTimer.Stop();
                myStopwatch.Reset();
                tblDisplay.Text = constDefaultInterval;


            }
            catch (NullReferenceException)
            {
                return;

            }
               
           
        
        }

        private void StartTimerForMe()
        {
            
        }

        private async void startBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
            //delay stop watch start to allow time to get ready.
            TimeSpan time = TimeSpan.FromSeconds(1);
            await System.Threading.Tasks.Task.Delay(time);


            StopGoCvs.Background = new SolidColorBrush(Colors.Green);
            //startSoundElmt.Play();


            // set up the timer
            myTimer = new DispatcherTimer();
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            myTimer.Tick += myTimer_Tick;

            // start both timers
            myTimer.Start();
            myStopwatch.Start();   
            
        }

        private void roundsTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void addWorkoutBtn_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddWorkout.xaml", UriKind.Relative));
        }




        

       
    }
}