using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FinalTaskTests.Fixtures;
public interface IDriverFixture
{
    public IWebDriver Driver { get; }
}
