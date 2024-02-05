using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SalesbookTest.Components;

namespace SalesbookTest.Pages.HomePage
{
    public class LogInPage
    {



        public InputComponent EmailInput => new InputComponent(By.Id("uxLogin"));
        public InputComponent PasswordInput => new InputComponent(By.Name("uxPassword"));
        
        public ButtonComponent LoginButton => new ButtonComponent(By.Id("uxSingIn"));






     




    }
}