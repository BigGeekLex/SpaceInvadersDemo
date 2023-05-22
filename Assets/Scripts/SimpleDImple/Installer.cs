using System;

namespace SimpleDImple
{
    public class Installer : InstallerBase
    {
        protected override object GetInjectArg(Type parameterType)
        {
            return SimpleDImple.Get(parameterType);
        }
    }
}