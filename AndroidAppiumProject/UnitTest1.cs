using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AndroidAppiumProject
{
  

   public class CSEConnect
    {
        private static AndroidDriver<AppiumWebElement> driver;
        private static AppiumLocalService appiumLocalService;


        public static void Main()
        {
            appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocalService.Start();
            var appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "device");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9.0");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.draeger.connect.cse");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.draeger.connect.cse.MainActivity");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            //new Uri("http://127.0.0.1:4723/wd/hub")
            driver = new AndroidDriver<AppiumWebElement>(appiumLocalService, appiumOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AppiumWebElement approveBox = driver.FindElementByAndroidUIAutomator("new UiSelector().textContains(\"Approve\");");
            approveBox.Click();
            AppiumWebElement background = driver.FindElementByAndroidUIAutomator("new UiSelector().textContains(\"Dräger CSE Mobile\");");
            background.Click();


        }

     /*   public void SwipeTest()
        {
            
            var element = driver.FindElementById("android:id/content");
            Point point = element.Coordinates.LocationInDom;
            Size size = element.Size;
            new TouchAction(driver)
                .Press(point.X + 5, point.Y + 5)
                .Wait(200)
                .MoveTo(point.X + size.Width - 5, point.Y + size.Height - 5)
                .Release()
                .Perform();
        }
        */

        public void TestInitalize()
        {
            driver.LaunchApp();
        }

        public void TestCleanup()
        {
            driver.CloseApp();
        }
    }
}
