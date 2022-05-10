## Legacy Export Files ##

The legacy export contains the following files, in a zip file. This list is in data conversion order by XML file

| Source XML | Size | Records | Analysis Needed | Notes | 
| ---------- | ---- | ------- | -------- | ----- | 
| User_HETS.xml | 327273 | 889 | Y | Load User, UserRoles, GroupMembership. Look at the different user "authority" in the system to enable populating group and role memberships. |
| Area.xml | 40952 | 160 | Y | Local Area List | 
| HETS_City.xml | 13390 | 100 |  |  | 
| Equip_Type.xml | 1329315 | 1887 | Y | Need to populate g;obal equipment type table and then a per district list, merging lists from Service Areas. | 
| Owner.xml | 5020004 | 4836 |  | Loads a record into Owner, Contact and Note | 
| Project.xml | 55070 | 159 | Y | Merge Service Area level data to District Level | 
| Equip.xml | 39524196 | 25287 |  |  | 
| Dump_Truck.xml | 7144372 | 6300 | Y | Review the number of populated records | 
| Equip_Attach.xml | 10193366 | 37776 | Y | Loads DistrictEquipmentType. Need to assess the data to see how to load EquipmentType as well. | 
| Seniority_Audit.xml | TBD | TBD |  | Not yet received. Should map to HETS Seniority Audit table. | 
| Block.xml | 7635156 | 13563 |  |  | 
| Equip_Usage.xml | 52667405 | 95897 |  |  | 
| Rotation_Doc.xml | 10061865 | 26844 | Y | Could be used for populating RequestRotationList if the data is consistent enough. However - doesn't seem to be. | 
| Service_Area.xml | 24977 | 29 | Y | Do not convert - only need to verify the BCBid data matches existing HETS data | 
| HETS_Audit.xml | 9222772 | 43392 | Y | Is there any data of value in this table? It appears not.| 
| HETS_Shift.xml | 0 | 0 |  |  | 
| List_Resource.xml | 0 | 0 |  |  | 


# Mappings #

## Area ##

| Legacy Field    | New Object | New Field       | Notes |
| ------------    | ---------- | ---------       | ----- |
| Area_Id         | N/A        |                 | ID will be generated in new table.|
| Area_Cd         | LocalArea  | LocalAreaNumber                 |       |
| Area_Desc       | LocalArea  | Name            |       |
| Service_Area_Id | LocalArea  | ServiceArea     | Need to make FK to the Service Area table. | 
| Created_Dt      | LocalArea  | CreateTimestamp |       |
| Created_By      | LocalArea  | CreateUserid    |       |
|                 | LocalArea  | startDate       | Constant Date - Jan. 1, 2017 |
|                 | LocalArea  | endDate         | Constant Null |


## Block ##

*NOTE*: Need to review the format.  The Postgres table is denormalized, multiple records of the Block.xml source file will map to a single record in the Postgres table.



| Legacy Field        | New Object | New Field       | Notes |
| ------------        | ---------- | ---------       | ----- |
|                     | LocalAreaRotationList | id                | Generated by Postgres |
| Area_Id             | LocalAreaRotationList | localArea         | FK Mapping from Area_ID to Postgres LocalAreaId |
| Equip_Type_Id       | LocalAreaRotationList | districtEquipmentType |       |
| Block_Num           | LocalAreaRotationList |                 | Used to select which field in the Postgres table to map |
| Cycle_Num           |            |                 | Not used in the HETS system |
| Max_Cycle           |            |                 | Not used in the HETS system |
| Last_Hired_Equip_Id | LocalAreaRotationList | askNextBlock1, askNextBlock2, askNextBlock3 | Which field to populate depends on XML Block_Num field |
| Block_Name          |            |                 | TBD what this field means |
| Closed              |            |                 | Not used in the HETS system |
| Closed_Comments     |            |                 |       |
| Created_Dt          | LocalAreaRotationList |                 |       |
| Created_By          | LocalAreaRotationList |                 |       |

## Equip ##

