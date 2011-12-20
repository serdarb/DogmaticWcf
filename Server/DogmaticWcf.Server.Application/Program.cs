using System;
using System.ServiceProcess;

namespace DogmaticWcf.Server.Application
{
    class Program
    {
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Bootstrapper.Initialize();
                Console.WriteLine("Server ready...");
                Console.ReadLine();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { });
            }
        }
    }
}
