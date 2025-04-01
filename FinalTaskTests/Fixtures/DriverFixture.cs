using OpenQA.Selenium;

namespace FinalTaskTests.Fixtures;
public abstract class DriverFixture<TDriver> : IDriverFixture, IDisposable
        where TDriver : IWebDriver, new()
{
    private bool isDisposed = false;

    ~DriverFixture()
    {
        this.Dispose(false);
    }

    protected DriverFixture()
    {
        this.Driver = new TDriver();
        this.Driver.Manage().Window.Maximize();
        this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
    }

    public IWebDriver Driver { get; protected set; }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!this.isDisposed)
        {
            if (disposing)
            {
                this.Driver.Quit();
                this.Driver.Dispose();
            }

            this.isDisposed = true;
        }
    }
}
