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
        public AnalysisCategoriesInputComponent(IWebElement parent,  string inputIndex)
        {
            _parent = parent;
            //_locator = By.XPath($"(.//*[text()='{inputElementName}']/following::input[{inputIndex}])[1]");
            _locator = By.XPath($"(.//*[contains(text(), 'Analysis Categories')]/following::input[starts-with(@id, 'scalableNumber-')])[{inputIndex}]");
        }

        public IWebElement GetElement()
        {
            return _parent.FindElement(_locator);
        }
    }
}
