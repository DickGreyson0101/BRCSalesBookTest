using OpenQA.Selenium;
using SalesbookTest.Drivers;

namespace SalesbookTest.Components
{
    public class LabelComponent
    {
        private readonly By _locator;

        public LabelComponent(By locator)
        {
            _locator = locator;
        }

        public bool Display()
        {
            return BrcWebdriver.GetInstance().FindElement(_locator).Displayed;
        }

        public string GetText() 
        {
            return BrcWebdriver.GetInstance().FindElement(_locator).Text;
        }
    }
}
