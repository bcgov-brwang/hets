﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HetsData.Entities
{
    public partial class HetUserFavourite
    {
        public int UserFavouriteId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? IsDefault { get; set; }
        public int? UserId { get; set; }
        public int? DistrictId { get; set; }
        public string AppCreateUserDirectory { get; set; }
        public string AppCreateUserGuid { get; set; }
        public string AppCreateUserid { get; set; }
        public DateTime AppCreateTimestamp { get; set; }
        public string AppLastUpdateUserDirectory { get; set; }
        public string AppLastUpdateUserGuid { get; set; }
        public string AppLastUpdateUserid { get; set; }
        public DateTime AppLastUpdateTimestamp { get; set; }
        public string DbCreateUserId { get; set; }
        public DateTime DbCreateTimestamp { get; set; }
        public DateTime DbLastUpdateTimestamp { get; set; }
        public string DbLastUpdateUserId { get; set; }
        public int ConcurrencyControlNumber { get; set; }

        public virtual HetDistrict District { get; set; }
        public virtual HetUser User { get; set; }
    }
}
