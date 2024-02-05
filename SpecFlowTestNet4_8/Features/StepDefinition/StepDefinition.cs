using NUnit.Framework;
using OpenQA.Selenium;
using SalesbookTest.ActionHandlers;
using SalesbookTest.Drivers;
using SalesbookTest.Pages.HomePage;
using SalesbookTest.Pages.HomePage.Forms;
using SalesbookTest.Pages.HomePage.Windows;
using System.Configuration;
using System.Collections.ObjectModel;  // Ensure this namespace is included

namespace SalesbookTest.Features.StepDefinition
{
    [Binding]
    public  class StepDefinition
    {
        protected  static readonly LogInPage salesbookPage = new LogInPage();
        protected  readonly ElementsForSelection selectEntryType = new ElementsForSelection();
       protected readonly BaseWindows baseWindows = new BaseWindows();
        public static ActionHandler handler = new ActionHandler();
        public static int _previousRecordCount;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
                // navigate to Login Page 
                BrcWebdriver.GetInstance().Manage().Window.Maximize();
                BrcWebdriver.GetInstance().Navigate().GoToUrl(ConfigurationManager.AppSettings["loginUrl"]);
                // enter email and pass
                salesbookPage.EmailInput.EnterText("linh.phan@idealogic.com.vn");
                salesbookPage.PasswordInput.EnterText("Welkom01");
                // click Login Button and wait for 2s
                salesbookPage.LoginButton.Click();
                Thread.Sleep(2000);
                // click the first company
                handler.Handle("Clicks", "Open", "Button", " ", "companySelection");

                Thread.Sleep(5000);
            // click Salesbook icon
            handler.Handle("Clicks", "Sales Book", "Button", " ", "navButton-1336");
            Thread.Sleep(5000);
            
        }
        //[Given(@"The user is in ""([^""]*)"" window")]
        //private void GivenUserIsInSalesbookScreen()
        //{
        //    //bool CheckIcon = homePage.SalesbookButtonInSalesbookScreen.Display();
        /// <summary>
        /// ///
        /// </summary>
        //}
        //[BeforeScenario]
        //public static void BeforeScenario()
        //{
        //    var webDriver = BrcWebdriver.GetInstance();

        //    // Navigate to the specific URL
        //    BrcWebdriver.GetInstance().Navigate().GoToUrl(ConfigurationManager.AppSettings["salesInvoicingPage"]);


        //}
        [Given(@"The user is in ""([^""]*)"" window")]
        public void GivenTheUserIsInWindows(string salesInvoicing)
        {
            var tableRows = BrcWebdriver.GetInstance().FindElements(By.XPath("(//div[starts-with(@id, 'gridpanel')]//div[starts-with(@id,'gridview')]//table[starts-with(@class, 'x-grid-table')])[1]//tr[contains(@class, 'x-grid-row')]"));
            _previousRecordCount = tableRows.Count;
            if (BrcWebdriver.GetInstance().Url == "https://brc-uat.azurewebsites.net/SalesInvoicing.aspx")
            {
               
                BrcWebdriver.GetInstance().Navigate().GoToUrl(ConfigurationManager.AppSettings["salesInvoicingPage"]);
                Thread.Sleep(2000);
                
            }
        }

        [When(@"The user ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" in ""([^""]*)"" window")]
        private void WhenTheUserInWindow(string clicks, string element, string button, string salesInvoicing)
        {
            handler.Handle("", "x-grid-table", "DataGrid","", salesInvoicing);
            handler.Handle(clicks,  element, button, "",salesInvoicing);


        }

        [When(@"The user selects ""(.*)""")]
        private void WhenTheUserSelects(string option)
        {
            switch (option)
            {
                case "Sales Entries":
                    selectEntryType.SalesbookEntriesRadio.Click();
                    selectEntryType.OkbuttonInSelectEntryType.Click();
                    Thread.Sleep(1000);

                    break;
                case "Sales Invoices":
                    selectEntryType.SalesInvoicesRadio.Click();
                    selectEntryType.OkbuttonInSelectEntryType.Click();
                    Thread.Sleep(1000);
                    break;
                case "a record":

                default:
                           throw new ArgumentException($"Unknown data entry option: {option}");
            }
        }

        [When(@"The user performs the following actions:")]
        private void WhenTheUserPerformsTheFollowingActionsInWindow(Table actions)
        {

            foreach (var row in actions.Rows)
            {
                var action = row["Action"];
                var element = row["Element"];
                var type = row["Type"];
                var detail = row["Detail"];
                var window = row["Window"];
                handler.Handle(action, element, type, detail, window);
            }
           
        }

    


        [Then(@"Verify the following actions:")]
        public void ThenTheUserPerformsTheFollowingVerification( Table table)
        {
            foreach (var row in table.Rows)
            {
                var action = row["Action"];
                var element = row["Element"];
                var detail = row["Detail"];
                var type = row["Type"];
                var window = row["Window"]; 
                handler.Handle(action, element,type,detail, window);
                //strageties pattern 

            }
        }






        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (BrcWebdriver.GetInstance() != null)
            {
                try
                {
                    BrcWebdriver.GetInstance().Quit();
                }
                catch (WebDriverException e)
                {
                    Console.WriteLine("Error during WebDriver cleanup: " + e.Message);
                }
                finally
                {
                    BrcWebdriver.driver = null;
                }
            }
        }
    }
}
