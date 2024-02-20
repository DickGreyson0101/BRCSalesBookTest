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
    public class UrlComponent : IBaseComponent
    {
        private readonly By _locator;
        private IWebElement _parent;
        public UrlComponent(By locator)
        {
            _locator = locator;

        }

        public UrlComponent(string inputElementName)
        {
            //_parent = parent;
            _locator = By.XPath($"//*[text()='{inputElementName}']");
            //_locator = By.XPath($"(.//*[text()='{inputElementName}']/following::input[{inputIndex}])[1]");

        }
        public IWebElement GetInstance()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator);
        }
        public IWebElement GetElement()
        {
            return GetInstance().FindElement(_locator);
        }

        public bool CheckDisplay()
        {
            return GetInstance().Displayed;
        }
    }
}
