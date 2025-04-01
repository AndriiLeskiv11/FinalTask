using log4net.Config;
using log4net;

namespace FinalTaskTests.Fixtures;
public class LogFixture
{
    public LogFixture()
    {
        var logRepository = LogManager.GetRepository();
        _ = XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}
