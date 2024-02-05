using OpenQA.Selenium;
using SalesbookTest.Drivers;

namespace SalesbookTest.Components
{
    public class LinkComponent
    {
        private readonly By _locator;

        public LinkComponent(By locator)
        {
            _locator = locator;
        }

        public void Click()
        {
            BrcWebdriver.GetInstance().FindElement(_locator).Click();
        }


    }
}
