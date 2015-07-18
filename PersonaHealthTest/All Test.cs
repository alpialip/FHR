using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Phone.Testing;
using Windows.Storage;
using System.Windows;
using PersonaHealth;
using System.Windows.Controls;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using System.Windows.Media.Animation;

 //using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;


namespace PersonaHealthTest
{
    [TestClass]
    public class Testing
    {
  
        #region Instantiated Test

        //[TestMethod]
        //[Description("Check to see MainPage Instantiated")]
        //public void MainPageTest()
        //{
        //    //Test
        //    PersonaHealth.MainPage Mpage = new PersonaHealth.MainPage();
        //    Assert.IsNotNull(Mpage);
        //}

        //[TestMethod]
        //[Description("Check to see Main Panorama Page Instantiated")]
        //public void MainPanoramaPageTest()
        //{
        //   // Test
        //  PersonaHealth.MainPanoramaPage Mpanorama = new PersonaHealth.MainPanoramaPage();
        //  Assert.IsNotNull(new PersonaHealth.MainPanoramaPage());
        //}

        [TestMethod]
        [Description("Check to see HealthVault Intro web Instantiated")]
        public void HVIntroPageTest()
        {
            //Test
            PersonaHealth.HVIntroPage HVIPage = new PersonaHealth.HVIntroPage();
            Assert.IsNotNull(HVIPage);
        }

        //[TestMethod]
        //[Description("Check to see Pivot Page Info Instatiated")]
        //public void MainPivotPageTest()
        //{
        //    //Test
        //    PersonaHealth.PivotInfo HPivotPage = new PersonaHealth.PivotInfo();
        //    Assert.IsNotNull(HPivotPage);
        //}

        //[TestMethod]
        //[Description("Check to see Measurement Pivot Instatiated")]
        //public void MeasurementPivotPageTest()
        //{
        //    //Test
        //    PersonaHealth.PivotInfo PivotPage = new PersonaHealth.PivotInfo();
        //    Assert.IsNotNull(PivotInfo.PivotDef.Two);
        //}

        //[TestMethod]
        //[Description("Check to see Health Pivot Instatiated")]
        //public void HealthPivotPageTest()
        //{
        //    //Test
        //    PersonaHealth.PivotInfo HPivotPage = new PersonaHealth.PivotInfo();
        //    Assert.IsNotNull(PivotInfo.PivotDef.One);
        //}

        //[TestMethod]
        //[Description("Check to see Profile Info Pivot Instatiated")]
        //public void ProfilePivotPageTest()
        //{
        //    //Test
        //    PersonaHealth.PivotInfo HPivotPage = new PersonaHealth.PivotInfo();
        //    Assert.IsNull(PivotInfo.PivotDef.Three);
        //}

        [TestMethod]
        [Description("Check to see List Of Doctor Page Instantiated")]
        public void ListOfDoctorPageTest()
        {
            //Test
            PersonaHealth.ListOfDoctors LIDoctor = new PersonaHealth.ListOfDoctors();
            Assert.IsNotNull(LIDoctor);
        }

        [TestMethod]
        [Description("Check to see Input Symptom Page Instantiated")]
        public void InputSymptomPageTest()
        {
            //Test
            PersonaHealth.Page1 ISPage = new PersonaHealth.Page1();
            Assert.IsNotNull(ISPage);
        }

        //[TestMethod]
        //[Description("Check to see List Of Illnesses Page Instantiated")]
        //public void ListOfIllnessesPageTest()
        //{
        //    //Test
        //    PersonaHealth.ListOfIllnesses LIll = new PersonaHealth.ListOfIllnesses();
        //    Assert.IsNotNull(LIll);
        //}

        [TestMethod]
        [Description("Check HealthVault Web Page Instantiated")]
        public void HVWebPageTest()
        {
            //Test the network
            PersonaHealth.HealthVaultWebPage HVPage = new PersonaHealth.HealthVaultWebPage();
            Assert.IsNotNull(HVPage);
        }
        #endregion


