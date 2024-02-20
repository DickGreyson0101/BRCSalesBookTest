using OpenQA.Selenium;
using SalesbookTest.Drivers;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using System;
using SalesbookTest.Contracts;
using System.Collections.ObjectModel;  // Ensure this namespace is included
using System.Collections.Generic;
using SalesbookTest.Features.StepDefinition;

namespace SalesbookTest.Components
{
    public class DataGridComponent : IBaseComponent
    {

        private readonly By _locator;
        private IWebElement _parent;
        //public StepDefinition previousCount ;

        public DataGridComponent(By locator)
        {
            _locator = locator;
            
        }
        public DataGridComponent(string element)
        {
            //_parent = parent;
           
            _locator = By.XPath($"(//div[starts-with(@id, 'gridpanel')]//div[starts-with(@id,'gridview')]//table[starts-with(@class, 'x-grid-table')])[1]//tr[contains(@class, 'x-grid-row')][{element}]");
            //if(_previousRowCount < 0)
            //{
            //    _previousRowCount = GetRows();
            //}
        }

        public  int GetRows()
        {
            return _parent.FindElements(_locator).Count;
        }

        public  bool CheckNewRecord()
        {
            int currentRowCount = GetRows();
            if (currentRowCount > StepDefinition._previousRecordCount)
            {
                StepDefinition._previousRecordCount = currentRowCount; 
                return true;
            }
            else
            {
                return false;
            }
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
