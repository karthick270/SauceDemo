using OpenQA.Selenium;
namespace SauceDemo.Elements
{
    public class InventoryItem
    {
        public double ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public IWebElement AddCart {  get; set; }


    }
}