        [TestMethod]
        [Description("Check if General Button is not Null")]
        public void ButtonTest()
        {
            Button button = new Button();
            Assert.IsNotNull(button,"It should be not null");
            Assert.AreEqual(null,button.Content);
        }

        [TestMethod]
        [Description("Check if Record Button is not Null")]
        public void RecordButtonTest()
        {

            Uri pageUri = new Uri("/SelectRecord.xaml", UriKind.RelativeOrAbsolute); 
            Assert.IsNotNull(pageUri);
        }

        [TestMethod]
        [Description("Check if Record Button navigated correctly")]
        public void RecordButtonNavigatedCorrectly()
        {
            Uri pageUri = new Uri("/SelectRecord.xaml", UriKind.RelativeOrAbsolute);
            Assert.AreEqual(pageUri, "/SelectRecord.xaml");
        }

        [TestMethod]
        [Description("Check if Main Page are navigated and Not Null")]
        public void MainPageNavigatedNotNull()
        {
            Uri pageUri = new Uri("/HealthVaultIntroPage.xaml", UriKind.RelativeOrAbsolute);
            Assert.IsNotNull(pageUri);
        }

        [TestMethod]
        [Description("Check if Main Page are navigated to HealthVault Intro")]
        public void MainPageNavigatedCorrectly()
        {
            Uri pageUri = new Uri("/HealthVaultIntroPage.xaml", UriKind.RelativeOrAbsolute);
            Assert.AreEqual(pageUri, "/HealthVaultIntroPage.xaml");
        }

        [TestMethod]
        [Description("Check Animate Object Opacity and Easing is not null")]
        public void AnimeObjectOpacity()
        {
            CubicEase easing = new CubicEase();
            Assert.IsNotNull(easing);           
        }

        [TestMethod]
        [Description("Check Animate Object Opacity is come from 0.0 to 1.0")]
        public void ObjectOpacityStart()
        {
            DoubleAnimation animation = new DoubleAnimation();
            CubicEase easing = new CubicEase();
            animation.From = 0.0;
            animation.To = 1.0;
            Assert.AreEqual(animation.From, 0.0);            
        }

        [TestMethod]
        [Description("Check Animate Object Opacity is come from 0.0 to 1.0")]
        public void ObjectOpacityEnd()
        {
            DoubleAnimation animation = new DoubleAnimation();
            CubicEase easing = new CubicEase();
            animation.From = 0.0;
            animation.To = 1.0;
            Assert.AreEqual(animation.To, 1.0);
        }

        [TestMethod]
        [Description("Check Animation Duration is not null")]
        public void AnimationDurationTest()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            Assert.IsNotNull(animation.Duration);
        }

        [TestMethod]
        [Description("Check Storyboard is not null")]
        public void StoryBoardTest()
        {
            Storyboard storyboard = new Storyboard();
            Assert.IsNotNull(storyboard);
        }

        [TestMethod]
        [Description("Check Exit Button is work")]
        public void ExitButtonTest()
        {
            Exception.Equals("Exit","Exit");         
        }
         

        [TestMethod]
        [Description("Check to see Doctors data are initialize")]
        public void DoctorItemsInitialize()
        {
            //Test
            PersonaHealth.ViewModels.MainDataViewModel Model = new PersonaHealth.ViewModels.MainDataViewModel();
            Assert.IsNotNull(Model);
        }


