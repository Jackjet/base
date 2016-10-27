using System;
using HSCP.Core;

namespace HSCP.Model
{
    /// <summary>
    /// demotype
    /// </summary>
    public class DemoType : Entity<int>
    {
        public virtual string  Name { get; set; }
   
    }
}
