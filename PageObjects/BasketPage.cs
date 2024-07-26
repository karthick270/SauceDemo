using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SauceDemo.PageObjects
{
    public class BasketPage : BasePage
    { 
        public BasketPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement InventoryItemName => Driver.FindElement(By.XPath("//div[@class = 'inventory_item_name']"));

        public void VerifyHighestItemAddedToBasket()
        {
            var highestPriceItemDescription = ScenarioContext.Current["ItemName"];
            InventoryItemName.Text.Should().Be(highestPriceItemDescription.ToString(), $"{InventoryItemName} is not same as {highestPriceItemDescription}");
        }
    }
}
