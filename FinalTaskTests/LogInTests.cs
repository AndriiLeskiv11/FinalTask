using FinalTask;
using FinalTask.PageObject;
using FinalTaskTests.Fixtures;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace FinalTaskTests
{

    public abstract class LogInTests : IClassFixture<LogFixture>
    {
        private readonly IDriverFixture fixture;
        private readonly ILog logger = LogManager.GetLogger(typeof(LogInTests));
        protected LogInTests(IDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("locked_out_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void LogInWhithEmptyCredentials(string userName, string password)
        {
            LogInPage logInPage = new LogInPage(this.fixture.Driver);
            logInPage.Cleanup();
            logInPage.Open();
            this.logger.Info("Entering credentials");
            logInPage.EnterUsername(userName);
            logInPage.EnterPassword(password);
            this.logger.Info("Clearing credentials");
            logInPage.ClearLogInInput();
            this.logger.Info("Attempting Log In");
            logInPage.ClickLogin();

            Assert.Equal("Epic sadface: Username is required", logInPage.GetError());
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("locked_out_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void LogInWhithEmptyPassword(string userName, string password)
        {
            LogInPage logInPage = new LogInPage(this.fixture.Driver);
            logInPage.Cleanup();
            logInPage.Open();
            logInPage.EnterUsername(userName);
            logInPage.EnterPassword(password);
            logInPage.ClearPasswordInput();
            logInPage.ClickLogin();
            Assert.Equal("Epic sadface: Password is required", logInPage.GetError());
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void ValidLogIn(string userName, string password)
        {
            LogInPage logInPage = new LogInPage(this.fixture.Driver);
            logInPage.Cleanup();
            logInPage.Open();
            logInPage.EnterUsername(userName);
            logInPage.EnterPassword(password);
            logInPage.ClickLogin();
            Assert.Equal("Swag Labs", logInPage.ApproveLogIn());
        }
    }

    [Collection("FirefoxTests")]
    public class LoginTextFirefox : LogInTests, IClassFixture<FirefoxDriverFixture>
    {
        public LoginTextFirefox(FirefoxDriverFixture fixture) : base(fixture)
        {
        }
    }


    [Collection("EdgeTests")]
    public class LoginTextEdge : LogInTests, IClassFixture<EdgeDriverFixture>
    {
        public LoginTextEdge(EdgeDriverFixture fixture) : base(fixture)
        {
        }
    }
}
