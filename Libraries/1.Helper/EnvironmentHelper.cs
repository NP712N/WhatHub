using System;

namespace _1.Helper
{
    public static class EnvironmentHelper
    {
        public static string GetByKey(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
