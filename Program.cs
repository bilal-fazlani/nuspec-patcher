using CommandDotNet;
using CommandDotNet.Models;

namespace NuspecPatcher
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new AppRunner<App>(new AppSettings
            {
                Case = Case.KebabCase,
                EnableVersionOption = false
            });
            
            return app.Run(args);
        }
    }
}