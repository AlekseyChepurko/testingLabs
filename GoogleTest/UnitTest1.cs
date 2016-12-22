using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace GoogleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WrongCreditionals()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://www.facebook.com/login.php");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("email")).SendKeys("ssssssss");
                wdriver.FindElement(By.Id("pass")).SendKeys("1234");
                wdriver.FindElement(By.Id("loginbutton")).Click();


                Assert.AreNotEqual(wdriver.Url, "https://www.facebook.com/");

                wdriver.Quit();
            }
        }

        [TestMethod]
        public void RightCreditionals()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://www.facebook.com/login.php");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("email")).SendKeys("iviet@list.ru");
                wdriver.FindElement(By.Id("pass")).SendKeys("cP8ne2ba");
                wdriver.FindElement(By.Id("loginbutton")).Click();


                Assert.AreEqual(wdriver.Url, "https://www.facebook.com/");

                wdriver.Quit();
            }
        }
        //[TestMethod]
        //public void messageSent()
        //{

        //    using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
        //    {
        //        wdriver.Navigate().GoToUrl("https://www.facebook.com/login.php");
        //        wdriver.Manage().Window.Maximize();
        //        wdriver.FindElement(By.Id("email")).SendKeys("iviet@list.ru");
        //        wdriver.FindElement(By.Id("pass")).SendKeys("cP8ne2ba");
        //        wdriver.FindElement(By.Id("loginbutton")).Click();


        //        if (wdriver.Url == "https://www.facebook.com/")
        //        {
        //            wdriver.FindElement(By.CssSelector("div[data-click='profile_icon']")).Click();

        //            IJavaScriptExecutor js = wdriver as IJavaScriptExecutor;
        //            //js.ExecuteScript("document.querySelector([data-testid='status-attachment-mentions-input']);");
        //            wdriver.FindElement(By.ClassName("_4h98")).Click();
        //            System.Threading.Thread.Sleep(1000);
        //            //js.ExecuteScript("document.getElementsByTagName('br')[0].innerHTML= 'heeelooo';");

        //            //System.Threading.Thread.Sleep(5000);
        //            //wdriver.FindElement(By.CssSelector("div[data-testid='status-attachment-mentions-input']")).SendKeys("Привет");
        //            System.Threading.Thread.Sleep(5000);
        //        }

        //        Assert.AreEqual(wdriver.Url, "https://www.facebook.com/");

        //        wdriver.Quit();
        //    }
        //}

        [TestMethod]
        public void logOut()
        {

            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://www.facebook.com/login.php");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("email")).SendKeys("iviet@list.ru");
                wdriver.FindElement(By.Id("pass")).SendKeys("cP8ne2ba");
                wdriver.FindElement(By.Id("loginbutton")).Click();

                string titleText = "";

                if (wdriver.Url == "https://www.facebook.com/")
                {
                    wdriver.FindElement(By.Id("userNavigationLabel")).Click();
                    System.Threading.Thread.Sleep(1000);
                    wdriver.FindElement(By.CssSelector("a[data-gt*='menu_logout']")).Click();
                    System.Threading.Thread.Sleep(1000);
                    
                }

                titleText = wdriver.FindElements(By.CssSelector("._z36._3nma._3ma"))[0].Text;
                Assert.AreEqual("Недавние входы", titleText);
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void selfSearch()
        {

            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://www.facebook.com/login.php");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("email")).SendKeys("iviet@list.ru");
                wdriver.FindElement(By.Id("pass")).SendKeys("cP8ne2ba");
                wdriver.FindElement(By.Id("loginbutton")).Click();

                string givenText = "";
                string searchTarget = "Алексей Чепурко";

                if (wdriver.Url == "https://www.facebook.com/")
                {
                    System.Threading.Thread.Sleep(3000);
                    wdriver.FindElement(By.Id("q")).SendKeys(searchTarget);
                    wdriver.FindElement(By.ClassName("reDesignedBtn")).Click();
                    System.Threading.Thread.Sleep(1000);
                    wdriver.FindElement(By.CssSelector("a[class='_2ial _8o _8s lfloat _ohe']")).Click();
                    System.Threading.Thread.Sleep(1000);
                    givenText = wdriver.FindElement(By.Id("fb-timeline-cover-name")).Text;
                }

                Assert.AreEqual(searchTarget, givenText);
                wdriver.Quit();
            }
        }

    }
}