| Legacy Field        | New Table | New Field          | Notes |
| ------------        | --------- | ---------          | ----- |
| Equip_Id            |           |
| Area_Id             | Equipment | LocalArea | Find FK in the HETS LocalArea table via the XML ID |
| Equip_Type_Id       | Equipment | EquipmentType | Find FK in the HETS DistrictEquipmentType Table via the XML ID |
| Owner_Popt_Id       | Equipment | Owner | Find FK in the HETS Owner Table via the XML ID |
| Equip_Cd            | N/A       |  | Primary Key will be generated by Postgres |
| Approved_Dt         | Equipment | ApprovedDate | |
| Received_Dt         | Equipment | ReceivedDate | |
| Addr1               |           |  | TBD - should we create a contact record for this? |
| Addr2               |           |  | TBD - If we do add a contact record - how do we prevent duplicates? |
| Addr3               |           |  | |
| Addr4               |           |  | |
| City                |           |  | |
| Postal              |           |  | |
| Block_Num           | Equipment | BlockNumber | TBD - need to see for the format of the BlockNumber |
| Comment             | Notes | Text | Need to link the new Note to the Equipment ID |
| Cycle_Hrs_Wrk       |  | | TBD - Need to look at the data.  Likely not needed. |
| Frozen_Out          |  | | Per the Business - not needed in the new HETS |
| Last_Dt             |  | | TBD - what is this field? Not in table definition we received. | 
| Licence             | Equipment | LicensePlate
| Make                | Equipment | Make
| Model               | Equipment | Model
| Year                | Equipment | Year
| Type                | Equipment | Type
| Num_Years           |  | | Calculated field in the new HETS - FY Start - ApprovedDate |
| Operator            | Equipment | Operator
| Pay_Rate            | Equipment | PayRate
| Project_Id          | | | Not tracked in the new HETS with the Equipment |
| Refuse_Rate         | | | Per the Business - field to be removed in new HETS |
| Seniority           | Equipment | Seniority
| Serial_Num          | Equipment | SerialNumber
| Size                | Equipment | Size
| Working             | Equipment | isHired | Field to be added - Defines when a piece of equipment has been hired. | 
| Year_End_Reg        | | | Per business - not needed in the new HETS |
| Prev_Reg_Area       | | | TBD - how to move a piece of equipment to a new area. |
| YTD                 | | | Calculated field in the new HETS - sum of work hours across Time Records. |
| YTD1                | Equipment | serviceHoursLastYear | |
| YTD2                | Equipment | serviceHoursTwoYearsAgo | |
| YTD3                | Equipment | serviceHoursThreeYearsAgo | |
| Status_Cd           | Equipment | Status | TBD - Need to look at old values |
| Archive_Cd          | Equipment | ArchiveCode |
| Archive_Reason      | Equipment | ArchiveReason |
| Reg_Dump_Trk        | 
| Created_Dt          | Equipment | CreateTimestamp
| Created_By          | Equipment | CreateUserid
| Modified_Dt         |
| Modified_By         |

## EquipAttach ##

NOTE: We would like to review the data to see about creating a global list of generic attachment types and linking the specific attachments for equipment
to those.  If a pattern is found, there will be a mapping developed between these records and the global list of attachments (which will be in a new HETS table).

NOTE: The combination "Equip_ID" + "Attach_Seq_Num" must be used as the "OldKey" in the ImportMap table.

| Legacy Field        | New Table           | New Field            | Notes |
| ------------        | ---------           | ---------            | ----- |
| Equip_Id            | EquipmentAttachment | Equipment | Find FK in the HETS Equipment Table via the XML ID |
| Attach_Seq_Num      | N/A |            | ID for the record will be generated by Postgres |
| Attach_Desc         | EquipmentAttachment | Description          |       |
| Created_Dt          | EquipmentAttachment | CreateTimestamp      |       |
| Created_By          | EquipmentAttachment | CreateUserid         |       |

## EquipType ##

*NOTE*: The HETS EQUIP_TYPE table contains a global, generic list of EQUIP_TYPES.  The HETS DISTRICT_EQUIPMENT_TYPE table will be the true target of the XML source. 

