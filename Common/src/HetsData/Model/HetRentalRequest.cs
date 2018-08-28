﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HetsData.Model
{
    public partial class HetRentalRequest
    {
        public HetRentalRequest()
        {
            HetAttachment = new HashSet<HetAttachment>();
            HetHistory = new HashSet<HetHistory>();
            HetNote = new HashSet<HetNote>();
            HetRentalRequestAttachment = new HashSet<HetRentalRequestAttachment>();
            HetRentalRequestRotationList = new HashSet<HetRentalRequestRotationList>();
        }

        [JsonProperty("Id")]
        public int RentalRequestId { get; set; }

        public int EquipmentCount { get; set; }
        public int? DistrictEquipmentTypeId { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public int? ExpectedHours { get; set; }
        public DateTime? ExpectedStartDate { get; set; }
        public int? FirstOnRotationListId { get; set; }
        public int? LocalAreaId { get; set; }
        public int? ProjectId { get; set; }
        public string Status { get; set; }
        [JsonIgnore]public DateTime DbCreateTimestamp { get; set; }
        [JsonIgnore]public string AppCreateUserDirectory { get; set; }
        [JsonIgnore]public DateTime DbLastUpdateTimestamp { get; set; }
        [JsonIgnore]public string AppLastUpdateUserDirectory { get; set; }
        [JsonIgnore]public DateTime AppCreateTimestamp { get; set; }
        [JsonIgnore]public string AppCreateUserGuid { get; set; }
        [JsonIgnore]public string AppCreateUserid { get; set; }
        [JsonIgnore]public DateTime AppLastUpdateTimestamp { get; set; }
        [JsonIgnore]public string AppLastUpdateUserGuid { get; set; }
        [JsonIgnore]public string AppLastUpdateUserid { get; set; }
        [JsonIgnore]public string DbCreateUserId { get; set; }
        [JsonIgnore]public string DbLastUpdateUserId { get; set; }
        public int ConcurrencyControlNumber { get; set; }

        public HetDistrictEquipmentType DistrictEquipmentType { get; set; }
        public HetEquipment FirstOnRotationList { get; set; }
        public HetLocalArea LocalArea { get; set; }
        public HetProject Project { get; set; }

        [JsonIgnore]
        public ICollection<HetAttachment> HetAttachment { get; set; }

        [JsonIgnore]
        public ICollection<HetHistory> HetHistory { get; set; }

        [JsonIgnore]
        public ICollection<HetNote> HetNote { get; set; }

        [JsonIgnore]
        public ICollection<HetRentalRequestAttachment> HetRentalRequestAttachment { get; set; }

        [JsonIgnore]
        public ICollection<HetRentalRequestRotationList> HetRentalRequestRotationList { get; set; }
    }
}
