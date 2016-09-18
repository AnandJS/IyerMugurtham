-- =============================================
-- Author:      <ANAND JAYASEELAN>
-- Create date: <APR 21 2014>
-- Description: <ALL PROFILE SEARCH DYNAMIC SQL>
-- =============================================
Create PROCEDURE [dbo].[uspGetAllProfiles]
AS
  BEGIN
      DECLARE @strSQLQuery AS NVARCHAR(4000)

      SET nocount ON;
      SET xact_abort, quoted_identifier, ansi_nulls, ansi_padding, ansi_warnings
      ,
      arithabort, concat_null_yields_null ON;
      SET numeric_roundabort OFF;

      DECLARE @localTran BIT

      IF @@TRANCOUNT = 0
        BEGIN
            SET @localTran = 1

            BEGIN TRANSACTION localtran
        END

      BEGIN try
          SELECT profilebasicinfo.elanuserid,
                 profilebasicinfo.profileid,
                 profilebasicinfo.NAME,
                 profilebasicinfo.age,
                 profilebasicinfo.gender,
                 profilebasicinfo.dateofbirth,
                 profilebasicinfo.tamildob,
                 profilebasicinfo.timeofbirth,
                 profilebasicinfo.placeofbirth,
                 profilebasicinfo.maritalstatus,
                 profilebasicinfo.noofchildren,
                 profilebasicinfo.childrenlivingstatus,
                 profilebasicinfo.height,
                 profilebasicinfo.weight,
                 profilebasicinfo.bodytype,
                 profilebasicinfo.complexion,
                 profilebasicinfo.physicalstatus,
                 profilebasicinfo.bloodgroup,
                 profilebasicinfo.mothertongue,
                 profilebasicinfo.profilecreatedby,
                 profilebasicinfo.religion,
                 profilebasicinfo.caste,
                 profilebasicinfo.subcaste,
                 profilebasicinfo.gothram,
                 profilebasicinfo.star,
                 profilebasicinfo.raasi,
                 profilebasicinfo.zodiac,
                 profilebasicinfo.horoscopematch,
                 profilebasicinfo.anydosham,
                 profilebasicinfo.eating,
                 profilebasicinfo.smoking,
                 profilebasicinfo.drinking,
                 profilebasicinfo.aboutme,
                 profilebasicinfo.partnerexpectations,
                 profilebasicinfo.createdby,
                 profilebasicinfo.createddate,
                 profilebasicinfo.zodiacyear,
                 profilebasicinfo.zodiacmonth,
                 profilebasicinfo.zodiacday,
                 profilebasicinfo.photopath,
                 profilebasicinfo.sangamid,
                 profilebasicinfo.modifiedby,
                 profilebasicinfo.modifieddate
          FROM   profilebasicinfo ProfileBasicInfo WITH (nolock)
                 INNER JOIN portaluser PortalUser WITH (nolock)
                         ON portaluser.roleid = 'F62DDFBE55448E3A3'
                            -- User Profiles only
                            AND portaluser.isactivated = 1
                            -- Activated Profile Only
                            AND portaluser.loginid = profilebasicinfo.profileid
                 INNER JOIN sangammaster SangamMaster WITH (nolock)
                         ON sangammaster.isactivated = 1
                            -- Activated Sangam Only
                            AND sangammaster.id = portaluser.sangamid

          IF @localTran = 1
             AND Xact_state() = 1
            COMMIT TRAN localtran
      END try

      BEGIN catch
          DECLARE @ErrorMessage NVARCHAR(4000)
          DECLARE @ErrorSeverity INT
          DECLARE @ErrorState INT

          SELECT @ErrorMessage = Error_message(),
                 @ErrorSeverity = Error_severity(),
                 @ErrorState = Error_state()

          IF @localTran = 1
             AND Xact_state() <> 0
            ROLLBACK TRAN

          RAISERROR ( @ErrorMessage,@ErrorSeverity,@ErrorState)
      END catch
  END 