*Note*: The XML table is set at the Service Area level and in the new application, we would like it mapped at the District level, so a mapping is needed to apply that change. An interim, hand-constructed oldkey/newkey mapping may be needed to handle that.

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Equip_Type_Id          | 
| SubSystem_Id           | 
| Service_Area_Id        | DistrictEquipmentType       | District | Find FK in the HETS ServiceArea Table via the XML ID, then find the FK for the parent District of the service area.|
| Equip_Type_Cd          | DistrictEquipmentType       | Name
| Equip_Type_Desc        | DistrictEquipmentType       | Description
| Equip_Rental_Rate_No   | EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Equip_Rental_Rate_Page | EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Max_Hours              | EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Extend_Hours           |        |  | Not Needed |
| Max_Hours_Sub          |        |  | Not Needed |
| Second_Blk             | EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Created_Dt             |        |  | Not Needed |
| Created_Dt             |        |  | Not Needed |



## Dump_Truck ##

| Legacy Field          | New Table           | New Field       | Notes |
| ------------          | ---------           | ---------       | ----- |
| Equip_Id				| 
| Single_Axle           | 
| Tandem_Axle			| DistrictEquipmentType       | District | Find FK in the HETS ServiceArea Table via the XML ID, then find the FK for the parent District of the service area.|
| PUP					| DistrictEquipmentType       | Name
| Belly_Dump			| DistrictEquipmentType       | Description
| Tridem				| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Rock_Box				| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Hilift_Gate			| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Water_Truck           |        |  | Not Needed |
| Seal_Coat_Hitch		|        |  | Not Needed |
| Rear_Axle_Spacing		| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Front_Tire_Size		|        |  | Not Needed |
| Front_Tire_UOM		|        |  | Not Needed |
| Front_Axle_Capacity	| 
| Rare_Axle_Capacity	| 
| Legal_Load			| DistrictEquipmentType       | District | Find FK in the HETS ServiceArea Table via the XML ID, then find the FK for the parent District of the service area.|
| Legal_Capacity		| DistrictEquipmentType       | Name
| Legal_PUP_Tare_Weight	| DistrictEquipmentType       | Description
| Licenced_GVW			| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Licenced_GVW_UOM		| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Licenced_Tare_Weight	| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Licenced_PUP_Tare_Weight|        |  | Not Needed |
| Licenced_Load			|        |  | Not Needed |
| Licenced_Capacity		| EquipType       | TBD | TBD - Need to look at the data to see how best to map this. |
| Box_Length			|        |  | Not Needed |
| Box_Width				|        |  | Not Needed |
| Box_Height			|        |  | Not Needed |
| Box_Capacity			|        |  | Not Needed |
| Trailer_Box_Length	|        |  | Not Needed |
| Trailer_Box_Width		|        |  | Not Needed |
| Trailer_Box_Height	|        |  | Not Needed |
| Trailer_Box_Capacity	|        |  | Not Needed |


"DUMP_TRUCK_ID", "BOX_CAPACITY", "BOX_HEIGHT", "BOX_LENGTH", 
       "BOX_WIDTH", "FRONT_AXLE_CAPACITY", "FRONT_TIRE_SIZE", "FRONT_TIRE_UOM", 
       "LEGAL_CAPACITY", "LEGAL_LOAD", "LEGAL_PUPTARE_WEIGHT", "LICENCED_CAPACITY", 
       "LICENCED_GVW", "LICENCED_GVWUOM", "LICENCED_LOAD", "LICENCED_PUPTARE_WEIGHT", 
       "LICENCED_TARE_WEIGHT", "REAR_AXLE_CAPACITY", "REAR_AXLE_SPACING", 
       "TRAILER_BOX_CAPACITY", "TRAILER_BOX_HEIGHT", "TRAILER_BOX_LENGTH", 
       "TRAILER_BOX_WIDTH", "HAS_BELLY_DUMP", "HAS_HILIFT_GATE", "HAS_PUP", 
       "HAS_ROCK_BOX", "HAS_SEALCOAT_HITCH", "IS_SINGLE_AXLE", "IS_TANDEM_AXLE", 
       "IS_TRIDEM", "IS_WATER_TRUCK", "CREATE_TIMESTAMP", "CREATE_USERID", 
       "LAST_UPDATE_TIMESTAMP", "LAST_UPDATE_USERID"

