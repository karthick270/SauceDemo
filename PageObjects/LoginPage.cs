using OpenQA.Selenium;

namespace SauceDemo.PageObjects
{
    public class LoginPage : BasePage
    {
        string username = "standard_user";
        string password = "secret_sauce";
        private IWebElement UserName => Driver.FindElement(By.Id("user-name"));
        private IWebElement Password => Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("input[value='Login']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToLoginPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login()
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Click();
        }

        public void ClickLoginButton()
        {

        }
    }
}
