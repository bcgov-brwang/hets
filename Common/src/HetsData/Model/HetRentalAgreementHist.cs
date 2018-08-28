﻿using System;
using Newtonsoft.Json;

namespace HetsData.Model
{
    public partial class HetRentalAgreementHist
    {
        public int RentalAgreementHistId { get; set; }
        public int RentalAgreementId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EquipmentId { get; set; }
        public int? ProjectId { get; set; }
        public string Status { get; set; }
        [JsonIgnore]public DateTime DbCreateTimestamp { get; set; }
        [JsonIgnore]public string AppCreateUserDirectory { get; set; }
        public DateTime? DatedOn { get; set; }
        public float? EquipmentRate { get; set; }
        public int? EstimateHours { get; set; }
        public DateTime? EstimateStartWork { get; set; }
        [JsonIgnore]public DateTime DbLastUpdateTimestamp { get; set; }
        [JsonIgnore]public string AppLastUpdateUserDirectory { get; set; }
        public string Note { get; set; }
        public string Number { get; set; }
        public string RateComment { get; set; }
        public string RatePeriod { get; set; }
        public int ConcurrencyControlNumber { get; set; }
        [JsonIgnore]public DateTime AppCreateTimestamp { get; set; }
        [JsonIgnore]public string AppCreateUserGuid { get; set; }
        [JsonIgnore]public string AppCreateUserid { get; set; }
        [JsonIgnore]public DateTime AppLastUpdateTimestamp { get; set; }
        [JsonIgnore]public string AppLastUpdateUserGuid { get; set; }
        [JsonIgnore]public string AppLastUpdateUserid { get; set; }
        [JsonIgnore]public string DbCreateUserId { get; set; }
        [JsonIgnore]public string DbLastUpdateUserId { get; set; }
    }
}
