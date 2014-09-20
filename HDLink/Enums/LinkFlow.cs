using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Represents the direction of the ILink. Default Bidirectional
    /// </summary>
    public enum LinkFlow
    {
        Bidirectional = 0,
        AtoB = 1,
        BtoA = 2
    }
}
