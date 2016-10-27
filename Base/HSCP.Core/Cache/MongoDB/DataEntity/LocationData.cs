using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    [Serializable]
    public class LocationData
    {
        public ObjectId _id { get; set; }

        public LocData Loc { get; set; }
    }
}
