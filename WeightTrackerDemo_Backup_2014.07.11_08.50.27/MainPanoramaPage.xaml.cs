using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Phone.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Device.Location;

namespace PersonaHealth
{
    public partial class MainPanoramaPage : PhoneApplicationPage
    {
        public MainPanoramaPage()
        {
            InitializeComponent();
        }

        private static void SetProperty(object instance, string name, object value)
        {
            var setMethod = instance.GetType().GetProperty(name);
            setMethod.SetValue(instance, value, null);
        }
        
        public void mapEvent_Click(object sender, EventArgs e) 
        {
            BingMapsTask bingMapsTask = new BingMapsTask();

            //Omit the Center property to use the user's current location.
            //bingMapsTask.Center = new GeoCoordinate(47.6204, -122.3493);

            bingMapsTask.SearchTerm = "Hospital";
            bingMapsTask.ZoomLevel = 2;

            bingMapsTask.Show();
        }

        public void logsEvent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logs button works!");
            //Do work for your application here.
        }

        public void callEvent_Click(object sender, EventArgs e)
        {
            //Do work for your application here.
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = "911";
            phoneCallTask.DisplayName = "Emergency Call";
            phoneCallTask.Show();
           // MessageBox.Show("Call button works!");
         }

        public void shareEvent_Click(object sender, EventArgs e)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();

            shareStatusTask.Status = " #personahealth";

            shareStatusTask.Show();
        }

        public void exit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Exit button works!");
            //Do work for your application here.
            throw new Exception("Exit");
        }
        
        public void loadFeedButton_Click(object sender, RoutedEventArgs e)
        {
            // WebClient is used instead of HttpWebRequest in this code sample because 
            // the implementation is simpler and easier to use, and we do not need to use 
            // advanced functionality that HttpWebRequest provides, such as the ability to send headers.
            WebClient webClient = new WebClient();

            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);

            // Download the RSS feed. DownloadStringAsync was used instead of OpenStreamAsync because we do not need 
            // to leave a stream open, and we will not need to worry about closing the channel. 
            webClient.DownloadStringAsync(new System.Uri("http://rss.nytimes.com/services/xml/rss/nyt/Health.xml"));
        }

        // Event handler which runs after the feed is fully downloaded.
        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                this.State["feed"] = e.Result;

                UpdateFeedList(e.Result);
            }
        }

        // This method determines whether the user has navigated to the application after the application was tombstoned.
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // First, check whether the feed is already saved in the page state.
            if (this.State.ContainsKey("feed"))
            {
                // Get the feed again only if the application was tombstoned, which means the ListBox will be empty.
                // This is because the OnNavigatedTo method is also called when navigating between pages in your application.
                // You would want to rebind only if your application was tombstoned and page state has been lost. 
                if (feedListBox.Items.Count == 0)
                {
                    UpdateFeedList(State["feed"] as string);
                }
            }
        }

        // This method sets up the feed and binds it to our ListBox. 
        private void UpdateFeedList(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // In Windows Phone OS 7.1, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                // Bind the list of SyndicationItems to our ListBox
                feedListBox.ItemsSource = feed.Items;

                loadFeedButton.Content = "Refresh Feed";
            });

        }

        // The SelectionChanged handler for the feed items 
        private void feedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            if (listBox != null && listBox.SelectedItem != null)
            {
                // Get the SyndicationItem that was tapped.
                SyndicationItem sItem = (SyndicationItem)listBox.SelectedItem;

                // Set up the page navigation only if a link actually exists in the feed item.
                if (sItem.Links.Count > 0)
                {
                    // Get the associated URI of the feed item.
                    Uri uri = sItem.Links.FirstOrDefault().Uri;

                    // Create a new WebBrowserTask Launcher to navigate to the feed item. 
                    // An alternative solution would be to use a WebBrowser control, but WebBrowserTask is simpler to use. 
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    webBrowserTask.Uri = uri;
                    webBrowserTask.Show();
                }
            }
        }

        public void Email_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Appointment";
            emailComposeTask.Body = "Good day Dr.Bucho.";
            emailComposeTask.To = "Dr_Bucho@live.com";
            emailComposeTask.Cc = "";
            emailComposeTask.Bcc = "";
            emailComposeTask.Show();
        }


        public void Appointment_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var type = Type.GetType("Microsoft.Phone.Tasks.SaveAppointmentTask, Microsoft.Phone");
            if (type != null)
            {
                var constructor = type.GetConstructor(new Type[] { });
                var appt = constructor.Invoke(null);
                SetProperty(appt, "Subject", "Important Appointment");
                SetProperty(appt, "StartTime", DateTime.Now.AddHours(4));
                SetProperty(appt, "EndTime", DateTime.Now.AddHours(6));

                type.GetMethod("Show").Invoke(appt, null);
            }
        //SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
        //saveAppointmentTask.StartTime = DateTime.Now.AddHours(2);
        //saveAppointmentTask.EndTime = DateTime.Now.AddHours(3);
        //saveAppointmentTask.Subject = "Appointment subject";
        //saveAppointmentTask.Location = "Appointment location";
        //saveAppointmentTask.Details = "Appointment details";
        //saveAppointmentTask.IsAllDayEvent = false;
        //saveAppointmentTask.Reminder = Reminder.FifteenMinutes;
        //saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;

        //saveAppointmentTask.Show();
         }

        public void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BingMapsTask bingMapsTask = new BingMapsTask();

            //Omit the Center property to use the user's current location.
            //bingMapsTask.Center = new GeoCoordinate(47.6204, -122.3493);

            bingMapsTask.SearchTerm = "Hospital";
            bingMapsTask.ZoomLevel = 5;

            bingMapsTask.Show();
        }

    }
}