## EquipUsage ##

*Note*: In the new HETS design, we have the "RentalAgreement" record through which we can get the links to Equip_Id and Project_Id. 
If we use that, RentalAgreement records will be created from groups of EquipUsage records with common key of Equip_Id+Project_Id (+ possibly Year(Worked_Dt)).

Alternatively, we simply add "Equip_Id" and "Project_Id" fields to the 


| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Equip_Id               | TimeRecord          | Equipment | TBD - we have to decide if we create historical RentalAgreement records or 
| Project_Id             | TimeRecord          | Project   | TBD - those fields are not currently in the data definition |
|                        | TimeRecord          | RentalAgreement | TBD - How to map from the XML Key Fields (and possibly date) to a RentalAgreement Record
| Service_Area_Id        | 
| Worked_Dt              | TimeRecord          | WorkedDate
| Entered_Dt             | TimeRecord          | EnteredDate
| Hours                  | TimeRecord          | Hours
| Rate                   | TimeRecord          | RentalAgreementRate
| Hours2                 | TimeRecord          | Hours
| Rate2                  | TimeRecord          | RentalAgreementRate
| Hours3                 | TimeRecord          | Hours
| Rate3                  | TimeRecord          | RentalAgreementRate
| Created_Dt             | TimeRecord          | CreateTimestamp
| Created_By             | TimeRecord          | CreateUserid

## HETS_Audit ##

*NOTE:* The XML for this table is empty, and it is unlikely that we will be able to use this data anyway - it's at too low a level.

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Created_By             |
| Created_Dt             |
| Action                 |
| Reason                 |

## HETS_City ##

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Service_Area_Id        |                     |                 |       |
| Seq_Num                |                     |                 |       |
|                        | City                | Id              | Generated by Postgres |
| City                   | City                | Name            |       |


## Owner ##

NOTE: The Owner XML file will generated a record in each of three tables during the process - one in Owner, one in Contact and one in Notes.

| Legacy Field             | New Table           | New Field       | Notes |
| ------------             | ---------           | ---------       | ----- |
| Popt_Id                  | User                | TBD             | If we want to convert existing accounts from the old system to the new (not likely we do), a field in the User table would link a user record to an Owner |
| Area_Id                  | Owner               | LocalArea
| Owner_Cd                 | Owner               | ownerEquipmentCodePrefix |
| Owner_First_Name         | Owner               | OrganizationName | Concatonate Owner_Last_Name + ", " + Owner_First_Name |
| Owner_Last_Name          | Owner               | OrganizationName
| Owner_First_Name         | Contact             | OrganizationName | Concatonate Owner_Last_Name + ", " + Owner_First_Name |
| Owner_Last_Name          | Contact             | OrganizationName, OwenrID to newkey, all other fields to NULL; Owner-> PrimaryContact  set to Contact newkey |
| Contact_Person           |                     | | TBD - Need to review the data to see if there is anything useful in this data element |
| Local_To_Area            |                | | We won't use this - a constant True will go into the "meetsResidency" field. |
| Maintenance_Contractor   | Owner               | IsMaintenanceContractor
| Comment                  | Notes               | Text |Other fields in Notes table - OwnerID to NewKey, isNoLongerRelevant to FALSE |
| WCB_Num                  | Owner               | workSafeBCPolicyNumber
| WCB_Expiry_Dt            | Owner               | workSafeBCExpiryDate
| CGL_company              | | | Not converted |
| CGL_Policy               | | | Not converted |
| CGL_Start_Dt             | | | Not converted |
| CGL_End_Dt               | Owner               | CGLEndDate
| Status_Cd                | Owner               | Status
| Archive_Cd               | Owner               | ArchiveCode
| Service_Area_Id          | | | Not converted |
| Selected_Service_Area_Id | | | Not converted |
| Created_By               | Owner               |
| Created_Dt               | Owner               |
| Modified_By              | Owner               |
| Modified_Dt              | Owner               |



