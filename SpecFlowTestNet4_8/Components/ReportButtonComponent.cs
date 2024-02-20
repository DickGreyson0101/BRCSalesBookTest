using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SalesbookTest.Contracts;
using SalesbookTest.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesbookTest.Components
{
    public class ReportButtonComponent : IBaseComponent
    {
        private readonly By _locator;
        private IWebElement _parent;
        Actions action = new Actions(BrcWebdriver.GetInstance());

        public ReportButtonComponent(By locator)
        {
            _locator = locator;
        }

        public ReportButtonComponent( string buttonName, string detail)
        {
            if (detail == "upper button")
            {
                _locator = By.XPath($"//*[text()='{buttonName}'][1]");
            }
            if (detail == "lower button")
            {
                _locator = By.XPath($"//*[text()='{buttonName}'][2]");
            }
            if (detail == "in report list")
            {
                _locator = By.XPath($"(//*[text()='{buttonName}'])[2]");

            }
        }


        public void Click()
        {
            GetInstance().Click();
        }
        //public void EnterText(string text)
        //{

        //    GetInstance().SendKeys(text);
        //}
        public void DoubleClick()
        {
            action.DoubleClick(BrcWebdriver.GetInstance().FindElement(_locator)).Build().Perform();
        }
        public bool Display()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator).Displayed;
        }

        public IWebElement GetInstance()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator);
        }
        public IWebElement GetElement()
        {
            return GetInstance().FindElement(_locator);
        }

    }
}
