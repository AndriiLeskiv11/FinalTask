using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalTaskTests.Fixtures;
public abstract class DriverFixture<TDriver> : IDriverFixture, IDisposable
        where TDriver : IWebDriver, new()
{
    protected DriverFixture()
    {
        this.Driver = new TDriver();
        this.Driver.Manage().Window.Maximize();
        this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
    }

    public IWebDriver Driver { get; protected set; }

    public void Dispose()
    {
        if (this.Driver != null)
        {
            this.Driver.Quit();
            this.Driver.Dispose();
        }
    }
}
