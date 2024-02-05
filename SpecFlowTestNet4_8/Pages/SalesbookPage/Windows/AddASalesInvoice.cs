using OpenQA.Selenium;
using SalesbookTest.Components;
using SalesbookTest.Pages.HomePage.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesbookTest.Pages.HomePage.Forms
{
    public class AddASalesInvoice:BaseWindows
    {
        // important : //div[starts-with(@id,'salesBookEntryEdit')]//label[text()='Date:']/ancestor::td/following-sibling::td//input
        public InputComponent yourRef => new InputComponent(By.XPath("//label[text()='Your Reference:']/ancestor::td/following-sibling::td//input\r\n"));
        public InputComponent ourRef => new InputComponent(By.XPath("//label[text()='Our Reference:']/ancestor::td/following-sibling::td//input\r\n"));
        public InputComponent salesRep => new InputComponent(By.XPath("//label[contains(text(),'Sales Rep:')]/following::input[1]\r\n"));

        public InputComponent account => new InputComponent(By.XPath("//*[@id=\"lookupTrigger-1238-inputEl\"]"));

        public ButtonComponent add => new ButtonComponent(By.CssSelector("#lookupTrigger-1238-inputEl"));

        public ButtonComponent saveButton => new ButtonComponent(By.XPath("//button[contains(., 'Save')]\r\n"));
        //(//div[starts-with(@id,'salesInvoicingBookEdit')]//*[text()='Account:']/ancestor::td/following-sibling::td//input)[1]
    }

}
