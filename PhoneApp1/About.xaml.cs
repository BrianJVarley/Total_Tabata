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
using System.IO;

namespace TotalTabata
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        

        private void liveTileBtn_Click(object sender, RoutedEventArgs e)
        {
            //generate some random data and put it in the app tile
            Random random = new Random();

            ShellTile tile = ShellTile.ActiveTiles.First();
            if (tile != null)
            {
                //update information here.
                //create some tile data
                StandardTileData tileData = new StandardTileData();
                tileData.Title = "Total Tabata HIT Training";
                tileData.BackBackgroundImage = new Uri("Images/timer_icon_medium.jpg", UriKind.Relative);
                tileData.Count = random.Next(99);
                //set background data to get the tile to flip
                tileData.BackTitle = "Total Tabata";
                tileData.BackgroundImage = new Uri("Images/blue_flip_icon_medium.jpg", UriKind.Relative);
                tileData.BackContent = "Add a new workout";

                //update tile data
                tile.Update(tileData);

            }

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            //using (StreamReader reader = File.OpenText(@"Resources/totalTabataInfo.txt"))

            //    aboutTxtBlk.Text = reader.ReadLine();

        }

        
    }
}