using System;

namespace Core.Web
{
    [Flags]
    public enum PageOption
    {
        None = 0,
        NotNavigable = 1,
        Area = 2,
        Controller = 4,
        Action = 8,
        Anonymous = 16,
        System = 32,
        Parameterized = 64,
        Hidden = 128,
        Default = 256,
    }
}
