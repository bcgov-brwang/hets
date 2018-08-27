﻿using System;
using System.Collections.Generic;

namespace HetsData.Model
{
    public partial class HetContact
    {
        public HetContact()
        {
            HetOwner = new HashSet<HetOwner>();
            HetProject = new HashSet<HetProject>();
        }

        public int ContactId { get; set; }
        public string GivenName { get; set; }
        public string Notes { get; set; }
        public int? OwnerId { get; set; }
        public int? ProjectId { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public DateTime DbCreateTimestamp { get; set; }
        public string AppCreateUserDirectory { get; set; }
        public string EmailAddress { get; set; }
        public string FaxPhoneNumber { get; set; }
        public DateTime DbLastUpdateTimestamp { get; set; }
        public string AppLastUpdateUserDirectory { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string WorkPhoneNumber { get; set; }
        public DateTime AppCreateTimestamp { get; set; }
        public string AppCreateUserGuid { get; set; }
        public string AppCreateUserid { get; set; }
        public DateTime AppLastUpdateTimestamp { get; set; }
        public string AppLastUpdateUserGuid { get; set; }
        public string AppLastUpdateUserid { get; set; }
        public string DbCreateUserId { get; set; }
        public string DbLastUpdateUserId { get; set; }
        public int ConcurrencyControlNumber { get; set; }

        public HetOwner Owner { get; set; }
        public HetProject Project { get; set; }
        public ICollection<HetOwner> HetOwner { get; set; }
        public ICollection<HetProject> HetProject { get; set; }
    }
}