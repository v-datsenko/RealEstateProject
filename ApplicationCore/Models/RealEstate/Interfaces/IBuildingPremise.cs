using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.RealEstate
{
    interface IBuildingPremise
    {
        public int NumberFloor { get; set; }
        public TypeBalcony TypeBalcony { get; set; }
    }
}
