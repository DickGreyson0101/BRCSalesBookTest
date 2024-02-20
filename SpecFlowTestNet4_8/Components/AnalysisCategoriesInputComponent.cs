using OpenQA.Selenium;
using SalesbookTest.Drivers;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using System;
using SalesbookTest.Contracts;

namespace SalesbookTest.Components
{
    public class AnalysisCategoriesInputComponent : IBaseComponent
    {
        private static Dictionary<string, int> _inputCounters = new Dictionary<string, int>();

        private readonly By _locator;
        private IWebElement _parent;

        public AnalysisCategoriesInputComponent(By locator)
        {
            _locator = locator;
            
        }
        public AnalysisCategoriesInputComponent(string windowName,  string inputIndex)
        {
            //_locator = By.XPath($"(.//*[text()='{inputElementName}']/following::input[{inputIndex}])[1]");
            _locator = By.XPath($"(//div[starts-with(@id,'{windowName}')]//*[contains(text(), 'Analysis Categories')]/following::input[starts-with(@id, 'scalableNumber-')])[{inputIndex}]");
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
