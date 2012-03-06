using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    [Flags]
    public enum LinkOption
    {
        None        = 0,
        First       = 1,
        Last        = 2,
        Image       = 4,
        Disabled    = 8,
        Selected    = 16,
    }
}