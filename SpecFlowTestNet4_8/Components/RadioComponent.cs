using OpenQA.Selenium;
using SalesbookTest.Contracts;
using SalesbookTest.Drivers;

namespace SalesbookTest.Components
{
    public class RadioComponent:IBaseComponent
    {
        private readonly By _locator;
        private IWebElement _parent;

        public RadioComponent(By locator)
        {
            _locator = locator;
        }
        public RadioComponent( string windowName,string buttonName)
        {
            //_parent = parent;
            _locator = By.XPath($"//div[starts-with(@id,'selectEntryType')]//*[text()='{buttonName}']/ancestor::td[contains(@class,'wrap')]");
            //_locator = By.XPath($"(//div[starts-with(@id,'{windowName}')]//td[contains(@class,'wrap')])[{buttonName}]");
        }
        public void Click()
        {
            BrcWebdriver.GetInstance().FindElement(_locator).Click();
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
