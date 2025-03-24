using OpenQA.Selenium;

namespace FinalTask.PageObject;
public class LogInPage : BasePage
{
    private static string Url { get; } = "https://www.saucedemo.com/";
    private readonly By usernameField = By.Id("user-name");
    private readonly By passwordField = By.Id("password");
    private readonly By loginButton = By.Id("login-button");
    private readonly By errorMessage = By.CssSelector("[data-test='error']");

    public LogInPage(IWebDriver driver) : base(driver)
    {
    }

    public void Open()
    {
        this.driver.SwitchTo().NewWindow(WindowType.Tab).Navigate().GoToUrl(Url);
    }

    public void EnterUsername(string username)
    {
        this.WriteText(this.usernameField, username);
    }

    public void EnterPassword(string password)
    {
        this.WriteText(this.passwordField, password);
    }

    public void ClickLogin()
    {
        this.driver.FindElement(this.loginButton).Click();
    }

    public void ClearLogInInput()
    {
        this.DeleteText(this.usernameField);
    }

    public void ClearPasswordInput()
    {
        this.DeleteText(this.passwordField);
    }

    public string GetError()
    {
        return this.driver.FindElement(this.errorMessage).Text;
    }

    public string ApproveLogIn()
    {
        return this.driver.FindElement(By.ClassName("app_logo")).Text;
    }

    public void Cleanup()
    {
        this.driver.Manage().Cookies.DeleteAllCookies();
    }
}
