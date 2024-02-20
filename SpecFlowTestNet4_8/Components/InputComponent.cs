using OpenQA.Selenium;
using SalesbookTest.Drivers;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using System;
using SalesbookTest.Contracts;

namespace SalesbookTest.Components
{
    public class InputComponent : IBaseComponent
    {
        private readonly By _locator;
        private IWebElement _parent;
        //private IWebDriver driver;

        private IWebElement webElement;

        public InputComponent(By locator)
        {
            _locator = locator;
            
        }
        public InputComponent(string windowName, string inputElementName)
        {
            _locator = By.XPath($"//div[starts-with(@id,'{windowName}')]//*[text()='{inputElementName}']/ancestor::td/following-sibling::td//input[1]");
            //_locator = By.XPath($"(.//*[text()='{inputElementName}']/following::input[{inputIndex}])[1]");

        }
        //public InputComponent(IWebElement webElement, string inputString)
        //{
        //    this.webElement = webElement;
        //}
        public void EnterText(string text)
        {

            GetInstance().SendKeys(text);
        }

        public IWebElement GetInstance()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator);
        }
        public  IWebElement GetElement()
        {
            return _parent.FindElement(_locator);
        }
    }
}
