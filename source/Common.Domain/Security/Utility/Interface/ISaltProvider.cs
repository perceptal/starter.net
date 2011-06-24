using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Domain
{
    public interface ISaltProvider
    {
        string GenerateSalt();
        
        string GenerateSalt(int length);
    }
}
