using OpenQA.Selenium;
using SalesbookTest.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesbookTest.Pages.HomePage.Forms
{
    public class ElementsForSelection
    {
        public ButtonComponent OkbuttonInSelectEntryType => new ButtonComponent(By.XPath("//button[contains(@id, 'localeButton') and contains(@id, '-btnEl') and .//span[text()='OK']]"));
        public RadioComponent SalesbookEntriesRadio => new RadioComponent(By.XPath("(//input[contains(@id, 'radiofield') and contains(@id, '-inputEl')])[1]"));

        public RadioComponent SalesInvoicesRadio => new RadioComponent(By.XPath("(//input[contains(@id, 'radiofield') and contains(@id, '-inputEl')])[2]"));

    }
}