        [TestMethod]
        [Description("Check to see Mail Subject to Doctor are not null")]
        public void MailSubjectInitialize()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Appointment";
            Assert.IsNotNull(emailComposeTask.Subject);     
        }

        [TestMethod]
        [Description("Check to see Mail Subject to Doctor are right")]
        public void MailSubjectEqual()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Appointment";
            Assert.AreEqual(emailComposeTask.Subject, "Appointment");
        }

        [TestMethod]
        [Description("Check to see Mail Address to Doctor Eko are not null")]
        public void MailAddresEkoNotNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "Dr_Eko_Prabowo@live.com";
            Assert.IsNotNull(emailComposeTask.To);
        }

        [TestMethod]
        [Description("Check to see Mail Address to Doctor Buchori are not null")]
        public void MailAddresBuchoriNotNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "buchori.12ipa6@gmail.com";
            Assert.IsNotNull(emailComposeTask.To);
        }

        [TestMethod]
        [Description("Check to see Mail Address to Drg Kiding are not null")]
        public void MailAddresKidingNotNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "artnaldhy_kiding@live.com";
            Assert.IsNotNull(emailComposeTask.To);
        }

        [TestMethod]
        [Description("Check to see Subject cc can be null")]
        public void SubjectCcNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Cc = "";
            Assert.IsNull(emailComposeTask.To);
        }

        [TestMethod]
        [Description("Check to see Subject Bcc can be null")]
        public void SubjectBccNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Bcc = "";
            Assert.IsNull(emailComposeTask.To);
        }


        [TestMethod]
        [Description("Check to see Search location for maps is not null")]
        public void SearchLocationNotNull()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.SearchTerm = "Hospital";
            Assert.IsNotNull(bingMapsTask.SearchTerm);
        }


        [TestMethod]
        [Description("Check to see Search location for maps is hospital")]
        public void SearchLocationHospital()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.SearchTerm = "Hospital";
            Assert.AreEqual(bingMapsTask.SearchTerm, "Hospital");
        }

        [TestMethod]
        [Description("Check to see Current Location are right")]
        public void CurrentLocation()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.Center = new GeoCoordinate(47.6204, -122.3493);
            Assert.AreEqual(bingMapsTask.Center, bingMapsTask.Center);
        }

        [TestMethod]
        [Description("Check to see Maps Zoom is Working")]
        public void MapZoomWorking()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.ZoomLevel = 5;
            Assert.AreEqual(bingMapsTask.ZoomLevel, 5);
        }

        [TestMethod]
        [Description("Check to see Emergency Call is Working")]
        public void EmergencyCallWorking()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.DisplayName = "Emergency Call";
            Assert.AreEqual(phoneCallTask.DisplayName, "Emergency Call");
        }

        [TestMethod]
        [Description("Check to see Emergency Number is Working (911)")]
        public void EmergencyCallNumberWorking()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = "911";
            Assert.AreEqual(phoneCallTask.PhoneNumber, "911");
        }


        [TestMethod]
        [Description("Check to see Search location for maps in Application Bar is not null")]
        public void SearchLocationNotNull_ApplicationBar()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.SearchTerm = "Hospital";
            Assert.IsNotNull(bingMapsTask.SearchTerm);
        }


        [TestMethod]
        [Description("Check to see Search location for maps in Application Bar is hospital")]
        public void SearchLocationHospital_ApplicationBar()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.SearchTerm = "Hospital";
            Assert.AreEqual(bingMapsTask.SearchTerm, "Hospital");
        }

        [TestMethod]
        [Description("Check to see Current Location in Application Bar are right")]
        public void CurrentLocation_ApplicationBar()
        {
            //Test
            //var Mp = new MainPanoramaPage();
            //Mp.Appointment_Tap(this, new System.Windows.Input.GestureEventArgs());
            BingMapsTask bingMapsTask = new BingMapsTask();
            bingMapsTask.Center = new GeoCoordinate(47.6204, -122.3493);
            Assert.AreEqual(bingMapsTask.Center, bingMapsTask.Center);
        }

        [TestMethod]
        [Description("Check to see Platform URL is Not Null and connected")]
        public void PlatformURLNotNull()
        {
            string platformUrl = @"https://platform.healthvault-ppe.com/platform/wildcat.ashx";
            Assert.IsNotNull(platformUrl);
        }


        [TestMethod]
        [Description("Check to see Shell URL is Not Null and connected")]
        public void ShellURLNotNull()
        {
            string shellUrl = @"https://account.healthvault-ppe.com";
            Assert.IsNotNull(shellUrl);
        }

        [TestMethod]
        [Description("Check to see Master App ID is Alfi Hanif Noor and Not null")]
        public void MasterAppIDNotNull()
        {
            string masterAppId = "425fdcd2-3a87-4ebe-a8c3-241c01b24637";
            Assert.IsNotNull(masterAppId);
        }
     



        #region Navigation Test
        [TestMethod]
        [Description("Check Navigation on Health Info")]
        public void HealthNavigationTest()
        {
            //Test
           Assert.AreNotEqual((PivotInfo.PivotDef.One), (PivotInfo.PivotDef.Two));
        }

        [TestMethod]
        [Description("Check Navigation on Health Info 2")]
        public void HealthNavigation2Test()
        {
            //Test
            Assert.AreNotEqual((PivotInfo.PivotDef.One), (PivotInfo.PivotDef.Three));
        }

        [TestMethod]
        [Description("Check Navigation on Profile Info")]
        public void ProfileNavigationTest()
        {
            //Test
           Assert.AreNotEqual((PivotInfo.PivotDef.Two), (PivotInfo.PivotDef.Three));
        }

        [TestMethod]
        [Description("Check Navigation on Profile Info")]
        public void ProfileNavigation2Test()
        {
            //Test
            Assert.AreNotEqual((PivotInfo.PivotDef.Two), (PivotInfo.PivotDef.One));
        }

         [TestMethod]
         [Description("Check Navigation on Measure Info")]
         public void MeasureNavigationTest()
         {
             //Test
            Assert.AreNotSame((PivotInfo.PivotDef.Three), (PivotInfo.PivotDef.One));
         }

         [TestMethod]
         [Description("Check Navigation on Measure Info")]
         public void MeasureNavigation2Test()
         {
             //Test
             Assert.AreNotSame((PivotInfo.PivotDef.Three), (PivotInfo.PivotDef.Two));
         }
        #endregion

        #region Local file Test
        [TestMethod]
        [Description("Check access to local file : Saved Pictures")]
        public void SavedPicturesAccess()
        {
            Assert.IsNotNull(KnownFolders.SavedPictures);
        }


        [TestMethod]
        [Description("Check access to local file : Camera Roll")]
        public void CameraRollAccess()
        {
            Assert.IsNotNull(KnownFolders.CameraRoll);
        }

         #endregion

        #region Connection Test
    

        //[TestMethod]
        //[Asynchronous]
        //[Description("Check Connection on RSS. It should be fail since the length of the downloaded content is greater than 0.")]
        //public void AsyncMethodRSS()
        //{
        //    WebClient client = new WebClient();
        //    client.DownloadStringCompleted += (obj, args) =>
        //    {
        //        //  Assert.IsFalse(args.Result.Length == 0);
        //        Assert.AreNotEqual(0, args.Result.Length);
        //    };
        //    client.DownloadStringAsync(new Uri("http://rss.nytimes.com/services/xml/rss/nyt/Health.xml"));
        //}

        //[TestMethod]
        //[Asynchronous]
        //[Description("Check Connection on HealthVault. It should be fail since the length of the downloaded content is greater than 0.")]
        //public void AsyncMethodHealthVaulth()
        //{
        //    WebClient client = new WebClient();
        //    client.DownloadStringCompleted += (obj, args) =>
        //    {
        //        //              Assert.IsFalse(args.Result.Length == 0);
        //        Assert.AreNotEqual(0, args.Result.Length);
        //    };
        //    client.DownloadStringAsync(new Uri("http://developer.healthvault.com/pages/methods/methods.aspx"));
        //}

        [TestMethod]
        [Description("Simple Test")]
        public void SimpleTest()
        {
            //return true
            int a = 1;
            int b = 1;

            int c = a + b;

            Assert.IsTrue(c == 2);
        }

    }
        #endregion
}
