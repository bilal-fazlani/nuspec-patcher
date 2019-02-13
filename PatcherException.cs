using System;
using System.Data;

namespace NuspecPatcher
{
    public class PatcherException: Exception
    {
        public PatcherException(string message):base(message)
        {
            
        }
    }
}