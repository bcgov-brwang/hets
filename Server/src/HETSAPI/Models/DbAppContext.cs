using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HETSAPI.Models
{
    /// <summary>
    /// Database Context Factory Interface
    /// </summary>
    public interface IDbAppContextFactory
    {
        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns></returns>
        IDbAppContext Create();
    }

    /// <summary>
    /// Database Context Factory
    /// </summary>
    public class DbAppContextFactory : IDbAppContextFactory
    {
        readonly DbContextOptions<DbAppContext> _options;
        readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Database Context Factory Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="options"></param>
        public DbAppContextFactory(IHttpContextAccessor httpContextAccessor, DbContextOptions<DbAppContext> options)
        {
            _options = options;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns></returns>
        public IDbAppContext Create()
        {
            return new DbAppContext(_httpContextAccessor, _options);
        }
    }

    /// <summary>
    /// Database Context Interface
    /// </summary>
    public interface IDbAppContext
    {
        /// <summary>
        /// Attachment
        /// </summary>
        DbSet<Attachment> Attachments { get; set; }

        /// <summary>
        /// City
        /// </summary>
        DbSet<City> Cities { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// District
        /// </summary>
        DbSet<District> Districts { get; set; }

        /// <summary>
        /// District Equipment Type (district specific equipment subtypes)
        /// </summary>
        DbSet<DistrictEquipmentType> DistrictEquipmentTypes { get; set; }

        /// <summary>
        /// Dump Truck (subtype if Equipment)
        /// </summary>
        DbSet<DumpTruck> DumpTrucks { get; set; }

        /// <summary>
        /// Equipment
        /// </summary>
        DbSet<Equipment> Equipments { get; set; }

        /// <summary>
        /// Equipment Attachment 
        /// </summary>
        DbSet<EquipmentAttachment> EquipmentAttachments { get; set; }   
        
        /// <summary>
        /// Equipment Type
        /// </summary>
        DbSet<EquipmentType> EquipmentTypes { get; set; }     
        
        /// <summary>
        /// Group
        /// </summary>
        DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Group Membership
        /// </summary>
        DbSet<GroupMembership> GroupMemberships { get; set; }        

        /// <summary>
        /// History (log of activity)
        /// </summary>
        DbSet<History> Historys { get; set; }

        /// <summary>
        /// Import Map
        /// </summary>
        DbSet<ImportMap> ImportMaps { get; set; }

        /// <summary>
        /// Local Area
        /// </summary>
        DbSet<LocalArea> LocalAreas { get; set; }

        /// <summary>
        /// Local Area Rotation List
        /// </summary>
        DbSet<LocalAreaRotationList> LocalAreaRotationLists { get; set; }

        /// <summary>
        /// Lookup List
        /// </summary>
        DbSet<LookupList> LookupLists { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Permission
        /// </summary>
        DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Project
        /// </summary>
        DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Rental Agreement
        /// </summary>
        DbSet<RentalAgreement> RentalAgreements { get; set; }

        /// <summary>
        /// Rental Agreement Condition
        /// </summary>
        DbSet<RentalAgreementCondition> RentalAgreementConditions { get; set; }

        /// <summary>
        /// Rental Agreement Rate
        /// </summary>
        DbSet<RentalAgreementRate> RentalAgreementRates { get; set; }

        /// <summary>
        /// Rental Request
        /// </summary>
        DbSet<RentalRequest> RentalRequests { get; set; }

        /// <summary>
        /// Rental Request Attachment (document)
        /// </summary>
        DbSet<RentalRequestAttachment> RentalRequestAttachments { get; set; }

        /// <summary>
        /// Rental Request Rotation List
        /// </summary>
        DbSet<RentalRequestRotationList> RentalRequestRotationLists { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Role Permissions
        /// </summary>
        DbSet<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Seniority Audit
        /// </summary>
        DbSet<SeniorityAudit> SeniorityAudits { get; set; }

        /// <summary>
        /// Service Area
        /// </summary>
        DbSet<ServiceArea> ServiceAreas { get; set; }

        /// <summary>
        /// Time Record
        /// </summary>
        DbSet<TimeRecord> TimeRecords { get; set; }

        /// <summary>
        /// User
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        /// User Favourite
        /// </summary>
        DbSet<UserFavourite> UserFavourites { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Starts a new transaction.
        /// </summary>
        /// <returns>
        /// A Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction that represents
        /// the started transaction.
        /// </returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Save changes to the database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }

    /// <summary>
    /// Database Context Interface
    /// </summary>
    public class DbAppContext : DbContext, IDbAppContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor for Class used for Entity Framework access.
        /// </summary>
        public DbAppContext(IHttpContextAccessor httpContextAccessor, DbContextOptions<DbAppContext> options)
                                : base(options)
        {
            _httpContextAccessor = httpContextAccessor;

            // override the default timeout as some operations are time intensive
            Database?.SetCommandTimeout(180);
        }

        /// <summary>
        /// Override for OnModelCreating - used to change the database naming convention.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add our naming convention extension
            modelBuilder.UpperCaseUnderscoreSingularConvention();
        }
        
        /// <summary>
        /// Attachment
        /// </summary>
        public virtual DbSet<Attachment> Attachments { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public virtual DbSet<City> Cities { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        public virtual DbSet<Contact> Contacts { get; set; }        

        /// <summary>
        /// District
        /// </summary>
        public virtual DbSet<District> Districts { get; set; }

        /// <summary>
        /// Dump Truck (subtype of Equipment)
        /// </summary>
        public virtual DbSet<DumpTruck> DumpTrucks { get; set; }

        /// <summary>
        /// Equipment
        /// </summary>
        public virtual DbSet<Equipment> Equipments { get; set; }

        /// <summary>
        /// Equipment Attachment (hardware attached to the Equipment)
        /// </summary>
        public virtual DbSet<EquipmentAttachment> EquipmentAttachments { get; set; }

        /// <summary>
        /// District Equipment Type (subtype of Equipment by District)
        /// </summary>
        public virtual DbSet<DistrictEquipmentType> DistrictEquipmentTypes { get; set; }

        /// <summary>
        /// Equipment Type
        /// </summary>
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Group Membership
        /// </summary>
        public virtual DbSet<GroupMembership> GroupMemberships { get; set; }

        /// <summary>
        /// History (activity log)
        /// </summary>
        public virtual DbSet<History> Historys { get; set; }

        /// <summary>
        /// IMport Map
        /// </summary>
        public virtual DbSet<ImportMap> ImportMaps { get; set; }

        /// <summary>
        /// Local Area
        /// </summary>
        public virtual DbSet<LocalArea> LocalAreas { get; set; }

        /// <summary>
        /// Local Area Rotation List
        /// </summary>
        public virtual DbSet<LocalAreaRotationList> LocalAreaRotationLists { get; set; }

        /// <summary>
        /// Lookup List
        /// </summary>
        public virtual DbSet<LookupList> LookupLists { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public virtual DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Permission
        /// </summary>
        public virtual DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Project
        /// </summary>
        public virtual DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public virtual DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Rental Agreement
        /// </summary>
        public virtual DbSet<RentalAgreement> RentalAgreements { get; set; }

        /// <summary>
        /// Rental Agreement Condition
        /// </summary>
        public virtual DbSet<RentalAgreementCondition> RentalAgreementConditions { get; set; }

        /// <summary>
        /// Rental Agreement Rate
        /// </summary>
        public virtual DbSet<RentalAgreementRate> RentalAgreementRates { get; set; }

        /// <summary>
        /// Rental Request
        /// </summary>
        public virtual DbSet<RentalRequest> RentalRequests { get; set; }

        /// <summary>
        /// Rental Request Attachment (document)
        /// </summary>
        public virtual DbSet<RentalRequestAttachment> RentalRequestAttachments { get; set; }

        /// <summary>
        /// Rental Request Rotation List
        /// </summary>
        public virtual DbSet<RentalRequestRotationList> RentalRequestRotationLists { get; set; }       
        
        /// <summary>
        /// Role
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Role Permission
        /// </summary>
        public virtual DbSet<RolePermission> RolePermissions { get; set; }   
        
        /// <summary>
        /// Seniority Audit
        /// </summary>
        public virtual DbSet<SeniorityAudit> SeniorityAudits { get; set; }

        /// <summary>
        /// Service Area
        /// </summary>
        public virtual DbSet<ServiceArea> ServiceAreas { get; set; }

        /// <summary>
        /// Time Record
        /// </summary>
        public virtual DbSet<TimeRecord> TimeRecords { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// User Favourite
        /// </summary>
        public virtual DbSet<UserFavourite> UserFavourites { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        public virtual DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Starts a new transaction.
        /// </summary>
        /// <returns>
        /// A Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction that represents
        /// the started transaction.
        /// </returns>
        public virtual IDbContextTransaction BeginTransaction()
        {
            bool existingTransaction = true;

            IDbContextTransaction transaction = Database.CurrentTransaction;

            if (transaction == null)
            {
                existingTransaction = false;
                transaction = Database.BeginTransaction();
            }

            return new DbContextTransactionWrapper(transaction, existingTransaction);
        }

        /// <summary>
        /// Returns the current web user
        /// </summary>
        protected ClaimsPrincipal HttpContextUser => _httpContextAccessor.HttpContext.User;

        /// <summary>
        /// Returns the current user ID 
        /// </summary>
        /// <returns></returns>
        protected string GetCurrentUserId()
        {
            string result;

            try
            {
                result = HttpContextUser.FindFirst(ClaimTypes.Name).Value;
            }
            catch
            {
                result = null;
            }

            return result;
        }

        Object getOriginalValue (EntityEntry entry, string fieldName)
        {
            Object result = null;
            var property = entry.Metadata.FindProperty(fieldName);
            if (property != null)
            {
                result = entry.OriginalValues[fieldName];
            }
            return result;
        }

        private void DoEquipmentAudit(List<SeniorityAudit> audits, EntityEntry entry , string smUserId)
        {
            Equipment changed = (Equipment)entry.Entity;

            Equipment original = new Equipment
            {
                SeniorityEffectiveDate = (DateTime?) getOriginalValue(entry, "SeniorityEffectiveDate"),
                Seniority = (float?) getOriginalValue(entry, "Seniority"),
                LocalArea = (LocalArea) getOriginalValue(entry, "LocalArea"),
                BlockNumber = (int?) getOriginalValue(entry, "BlockNumber"),
                Owner = (Owner) getOriginalValue(entry, "Owner"),
                ServiceHoursLastYear = (float?) getOriginalValue(entry, "ServiceHoursLastYear"),
                ServiceHoursTwoYearsAgo = (float?) getOriginalValue(entry, "ServiceHoursTwoYearsAgo"),
                ServiceHoursThreeYearsAgo = (float?) getOriginalValue(entry, "ServiceHoursThreeYearsAgo")
            };

            // Calculate Seniority.  In the current UI design it is expected that this occurs after each change to the service hours.
            changed.CalculateSeniority();                        

            // compare the old and new
            if (changed.IsSeniorityAuditRequired (original))
            {
                DateTime currentTime = DateTime.UtcNow;

                // create the audit entry.
                SeniorityAudit seniorityAudit = new SeniorityAudit
                {
                    BlockNumber = original.BlockNumber,
                    EndDate = currentTime
                };

                changed.SeniorityEffectiveDate = currentTime;
                seniorityAudit.Equipment = changed;
                seniorityAudit.CreateTimestamp = currentTime;
                seniorityAudit.LastUpdateTimestamp = currentTime;
                seniorityAudit.CreateUserid = smUserId;
                seniorityAudit.LastUpdateUserid = smUserId;
                seniorityAudit.LocalArea = original.LocalArea;
                seniorityAudit.Owner = original.Owner;

                if (seniorityAudit.Owner != null)
                {
                    seniorityAudit.OwnerOrganizationName = seniorityAudit.Owner.OrganizationName;
                }

                if (original.SeniorityEffectiveDate != null)
                {
                    seniorityAudit.StartDate = (DateTime) original.SeniorityEffectiveDate;
                }

                seniorityAudit.Seniority = original.Seniority;
                seniorityAudit.ServiceHoursLastYear = original.ServiceHoursLastYear;
                seniorityAudit.ServiceHoursTwoYearsAgo = original.ServiceHoursTwoYearsAgo;
                seniorityAudit.ServiceHoursThreeYearsAgo = original.ServiceHoursThreeYearsAgo;

                audits.Add(seniorityAudit);
            }
        }

        /// <summary>
        /// Override for Save Changes to implement the audit log
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            // update the audit fields for this item.
            string smUserId = null;
            if (_httpContextAccessor != null)
                smUserId = GetCurrentUserId();

            var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            DateTime currentTime = DateTime.UtcNow;

            List<SeniorityAudit> seniorityAudits = new List<SeniorityAudit>();

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity.GetType().InheritsOrImplements(typeof(AuditableEntity)))
                {
                    var theObject = (AuditableEntity)entry.Entity;

                    theObject.LastUpdateUserid = smUserId;
                    theObject.LastUpdateTimestamp = currentTime;

                    if (entry.State == EntityState.Added)
                    {
                        theObject.CreateUserid = smUserId;
                        theObject.CreateTimestamp = currentTime;
                    }
                }

                if (entry.Entity.GetType().InheritsOrImplements(typeof(Equipment)))
                {
                    DoEquipmentAudit(seniorityAudits, entry, smUserId);
                }                    
            }            

            int result = base.SaveChanges();

            if (seniorityAudits.Count > 0)
            {
                foreach (SeniorityAudit seniorityAudit in seniorityAudits)
                {
                    SeniorityAudits.Add(seniorityAudit);
                }
            }

            base.SaveChanges();

            return result;
        }

        /// <summary>
        /// This is for importing data only
        /// </summary>
        /// <returns></returns>
        public int SaveChangesForImport()
        {
            // update the audit fields for this item.
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            int result = base.SaveChanges();

            return result;
        }
    }
}