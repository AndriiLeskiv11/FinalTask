using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.PageObject;
public class BasePage
{
    protected readonly IWebDriver driver;
    protected readonly WebDriverWait wait;
    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    protected void WriteText(By element, string text)
    {
        this.driver.FindElement(element).SendKeys(text);
    }

    protected void DeleteText(By element)
    {
        var pageElement = this.driver.FindElement(element);
        pageElement.Click();
        pageElement.SendKeys(Keys.Control + "A");
        pageElement.SendKeys(Keys.Delete);
    }
}
