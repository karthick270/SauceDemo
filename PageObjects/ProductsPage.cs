using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SauceDemo.Elements;
using TechTalk.SpecFlow;
using System.Net.WebSockets;

namespace SauceDemo.PageObjects
{
    public class ProductsPage : BasePage
    {
        IWebDriver _driver;
        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.ClassName, Using = "pricebar")]
        public List<IWebElement> PriceBarBlock { get; set; }

        [FindsBy(How = How.ClassName, Using = " btn_inventory")]
        public List<IWebElement> AddToCart { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_price")]
        public List<IWebElement> Price { get; set; }
        public IList<IWebElement> inventoryList => Driver.FindElements(By.ClassName("inventory_item"));
        public IWebElement ShoppingCartLink => Driver.FindElement(By.ClassName("shopping_cart_link"));

        public void SelectHighestPriceItem()
        {
            var inventoryList = _driver.FindElements(By.ClassName("inventory_item"));
            //List<IWebElement> priceBars = new List<IWebElement>();
            //List<IWebElement> inventoryItemNames = new List<IWebElement>();
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
            if(ShoppingCartLink.Displayed)
            ShoppingCartLink.Click();
        }

        public void SelectHighestPriceItemX()
        {
            var inventoryList = _driver.FindElements(By.ClassName("inventory_list"));
            List<IWebElement> priceBars = new List<IWebElement>();
            List<IWebElement> inventoryItemNames = new List<IWebElement>();
            var inventoryItems = new List<InventoryItem>();

            foreach (var item in inventoryList)
            {
                var priceBar = item.FindElement(By.ClassName("pricebar"));
                //priceBars.Add(priceBar); //may not need this
                var inventoryItem = new InventoryItem()
                {
                    ItemDescription = item.FindElement(By.ClassName("inventory_item_name")).Text,
                    ItemPrice = GetItemPrice(priceBar),
                    AddCart = priceBar.FindElement(By.ClassName("btn_inventory"))
                };
            }

            var priceListElements = new List<IWebElement>();
            var priceAddCartDict = new Dictionary<IWebElement, double>();
            List<double> priceList = new List<double>();

            foreach (var priceBar in priceBars)
            {
                var priceEl = priceBar.FindElement(By.ClassName("inventory_item_price"));
                var addCartEl = priceBar.FindElement(By.ClassName("btn_inventory"));

                var price = priceEl.Text.Replace("$", "");
                var valid = Double.TryParse(price, out double cost);
                if (valid)
                {
                    priceList.Add(cost);
                    priceAddCartDict.Add(addCartEl, cost);
                }

                priceListElements.Add(priceEl);
            }

            var priceDict = new Dictionary<IWebElement, double>();

            var maxPrice = priceList.Max();
            var maxPriceVal = priceAddCartDict.FirstOrDefault(x => x.Value == maxPrice);
            var maxPriceDictElem = maxPriceVal.Key;

            var addCartElem = priceAddCartDict[maxPriceDictElem];

            maxPriceDictElem.Click();
        }
    }
}
