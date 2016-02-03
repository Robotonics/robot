using IoTHelpers.Gpio.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace robotapp
{
    public sealed partial class MainPage : Page
    {
        private Sr04UltrasonicDistanceSensor ultrasonic;
        public object dist { get; private set; }

        public MainPage()

        {
            this.InitializeComponent();
            Unloaded += MainPage_Unloaded;
            ultrasonic = new Sr04UltrasonicDistanceSensor(triggerPinNumber: 12, echoPinNumber: 16);
            ultrasonic.DistanceChanged += ultrasonic_DistanceChanged;
            sonar();
           
        }
         private void sonar()
        {
            sonardata.Text = dist.ToString();
        }
        

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)

        {
            

            if (ultrasonic != null)

            {
              ultrasonic.DistanceChanged -= ultrasonic_DistanceChanged;
              ultrasonic.Dispose();                               
            }
        }

        private void ultrasonic_DistanceChanged(object sender, EventArgs e)

        {
            dist = ultrasonic.CurrentDistance;

           
        }

        
    }

}
