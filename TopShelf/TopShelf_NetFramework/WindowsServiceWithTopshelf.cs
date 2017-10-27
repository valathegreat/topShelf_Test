using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf_NetFramework
{
    public class WindowsServiceWithTopshelf
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

    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<WindowsServiceWithTopshelf.MyService>(service =>
                {
                    service.ConstructUsing(s => new WindowsServiceWithTopshelf.MyService());
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
