using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
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
           // appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
           // appiumLocalService.Start();
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

            // driver.FindElementByAndroidUIAutomator("new UiSelector().textContains(\"Approve\");");
            // wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Jobs")));
            // driver.FindElementByAndroidUIAutomator("new UiSelector().textContains(\"Approve\")");
            //driver.CloseApp();


        }


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
