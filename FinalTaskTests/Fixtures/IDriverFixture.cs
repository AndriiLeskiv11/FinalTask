using OpenQA.Selenium;

namespace FinalTaskTests.Fixtures;
public interface IDriverFixture
{
    public IWebDriver Driver { get; }
}
