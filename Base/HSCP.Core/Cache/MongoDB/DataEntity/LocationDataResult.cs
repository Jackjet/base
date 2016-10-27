using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    [Serializable]
    public class LocationDataResult
    {
        public double Distance { get; set; }

        public LocationData Loc { get; set; }
    }
}
