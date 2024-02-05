using OpenQA.Selenium;
using SalesbookTest.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesbookTest.Pages.HomePage.Forms
{
    public class LineItem
    {
        public InputComponent product => new InputComponent(By.XPath("//input[@name='productCode']"));
        public InputComponent quantity => new InputComponent(By.XPath("//input[@name='quantity']"));
        public InputComponent unitPrice => new InputComponent(By.XPath("//input[@name='unitPrice']"));
        public InputComponent cat1 => new InputComponent(By.XPath("//tr[contains(@class, 'x-grid-row')][1]//input[contains(@class, 'x-form-text')]\r\n"));
        public InputComponent cat3 => new InputComponent(By.XPath("//tr[contains(@class, 'x-grid-row')][3]//input[contains(@class, 'x-form-text')]\r\n"));
        public InputComponent cat2=> new InputComponent(By.XPath("//tr[contains(@class, 'x-grid-row')][2]//input[contains(@class, 'x-form-text')]\r\n"));
        public InputComponent cat4 => new InputComponent(By.XPath("//tr[contains(@class, 'x-grid-row')][4]//input[contains(@class, 'x-form-text')]\r\n"));
        public ButtonComponent saveButton => new ButtonComponent(By.XPath("//span[text()='Save']/ancestor::button\r\n"));
        public ButtonComponent closeButton => new ButtonComponent(By.XPath("//div[contains(@class, 'x-tool-close')]\r\n"));
        public ButtonComponent yesButton => new ButtonComponent(By.XPath("//div[contains(@class, 'x-btn-inner') and text()='Yes']/ancestor::div[contains(@class, 'x-btn')]\r\n"));


    }
}
