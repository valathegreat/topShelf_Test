# topShelf_Test #


**Creating Windows Service In .NET with Topshelf**


Following are the steps to create Windows service in .Net with Topshelf:
Create a New Project with Console Application Template using Visual Studio. 



> Install Topshelf using NuGet Package Manager.


> Create a class that contain our service logic: MyService.cs.

```
namespace WindowsServiceWithTopshelf  
{  
    public class MyService  
    {  
        public void Start()  
        {  
            // write code here that runs when the Windows Service starts up.  
        }  
        public void Stop()  
        {  
            // write code here that runs when the Windows Service stops.  
        }  
    }  
}  
```
> Create a class to configure our service logic using the Topshelf project: ConfigureService.cs.

```
using Topshelf;  
namespace WindowsServiceWithTopshelf  
{  
    internal static class ConfigureService  
    {  
        internal static void Configure()  
        {  
            HostFactory.Run(configure =>  
            {  
                configure.Service < MyService > (service =>  
                {  
                    service.ConstructUsing(s => new MyService());  
                    service.WhenStarted(s => s.Start());  
                    service.WhenStopped(s => s.Stop());  
                });  
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();  
                configure.SetServiceName("MyWindowServiceWithTopshelf");  
                configure.SetDisplayName("MyWindowServiceWithTopshelf");  
                configure.SetDescription("My .Net windows service with Topshelf");  
            });  
        }  
    }  
}

```

Call configure service in Main():
```
namespace WindowsServiceWithTopshelf  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            ConfigureService.Configure();  
        }  
    }  
}  
```
#Build Console application.#



#Install/uninstall Console Application using Topshelf command.#

Run Command Prompt as an Administrator and navigate to the bin/debug folder of Console Application.

```
WindowsServiceWithTopshelf.exe install //Your exe file name
```

#To uninstall windows service run this command.#

```
windowsServiceWithTopshelf.exe uninstall //Your exe file name
```
