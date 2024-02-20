using OpenQA.Selenium;
using SalesbookTest.Drivers;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using System;
using SalesbookTest.Contracts;

namespace SalesbookTest.Components
{
    public class VATAnalysisInputComponent : IBaseComponent
    {

        private readonly By _locator;
        private IWebElement _parent;

        public VATAnalysisInputComponent(By locator)
        {
            _locator = locator;
            
        }
        public VATAnalysisInputComponent(string windowName,  string inputIndex)
        {
            //_locator = By.XPath($"(.//*[text()='{inputElementName}']/following::input[{inputIndex}])[1]");
            _locator = By.XPath($"(//div[starts-with(@id,'{windowName}')]//*[contains(text(), 'VAT analysis')]/following::input[starts-with(@id, 'scalableNumber-')])[{inputIndex}]");
        }

        //public IWebElement GetElement()
        //{
        //    return _parent.FindElement(_locator);
        //}
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
