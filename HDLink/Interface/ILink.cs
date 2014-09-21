﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Represents a link between two nodes
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// First Node in a Link
        /// </summary>
        INode NodeA { get; }

        /// <summary>
        /// Second Node in a Link
        /// </summary>
        INode NodeB { get; }
        
        /// <summary>
        /// Strength of Link
        /// </summary>
        float Strength { get; }

        /// <summary>
        /// Direction of Link
        /// </summary>
        LinkFlow Direction { get; }

        LinkType Type { get; }
        
    }
}
