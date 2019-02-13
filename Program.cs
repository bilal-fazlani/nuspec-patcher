using CommandDotNet;
using CommandDotNet.Models;

namespace NuspecPatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppRunner<App>(new AppSettings
            {
                Case = Case.KebabCase,
                EnableVersionOption = false
            });
            
            app.Run(args);
        }
    }
}