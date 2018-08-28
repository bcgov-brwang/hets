﻿using System;
using Newtonsoft.Json;

namespace HetsData.Model
{
    public partial class HetImportMap
    {
        [JsonProperty("Id")]
        public int ImportMapId { get; set; }

        public DateTime DbCreateTimestamp { get; set; }
        public string AppCreateUserDirectory { get; set; }
        public DateTime DbLastUpdateTimestamp { get; set; }
        public string AppLastUpdateUserDirectory { get; set; }
        public int NewKey { get; set; }
        public string NewTable { get; set; }
        public string OldKey { get; set; }
        public string OldTable { get; set; }
        public DateTime AppCreateTimestamp { get; set; }
        public string AppCreateUserGuid { get; set; }
        public string AppCreateUserid { get; set; }
        public DateTime AppLastUpdateTimestamp { get; set; }
        public string AppLastUpdateUserGuid { get; set; }
        public string AppLastUpdateUserid { get; set; }
        public string DbCreateUserId { get; set; }
        public string DbLastUpdateUserId { get; set; }
        public int ConcurrencyControlNumber { get; set; }
    }
}
