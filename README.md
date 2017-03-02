# UnityNLogExtension
A simple extension to Unity that enables NLog Logger dependencies to be injected into consuming classes, with the ILogger instance being configured as the correct logger for the consuming class.

This library is an adaptation of UnityLog4NetExtension (https://github.com/roblevine/UnityLog4NetExtension) to NLog.

**Usage:**

    var container = new UnityContainer();
    container.AddNewExtension<NLogExtension<Logger>>()
	container.RegisterType<ILogger, Logger>();
	
Any class inherited from `NLog.Logger` can be used as the generic type parameter for `NLogExtension`.
    
See http://blog.roblevine.co.uk/net/using-log4net-with-unity/ for more info.

NOTE: This is now available as a NuGet package: 
https://www.nuget.org/packages/UnityLog4NetExtension/