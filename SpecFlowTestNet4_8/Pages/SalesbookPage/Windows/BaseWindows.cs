using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SalesbookTest.Components;
using SalesbookTest.Drivers;
using SalesbookTest.Pages.HomePage.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SalesbookTest.Pages.HomePage.Windows
{
    public  class BaseWindows
    {

        public By FindElementByXPath(string windowName, string elementName)
        {
            string xPath = $"(//div[starts-with(@id,'{windowName}')]//*[text()='{elementName}']/ancestor::td/following-sibling::td//input)[1]";
            return By.XPath(xPath);

        }

        public By FindElementByXPath2(string windowName, string elementName)
        {
            string xPath = $"(//div[starts-with(@id,'{windowName}')]//*[text()='{elementName}']/ancestor::td/following-sibling::td//input)[1]";
            return By.XPath(xPath);

        }


        //public class WindowFactory
        //{
        //    public BaseWindows GetPageObjectByWindowName(string windowName)
        //    {
        //        switch (windowName)
        //        {
        //            case "Add a Sales Book Entry":
        //                return new AddASalesBookEntry();
        //            case "Add a Sales Invoice":
        //                return new AddASalesInvoice();
        //            default:
        //                throw new ArgumentException($"Window name {windowName} not recognized.");
        //        }
        //    }
        //}

    }
}
