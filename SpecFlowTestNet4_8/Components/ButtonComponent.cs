﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SalesbookTest.Contracts;
using SalesbookTest.Drivers;
using System;

namespace SalesbookTest.Components
{
    public class ButtonComponent : IBaseComponent
    {

        private readonly By _locator;
        private IWebElement _parent;
        Actions action = new Actions(BrcWebdriver.GetInstance());

        public ButtonComponent(By locator)
        {
            _locator = locator;
        }

        public ButtonComponent(string windowName, string buttonName)
        {
            _locator = By.XPath($"//div[starts-with(@id,'{windowName}')]//*[text()='{buttonName}']");
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

        //public IWebElement GetInstance()
        //{
        //    return BrcWebdriver.GetInstance().FindElement(_locator);
        //}

        //public  IWebElement GetElement()
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
