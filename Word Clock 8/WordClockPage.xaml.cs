/**************************************************************************
 * Word Clock 8 - Metro Style for Windows 8
 * Code by sascha.corti@microsoft.com 
 * Bugs after this line.
 * 
 *  \__/      \__/       \__/       \__/       \__/       \__/       \__/
 *  (oo)      (o-)       (@@)       (xx)       (--)       (  )       (OO)
 * //||\\    //||\\     //||\\     //||\\     //||\\     //||\\     //||\\
 *  bug       bug        bug/w      dead       bug       blind     bug after
 *          winking    hangover     bug      sleeping     bug      seeing a
 *                                                                  female
 *                                                                   bug
 *                                                                   
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Word_Clock_8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WordClockPage : Page
    {

        Color colAccent = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
        Color colPageBackground = ((SolidColorBrush)Application.Current.Resources["ApplicationPageBackgroundBrush"]).Color;
        Color colTextActive = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        Color colTextInactive= Color.FromArgb(0xFF, 0x66, 0x66, 0x66);

        DispatcherTimer timer = new DispatcherTimer();

        public WordClockPage()
        {
            this.InitializeComponent();

            // Initialize Timer
            timer.Stop();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 15);

            // Set up event handlers
            anim_fadein.Completed += anim_fadein_Completed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            anim_fadein.Begin();
        }

        void anim_fadein_Completed(object sender, object e)
        {
            // Start the Timer.
            timer.Start();

            // Trigger first Tick.
            this.timer_Tick(this, null);
        }

        void timer_Tick(object sender, object e)
        {
            // Get time.
            int iHour = DateTime.Now.Hour;
            int iMin = DateTime.Now.Minute;

            // Display "IT IS"
            Anim_itis(1);

            // Display hour.
            string[] sHour = { "", "" };

            if (((iHour == 0 || iHour == 12) && iMin > 34) || ((iHour == 1 || iHour == 13) && iMin <= 34))
                sHour = new string[] { "twelve", "one" };

            else if (((iHour == 1 || iHour == 13) && iMin > 34) || ((iHour == 2 || iHour == 14) && iMin <= 34))
                sHour = new string[] { "one", "two" };

            else if (((iHour == 2 || iHour == 14) && iMin > 34) || ((iHour == 3 || iHour == 15) && iMin <= 34))
                sHour = new string[] { "two", "three" };

            else if (((iHour == 3 || iHour == 15) && iMin > 34) || ((iHour == 4 || iHour == 16) && iMin <= 34))
                sHour = new string[] { "three", "four" };

            else if (((iHour == 4 || iHour == 16) && iMin > 34) || ((iHour == 5 || iHour == 17) && iMin <= 34))
                sHour = new string[] { "four", "five" };

            else if (((iHour == 5 || iHour == 17) && iMin > 34) || ((iHour == 6 || iHour == 18) && iMin <= 34))
                sHour = new string[] { "five", "six" };

            else if (((iHour == 6 || iHour == 18) && iMin > 34) || ((iHour == 7 || iHour == 19) && iMin <= 34))
                sHour = new string[] { "six", "seven" };

            else if (((iHour == 7 || iHour == 19) && iMin > 34) || ((iHour == 8 || iHour == 20) && iMin <= 34))
                sHour = new string[] { "seven", "eight" };

            else if (((iHour == 8 || iHour == 20) && iMin > 34) || ((iHour == 9 || iHour == 21) && iMin <= 34))
                sHour = new string[] { "eight", "nine" };

            else if (((iHour == 9 || iHour == 21) && iMin > 34) || ((iHour == 10 || iHour == 22) && iMin <= 34))
                sHour = new string[] { "nine", "ten" };

            else if (((iHour == 10 || iHour == 22) && iMin > 34) || ((iHour == 11 || iHour == 23) && iMin <= 34))
                sHour = new string[] { "ten", "eleven" };

            else if (((iHour == 11 || iHour == 23) && iMin > 34) || ((iHour == 0 || iHour == 12) && iMin <= 34))
                sHour = new string[] { "eleven", "twelve" };

            Anim_hour(sHour[0], 0);
            Anim_hour(sHour[1], 1);

            // Display minutes.
            if (iMin >= 00 && iMin <= 04)
            {
                Fiveto(0);
                // Would show zero.
            }
            else if (iMin >= 05 && iMin <= 09)
            {
                // Would hide zero.
                Fivepast(1);
            }
            else if (iMin >= 10 && iMin <= 14)
            {
                Fivepast(0);
                Tenpast(1);
            }
            else if (iMin >= 15 && iMin <= 19)
            {
                Tenpast(0);
                Quarterpast(1);
            }
            else if (iMin >= 20 && iMin <= 24)
            {
                Quarterpast(0);
                Twentypast(1);
            }
            else if (iMin >= 25 && iMin <= 29)
            {
                Twentypast(0);
                Twentyfivepast(1);
            }
            else if (iMin >= 30 && iMin <= 34)
            {
                Twentyfivepast(0);
                Halfpast(1);
            }
            else if (iMin >= 35 && iMin <= 39)
            {
                Halfpast(0);
                Twentyfiveto(1);
            }
            else if (iMin >= 40 && iMin <= 44)
            {
                Twentyfiveto(0);
                Twentyto(1);
            }
            else if (iMin >= 45 && iMin <= 49)
            {
                Twentyto(0);
                Quarterto(1);
            }
            else if (iMin >= 50 && iMin <= 54)
            {
                Quarterto(0);
                Tento(1);
            }
            else if (iMin >= 55 && iMin <= 59)
            {
                Tento(0);
                Fiveto(1);
            }

            // Display "O'CLOCK"
            Anim_oclock(1);

            // Display Dots.
            if (iMin == 0 || iMin == 5 || iMin == 10 || iMin == 15 || iMin == 20 || iMin == 25 || iMin == 30 || iMin == 35 || iMin == 40 || iMin == 45 || iMin == 50 || iMin == 55)
            {
                Anim_dot(1, 0);
                Anim_dot(2, 0);
                Anim_dot(3, 0);
                Anim_dot(4, 0);
            }

            if (iMin == 1 || iMin == 6 || iMin == 11 || iMin == 16 || iMin == 21 || iMin == 26 || iMin == 31 || iMin == 36 || iMin == 41 || iMin == 46 || iMin == 51 || iMin == 56)
            {
                Anim_dot(1, 1);
            }

            if (iMin == 2 || iMin == 7 || iMin == 12 || iMin == 17 || iMin == 22 || iMin == 27 || iMin == 32 || iMin == 37 || iMin == 42 || iMin == 47 || iMin == 52 || iMin == 57)
            {
                Anim_dot(1, 1);
                Anim_dot(2, 1);
            }

            if (iMin == 3 || iMin == 8 || iMin == 13 || iMin == 18 || iMin == 23 || iMin == 28 || iMin == 33 || iMin == 38 || iMin == 43 || iMin == 48 || iMin == 53 || iMin == 58)
            {
                Anim_dot(1, 1);
                Anim_dot(2, 1);
                Anim_dot(3, 1);
            }

            if (iMin == 4 || iMin == 9 || iMin == 14 || iMin == 19 || iMin == 24 || iMin == 29 || iMin == 34 || iMin == 39 || iMin == 44 || iMin == 49 || iMin == 54 || iMin == 59)
            {
                Anim_dot(1, 1);
                Anim_dot(2, 1);
                Anim_dot(3, 1);
                Anim_dot(4, 1);
            }
        }



        void Anim_itis(int state)
        {
            for (int i = 1; i <= 4; i++)
                Letter_Animate("itis_" + i, state);
        }

        void Anim_hour(string hour, int state)
        {
            for (int i = 1; i <= hour.Length; i++)
            {
                Letter_Animate("hour_" + hour + "_" + i, state);
            }
        }

        void Anim_minute(string minute, int state)
        {
            for (int i = 1; i <= minute.Length; i++)
            {
                Letter_Animate("min_" + minute + "_" + i, state);
            }
        }

        void Anim_oclock(int state)
        {
            for (int i = 1; i <= 6; i++)
            {
                Letter_Animate("oclock_" + i, state);
            }
        }

        void Anim_dot(int number, int state)
        {
            Letter_Animate("dot_" + number, state);
        }



        void Fivepast(int status)
        {
            Anim_minute("five", status);
            Anim_minute("past", status);
        }

        void Tenpast(int status)
        {
            Anim_minute("ten", status);
            Anim_minute("past", status);
        }

        void Quarterpast(int status)
        {
            Anim_minute("a", status);
            Anim_minute("quarter", status);
            Anim_minute("past", status);
        }

        void Twentypast(int status)
        {
            Anim_minute("twenty", status);
            Anim_minute("past", status);
        }

        void Twentyfivepast(int status)
        {
            Anim_minute("twenty", status);
            Anim_minute("five", status);
            Anim_minute("past", status);
        }

        void Halfpast(int status)
        {
            Anim_minute("half", status);
            Anim_minute("past", status);
        }

        void Twentyfiveto(int status)
        {
            Anim_minute("twenty", status);
            Anim_minute("five", status);
            Anim_minute("to", status);
        }

        void Twentyto(int status)
        {
            Anim_minute("twenty", status);
            Anim_minute("to", status);
        }

        void Quarterto(int status)
        {
            Anim_minute("a", status);
            Anim_minute("quarter", status);
            Anim_minute("to", status);
        }

        void Tento(int status)
        {
            Anim_minute("ten", status);
            Anim_minute("to", status);
        }

        void Fiveto(int status)
        {
            Anim_minute("five", status);
            Anim_minute("to", status);
        }




        public void Letter_Animate(string controlName, int state)
        {
            Button targetButton = (Button)this.FindName(controlName);

            Color colText = colTextInactive;
            if (state == 1)
                colText = colTextActive;

            Color colBackground = colPageBackground;
            if (state == 1)
                colBackground = colAccent;



            LinearColorKeyFrame keyFrameCol = new LinearColorKeyFrame();
            keyFrameCol.Value = colText;
            keyFrameCol.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 2, 0));

            ColorAnimationUsingKeyFrames animColor = new ColorAnimationUsingKeyFrames();
            animColor.KeyFrames.Add(keyFrameCol); // 1 second

            Storyboard.SetTargetProperty(animColor, "(TextElement.Foreground).(SolidColorBrush.Color)");
            Storyboard.SetTarget(animColor, targetButton);



            LinearColorKeyFrame keyFrameColBG = new LinearColorKeyFrame();
            keyFrameColBG.Value = colBackground;
            keyFrameColBG.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 2, 0));

            ColorAnimationUsingKeyFrames animColorBG = new ColorAnimationUsingKeyFrames();
            animColorBG.KeyFrames.Add(keyFrameColBG); // 1 second

            Storyboard.SetTargetProperty(animColorBG, "(Control.Background).(SolidColorBrush.Color)");
            Storyboard.SetTarget(animColorBG, targetButton);



            Storyboard story = new Storyboard();
            story.Children.Add(animColor);
            story.Children.Add(animColorBG);

            story.Begin();
        }
    }
}
