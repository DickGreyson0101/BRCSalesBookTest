using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SalesbookTest.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesbookTest.Components
{
    public class ElementByIdComponent
    {
        private readonly By _locator;
        private IWebElement _parent;
        Actions action = new Actions(BrcWebdriver.GetInstance());

        public ElementByIdComponent(By locator)
        {
            _locator = locator;
        }

        public ElementByIdComponent(IWebElement parent, string buttonName)
        {
            _parent = parent;
            _locator = By.XPath($".//*[text()='{buttonName}']");
        }

        public IWebElement GetInstance()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator);
        }

        public IWebElement GetElement()
        {
            return _parent.FindElement(_locator);
        }

    }
}
