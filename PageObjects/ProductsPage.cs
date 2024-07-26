using OpenQA.Selenium;
using SauceDemo.Elements;
using TechTalk.SpecFlow;

namespace SauceDemo.PageObjects
{
    public class ProductsPage : BasePage
    {
        IWebDriver _driver;
        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IList<IWebElement> inventoryList => Driver.FindElements(By.ClassName("inventory_item"));
        public IWebElement ShoppingCartLink => Driver.FindElement(By.ClassName("shopping_cart_link"));

        public void SelectHighestPriceItem()
        {
            var inventoryItems = new List<InventoryItem>();

            foreach (var item in inventoryList)
            {
                var priceBar = item.FindElement(By.ClassName("pricebar"));
                var inventoryItem = new InventoryItem()
                {
                    ItemDescription = item.FindElement(By.ClassName("inventory_item_name")).Text,
                    ItemPrice = GetItemPrice(priceBar),
                    AddCart = priceBar.FindElement(By.ClassName("btn_inventory"))
                };
                inventoryItems.Add(inventoryItem);
            }

            var priceDict = new Dictionary<IWebElement, double>();

            var maxPriceItem = inventoryItems.OrderByDescending(x => x.ItemPrice).First();
            ScenarioContext.Current["ItemName"] = maxPriceItem.ItemDescription;
            maxPriceItem.AddCart.Click();
        }

        private double GetItemPrice(IWebElement priceBar)
        {
            var priceEl = priceBar.FindElement(By.ClassName("inventory_item_price"));

            var price = priceEl.Text.Replace("$", "");
            var valid = Double.TryParse(price, out double cost);
            if (valid)
            {
                return cost;
            }
            return 0.0;
        }

        public void ClickShoppingCartLink()
        {
            if (ShoppingCartLink.Displayed)
                ShoppingCartLink.Click();
        }
    }
}