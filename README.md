# Log4net_logging
Customize-able Log4net, using .net core 6

Feel free to to use, as didn't create nuget services to pump data, need to add source code into the project.

+----- Log4net_logging  
  |  
  +--- Web  
  |  
  +--- Structure  
    |  
    +- Log4net  
    
    
A customizable log4net, reuseable on all services and controller on whole system.
An also automatically log system logging level, whenever system run error with customizable information log in "log4net.config(xml)"

  +--- _Log4net  
     |  
     +-- LogBuilder.cs (Initialize log4net and custom log level function)  
     +-- Logger.cs (Custom and log level)  
     +-- LogProvider.cs (After initialize, getting references and log detail from config file)  
   
- System level log,
- Startup log level,
- Compatible with Microsoft.Extensions.Logging (ILogger)
  - ILoggerFactory (Services)
- All Controller Ilogging services
- Nuget use

+----- Log4net_logging
  
  +--- Web (log4net @2.0.14)
  
  +--- Structure (log4net @2.0.14, Microsoft.Extensions.Logging @6)

- DEMO -
+-- Program.cs
 | Code (iniitialize in Program.cs)
```
app.Services.GetRequiredService<ILoggerFactory>().AddLog4net("log4net.config", "log4net"); // ....AddLog4net("__Config File Name__", "log4net")
```
+-- HomeController.cs
 | Sample Code
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello!."); //It will log the using log4net
            return View();
        }
    }
