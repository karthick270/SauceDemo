using BoDi;
using SauceDemo.PageObjects;
using TechTalk.SpecFlow;

namespace SauceDemo.Steps
{
    [Binding]
    public class AddItemToCartSteps : StepBase
    {
        public AddItemToCartSteps(IObjectContainer container) : base(container)
        {
        }
        private new LoginPage LoginPage => GetPage<LoginPage>();
        private new ProductsPage ProductsPage => GetPage<ProductsPage>();
        private new BasketPage BasketPage => GetPage<BasketPage>();

        [Given(@"I go to sauce demo page")]
        public void GivenIGoToSauceDemoPage()
        {
            LoginPage.NavigateToLoginPage();
        }

        [When(@"I login using to webpage")]
        public void WhenILoginUsingToWebpage()
        {
            LoginPage.Login();
        }

        [When(@"I select the highest price item and add to cart")]
        public void WhenISelectTheHighestPriceItemAndAddToCart()
        {            
            ProductsPage.SelectHighestPriceItem();
        }

        [When(@"I click add to shopping cart link")]
        public void WhenIClickAddToShoppingCartLink()
        {
            ProductsPage.ClickShoppingCartLink();
        }

        [Then(@"I should see the hight price item added to cart")]
        public void ThenIShouldSeeTheHightPriceItemAddedToCart()
        {
            BasketPage.VerifyHighestItemAddedToBasket();
        }
    }
}
