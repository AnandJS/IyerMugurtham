using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Contact
{
    public class ContactCore
    {
        public int Add(ref Mugurtham.Core.Contact.ContactCoreEntity objContactCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Contact objDTOContact = new DTO.Profile.Contact();
                    using (objDTOContact as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOContact, ref objContactCoreEntity);
                    }
                    objIUnitOfWork.RepositoryContact.Add(objDTOContact);
                    objDTOContact = null;
                }
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        public int Edit(ref Mugurtham.Core.Contact.ContactCoreEntity objContactCoreEntity)
        {
            IUnitOfWork objIUnitOfWork = new UnitOfWork();
            try
            {
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Contact objDTOContact = new DTO.Profile.Contact();
                    using (objDTOContact as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOContact, ref objContactCoreEntity);
                    }
                    objIUnitOfWork.RepositoryContact.Edit(objDTOContact);
                    objDTOContact = null;
                }
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        public ContactCoreEntity GetByProfileID(string strProfileID)
        {
            ContactCoreEntity objContactCoreEntity = new ContactCoreEntity();
            try
            {
                Mugurtham.DTO.Profile.Contact objContact = new Mugurtham.DTO.Profile.Contact();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objContact = objUOW.RepositoryContact.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objContact != null)
                {
                    using (objContact as IDisposable)
                    {
                        AssignEntityFromCore(ref objContact, ref objContactCoreEntity);
                    }
                }
                objContact = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objContactCoreEntity;
        }

        private int AssignDTOFromEntity(ref Mugurtham.DTO.Profile.Contact objDTOContact, ref Mugurtham.Core.Contact.ContactCoreEntity objContactCoreEntity)
        {
            try
            {
                objDTOContact.Address = objContactCoreEntity.ResidentialAddress;
                objDTOContact.ConvinientTimeToCall = objContactCoreEntity.TimeToCall;
                objDTOContact.EMail = objContactCoreEntity.Email;
                objDTOContact.LandLineNumber = objContactCoreEntity.LandlineNumber;
                objDTOContact.MobileNumber = objContactCoreEntity.MobileNumber;
                objDTOContact.RelationShipWithMember = objContactCoreEntity.Relationship;
                objDTOContact.CreatedDate = DateTime.Now;
                objDTOContact.ModifiedDate = DateTime.Now;
                objDTOContact.ProfileID = objContactCoreEntity.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignEntityFromCore(ref Mugurtham.DTO.Profile.Contact objDTOContact, ref Mugurtham.Core.Contact.ContactCoreEntity objContactCoreEntity)
        {
            try
            {
                objContactCoreEntity.ResidentialAddress = objDTOContact.Address;
                objContactCoreEntity.TimeToCall = objDTOContact.ConvinientTimeToCall;
                objContactCoreEntity.Email = objDTOContact.EMail;
                objContactCoreEntity.LandlineNumber = objDTOContact.LandLineNumber;
                objContactCoreEntity.MobileNumber = objDTOContact.MobileNumber;
                objContactCoreEntity.Relationship = objDTOContact.RelationShipWithMember;
                objContactCoreEntity.ProfileID = objDTOContact.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}
