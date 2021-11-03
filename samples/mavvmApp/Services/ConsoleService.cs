using System;
using mavvmApp.Interfaces;

namespace mavvmApp.Services
{
    public class ConsoleService : IConsoleService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}

