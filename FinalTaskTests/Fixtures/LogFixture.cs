using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace FinalTaskTests.Fixtures;
public class LogFixture
{
    public LogFixture()
    {
        var logRepository = LogManager.GetRepository();
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}
