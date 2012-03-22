using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class ConcerningAttribute : Attribute
    {
        public Type ConcerningType { get; private set; }

        public ConcerningAttribute(Type concerningType)
        {
            ConcerningType = concerningType;
        }
    }
}