## Project ##

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Project_Id             || Service_Area_Id        | Project             | LocalArea
| Project_Num            | Project             | ProvincialProjectNumber 
| Job_Desc1              | Project             | Name
| Job_Desc2              | Project             | Notes
| Created_Dt             | Project             | CreateTimestamp
| Created_By             | Project             

## Rotation_Doc ##

*Note*: Need to investigate this XML file to determine the format and how to map it. It appears to map to the RentalRequestRotationList, but it does not have the transactional data that is expected.

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Equip_Id               |
| Note_Dt                |
| Created_Dt             |
| Service_Area_Id        | 
| Project_Id             |
| Note_Type              |
| Reason                 |
| Note_Id                |
| Created_By             |

## Service_Area ##

*Note*: This table will not be mapped. Instead - we need to verify that the table matches up with the one from School Bus. It will be loaded with the JSON files via the API as part 2 of the start up process.

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- |
| Service_Area_Id        | 
| Service_Area_Cd        |          | 
| Service_Area_Desc      |          | 
| District_Area_Id       |          | 
| Last_Year_End_Shift    |                     |  
| Address                |                     | 
| Phone                  |                     |
| Fax                    |                     | 
| FiscalStart            |          | 
| FiscalEnd              |                     |
| Created_Dt             |          |       
| Created_By             |          | 

## User_HETS ##

*NOTE*: Only load users that have IDIR IDs. There may be BCBid users - they will not be converted, and BCeID users - they could be, but again, will not.  We may get a list of the non-converted users for the Business to work with. In necessary, we'll load those users via the API process.

*NOTE*: Based on the Authority, UserRole and GroupMembership records will be created for the user.  Investigation needed to determine the authorities in BCBid, what they mean and to what Roles/Groups they should be mapped.

| Legacy Field           | New Table           | New Field       | Notes |
| ------------           | ---------           | ---------       | ----- | 
| Popt_ID                | 
| Service_Area_Id        | User                | District | Need to convert Service ID to it's parent District |
| User_Cd                | User                | SmUserId
| User_Cd                | User                | SmAuthorizationDirectory | Only load users from IDIR. BCeID users COULD be converted, but we probably won't. |
| Authority              | User, GroupMembership | UserRoles, GroupMembership | Mapping to be determined. Likely only 2 types of users - Admin and HETS Clerk. |
| Default_Service_Area   | 
| Created_Dt             | User                |    
| Created_By             | User                |    
| Modified_Dt            | User                |
| Modified_By            | User                | 

# Flow #

- Load process starts the first time with the database empty
- The Server starting up creates the Database schema
- Secrets are loaded into the new database
- An Admin user runs an API script to load fixed data into database tables from generated JSON files
- An authorized user initiates the first import process - via an API call passing in the location of the unzipped files and a list of all the Districts in the system - converting all XML data
- Load order is as defined in the table at the top of this Readme.
- Time passes and the system is used by one District
- ...
- Time for another District to go live on the system
- START OF LOOP
- The BCBid Data is exported, prepared, delivered and upzipped on the HETS server
- An authorized user initiates the next import process - via an API call passing in the location of the unzipped files and a list of all the Districts in the system EXCEPT for the District(s) already live
- Time passes until it's time to go live with another district
- LOOP until all Districts are live on HETS



-- commented out sections from BCBidImport:
//*** start by importing Region from Region.xml. THis goes to table HETS_REGION
//***[ImportRegion.Import(context, dbContext, fileLocation, systemId);]

//*** start by importing districts from District.xml. THis goes to table HETS_DISTRICT
// dbContext = new DbAppContext(null, options.Options);
// ImportDistrict.Import(context, dbContext, fileLocation, systemId);

//*** start by importing Cities from HETS_City.xml to HET_CITY
//dbContext = new DbAppContext(null, options.Options);
// ImportCity.Import(context, dbContext, fileLocation, systemId);

//*** Service Areas: from the file of Service_Area.xml to the table of HET_SERVICE_AREA
//dbContext = new DbAppContext(null, options.Options);
// ImportServiceArea.Import(context, dbContext, fileLocation, systemId);