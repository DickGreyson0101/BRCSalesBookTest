using SalesbookTest.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesbookTest.Contracts;
using SalesbookTest.Components;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V118.Debugger;
using System.Collections.ObjectModel;  // Ensure this namespace is included
using NUnit.Framework;

namespace SalesbookTest.ActionHandlers
{
    public class ActionHandler
    {
        //Actions action = new Actions(BrcWebdriver.GetInstance());
        //private IComponentAction componentAction;
        //
        //public void SetActionStrategy(IComponentAction actionStrategy)
        //{
        //    this.componentAction = actionStrategy;
        //}
        public void Handle(string action,  string elementName, string elementType, string detail, string windowId)
        {
            var webDriver = BrcWebdriver.GetInstance();
            var webDriverAction = new Actions(webDriver);

            //var windowComponent = webDriver.FindElement(By.XPath($"//div[starts-with(@id,'{windowId}')]"));
            IBaseComponent? component = null;
         
            switch (elementType)
            {
                case "Button":
                    component = new ButtonComponent(windowId, elementName);
                    break;
                case "Input":
                    component = new InputComponent(windowId, elementName);
                    break;
                case "VATAnalysis":
                    component = new VATAnalysisInputComponent(windowId, elementName);
                        break ;
                case "AnalysisCategories":
                    component = new AnalysisCategoriesInputComponent(windowId, elementName);
                    break;
                case "DataGrid":
                    component = new DataGridComponent( elementName);
                    break;
                case "Message":
                    component = new ToolTipComponent( elementName);
                    break;
                case "Radio":
                    component = new RadioComponent(windowId,elementName);
                    break;
                case "Url":
                    component = new UrlComponent(elementName);
                    break;
                case "ReportButton":
                    component = new ReportButtonComponent( elementName, detail);
                    break;
            }
            if (component == null) { return; }
            switch (action) {
                case "Clicks":
                    //webDriverAction.Click(component.GetElement());
                    webDriverAction.Click(component.GetElement()).Build().Perform();
                    //component.GetElement().Click();
                    Thread.Sleep(2000);
                    break;
                case "Enters":
                    webDriverAction.Click(component.GetElement()).Build().Perform();
                    component.GetElement().Clear();
                    component.GetElement().SendKeys(detail);
                    break;
                case "Double clicks":
                    webDriverAction.DoubleClick(component.GetElement()).Build().Perform();
                    break; 
                case "Checks new record":
                    if (component is DataGridComponent dataGridComponent)
                    {
                        bool hasNewRow = dataGridComponent.CheckNewRecord();
                        Assert.AreEqual(true, hasNewRow);
                    }
                    break;
                case "Checks existence":
                    if (component is ToolTipComponent MessageComponent)
                    {
                        bool isMessageDisplayed = MessageComponent.CheckDisplay();
                        Assert.AreEqual(true, isMessageDisplayed);
                    }
                    break;
                case "Selects":
                    webDriverAction.Click(component.GetElement()).Build().Perform();
                    break;
                case "Checks Display":
                    bool isButtonDisplayed = component.GetElement().Displayed;
                    Assert.AreEqual(false, isButtonDisplayed);

                    break;
                case "Waits":
                    if (component is UrlComponent waitUrlComponent)
                    {
                        waitUrlComponent.WaitForUrl(elementName);

                    }

                    break;
                case "Verifies Content":
                    if (component is UrlComponent verifyUrlComponent)
                    {
                       bool isContentDisplayed = verifyUrlComponent.VerifyElementTextPresent(elementName);
                        Assert.AreEqual(true, isContentDisplayed);
                    }
                    break;

            }


        }
    }
}
