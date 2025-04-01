using FinalTask.PageObject;
using FinalTaskTests.Fixtures;
using FluentAssertions;
using log4net;

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
            this.logger.Info("Clearing username");
            logInPage.ClearLogInInput();
            this.logger.Info("Attempting Log In");
            logInPage.ClickLogin();

            _ = logInPage.GetErrorMessage().Should().Be("Epic sadface: Username is required");
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
            this.logger.Info("Entering credentials");
            logInPage.EnterUsername(userName);
            logInPage.EnterPassword(password);
            this.logger.Info("Clearing password");
            logInPage.ClearPasswordInput();
            this.logger.Info("Attempting Log In");
            logInPage.ClickLogin();

            _ = logInPage.GetErrorMessage().Should().Be("Epic sadface: Password is required");
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
            this.logger.Info("Entering credentials");
            logInPage.EnterUsername(userName);
            logInPage.EnterPassword(password);
            this.logger.Info("Attempting Log In");
            logInPage.ClickLogin();

            _ = logInPage.ApproveLogIn().Should().Be("Swag Labs");
        }
    }

    [Collection("FirefoxTests")]
    public class LoginTextFirefox(FirefoxDriverFixture fixture) : LogInTests(fixture), IClassFixture<FirefoxDriverFixture>
    {
    }


    [Collection("EdgeTests")]
    public class LoginTextEdge(EdgeDriverFixture fixture) : LogInTests(fixture), IClassFixture<EdgeDriverFixture>
    {
    }
}
