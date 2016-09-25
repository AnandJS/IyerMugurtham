using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.BasicInfo
{
    public class BasicInfoCore
    {
        public int Add(ref Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.BasicInfo objDTOBasicInfo = new DTO.Profile.BasicInfo();
                    using (objDTOBasicInfo as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOBasicInfo, ref objBasicInfoCoreEntity);
                        objDTOBasicInfo.CreatedDate = DateTime.Now;
                    }
                    objIUnitOfWork.RepositoryBasicInfo.Add(objDTOBasicInfo);
                    objDTOBasicInfo = null;
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

        public int Edit(ref Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.BasicInfo objDTOBasicInfo = new DTO.Profile.BasicInfo();
                    using (objDTOBasicInfo as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOBasicInfo, ref objBasicInfoCoreEntity);
                    }
                    objIUnitOfWork.RepositoryBasicInfo.Edit(objDTOBasicInfo);
                    objDTOBasicInfo = null;
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

        public BasicInfoCoreEntity GetByProfileID(string strProfileID)
        {
            BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
            try
            {
                Mugurtham.DTO.Profile.BasicInfo objBasicInfo = new Mugurtham.DTO.Profile.BasicInfo();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objBasicInfo = objUOW.RepositoryBasicInfo.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objBasicInfo != null)
                {
                    using (objBasicInfo as IDisposable)
                    {
                        AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                    }
                }
                objBasicInfo = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objBasicInfoCoreEntity;
        }

        public List<BasicInfoCoreEntity> GetAll()
        {
            List<BasicInfoCoreEntity> objListBasicInfoCoreEntity = new List<BasicInfoCoreEntity>();
            try
            {
                List<Mugurtham.DTO.Profile.BasicInfo> objListBasicInfo = new List<Mugurtham.DTO.Profile.BasicInfo>();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objListBasicInfo = objUOW.RepositoryBasicInfo.GetAll().ToList();
                objUOW = null;
                if (objListBasicInfo != null && objListBasicInfo.Count > 0)
                {
                    foreach (Mugurtham.DTO.Profile.BasicInfo objBasicInfo in objListBasicInfo)
                    {
                        using (objBasicInfo as IDisposable)
                        {
                            BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
                            AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                            objListBasicInfoCoreEntity.Add(objBasicInfoCoreEntity);
                            objBasicInfoCoreEntity = null;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objListBasicInfoCoreEntity;
        }

        public List<BasicInfoCoreEntity> GetAllBySangam()
        {
            List<BasicInfoCoreEntity> objListBasicInfoCoreEntity = new List<BasicInfoCoreEntity>();
            try
            {
                List<Mugurtham.DTO.Profile.BasicInfo> objListBasicInfo = new List<Mugurtham.DTO.Profile.BasicInfo>();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objListBasicInfo = objUOW.RepositoryBasicInfo.GetAll().ToList();
                objUOW = null;
                if (objListBasicInfo != null && objListBasicInfo.Count > 0)
                {
                    foreach (Mugurtham.DTO.Profile.BasicInfo objBasicInfo in objListBasicInfo)
                    {
                        using (objBasicInfo as IDisposable)
                        {
                            BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
                            AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                            objListBasicInfoCoreEntity.Add(objBasicInfoCoreEntity);
                            objBasicInfoCoreEntity = null;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objListBasicInfoCoreEntity;
        }

        public List<BasicInfoCoreEntity> GetAllBySangam(string strSangamID)
        {
            List<BasicInfoCoreEntity> objListBasicInfoCoreEntity = new List<BasicInfoCoreEntity>();
            try
            {
                List<Mugurtham.DTO.Profile.BasicInfo> objListBasicInfo = new List<Mugurtham.DTO.Profile.BasicInfo>();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objListBasicInfo = objUOW.RepositoryBasicInfo.GetAll().ToList().Where(p => p.SangamID == strSangamID).ToList();
                objUOW = null;
                if (objListBasicInfo != null && objListBasicInfo.Count > 0)
                {
                    foreach (Mugurtham.DTO.Profile.BasicInfo objBasicInfo in objListBasicInfo)
                    {
                        using (objBasicInfo as IDisposable)
                        {
                            BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
                            AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                            objListBasicInfoCoreEntity.Add(objBasicInfoCoreEntity);
                            objBasicInfoCoreEntity = null;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objListBasicInfoCoreEntity;
        }

        private int AssignDTOFromEntity(ref Mugurtham.DTO.Profile.BasicInfo objBasicInfo, ref Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            try
            {
                objBasicInfo.ProfileID = objBasicInfoCoreEntity.ProfileID;
                objBasicInfo.SangamProfileID = objBasicInfoCoreEntity.SangamProfileID;
                objBasicInfo.AboutMe = objBasicInfoCoreEntity.AboutMe;
                objBasicInfo.Age = objBasicInfoCoreEntity.Age;
                objBasicInfo.AnyDosham = objBasicInfoCoreEntity.AnyDhosham;
                objBasicInfo.BloodGroup = objBasicInfoCoreEntity.BloodGroup;
                objBasicInfo.BodyType = objBasicInfoCoreEntity.BodyType;
                objBasicInfo.Caste = objBasicInfoCoreEntity.Caste;
                objBasicInfo.ChildrenLivingStatus = objBasicInfoCoreEntity.ChildrenLivingStatus;
                objBasicInfo.Complexion = objBasicInfoCoreEntity.Complexion;
                objBasicInfo.CreatedBy = objBasicInfoCoreEntity.ProfileCreatedBy;
                objBasicInfo.CreatedDate = objBasicInfoCoreEntity.CreatedDate;
                objBasicInfo.DateOfBirth = objBasicInfoCoreEntity.DOB;
                objBasicInfo.Drinking = objBasicInfoCoreEntity.Drinking;
                objBasicInfo.Eating = objBasicInfoCoreEntity.Eating;
                objBasicInfo.ElanUserID = objBasicInfoCoreEntity.ElanUserID; //ElanProfileID
                objBasicInfo.Gender = objBasicInfoCoreEntity.Gender;
                objBasicInfo.Gothram = objBasicInfoCoreEntity.Gothram;
                objBasicInfo.Height = objBasicInfoCoreEntity.Height;
                objBasicInfo.HoroscopeMatch = objBasicInfoCoreEntity.HoroscopeMatch;
                objBasicInfo.MaritalStatus = objBasicInfoCoreEntity.MaritalStatus;
                objBasicInfo.ModifiedBy = objBasicInfoCoreEntity.ModifiedBy;
                objBasicInfo.ModifiedDate = DateTime.Now;
                objBasicInfo.MotherTongue = objBasicInfoCoreEntity.MotherTongue;
                objBasicInfo.Name = objBasicInfoCoreEntity.Name;
                objBasicInfo.NoOfChildren = objBasicInfoCoreEntity.NoOfChildren;
                objBasicInfo.PartnerExpectations = objBasicInfoCoreEntity.PartnerExpectation;
                objBasicInfo.PhysicalStatus = objBasicInfoCoreEntity.PhysicalStatus;
                objBasicInfo.PlaceOfBirth = objBasicInfoCoreEntity.PlaceOfBirth;
                objBasicInfo.ProfileCreatedBy = objBasicInfoCoreEntity.ProfileCreatedBy;
                objBasicInfo.Raasi = objBasicInfoCoreEntity.Raasi;
                objBasicInfo.Religion = objBasicInfoCoreEntity.Religion;
                objBasicInfo.SangamID = objBasicInfoCoreEntity.SangamID;
                objBasicInfo.Smoking = objBasicInfoCoreEntity.Smoking;
                objBasicInfo.Star = objBasicInfoCoreEntity.Star;
                objBasicInfo.SubCaste = objBasicInfoCoreEntity.SubCaste;
                objBasicInfo.TamilDOB = objBasicInfoCoreEntity.TamilDOB;
                objBasicInfo.TimeOfBirth = objBasicInfoCoreEntity.TOB;
                objBasicInfo.Weight = objBasicInfoCoreEntity.Weight;
                objBasicInfo.Zodiac = objBasicInfoCoreEntity.Zodiac;
                objBasicInfo.ZodiacDay = objBasicInfoCoreEntity.ZodiacDay;
                objBasicInfo.ZodiacMonth = objBasicInfoCoreEntity.ZodiacMonth;
                objBasicInfo.ZodiacDay = objBasicInfoCoreEntity.ZodiacYear;
                objBasicInfo.PhotoPath = objBasicInfoCoreEntity.PhotoPath;
                objBasicInfo.Paadham = objBasicInfoCoreEntity.Paadham;

            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }


        public int AssignEntityFromDTO(BasicInfoCoreEntity objBasicInfoCoreEntity, Mugurtham.DTO.Profile.BasicInfo objBasicInfo)
        {
            try
            {
                objBasicInfoCoreEntity.ProfileID = objBasicInfo.ProfileID;
                objBasicInfoCoreEntity.SangamProfileID = objBasicInfo.SangamProfileID;
                objBasicInfoCoreEntity.AboutMe = objBasicInfo.AboutMe;
                objBasicInfoCoreEntity.Age = objBasicInfo.Age;
                objBasicInfoCoreEntity.AnyDhosham = objBasicInfo.AnyDosham;
                objBasicInfoCoreEntity.BloodGroup = objBasicInfo.BloodGroup;
                objBasicInfoCoreEntity.BodyType = objBasicInfo.BodyType;
                objBasicInfoCoreEntity.Caste = objBasicInfo.Caste;
                objBasicInfoCoreEntity.ChildrenLivingStatus = objBasicInfo.ChildrenLivingStatus;
                objBasicInfoCoreEntity.Complexion = objBasicInfo.Complexion;
                objBasicInfoCoreEntity.DOB = objBasicInfo.DateOfBirth;
                objBasicInfoCoreEntity.Drinking = objBasicInfo.Drinking;
                objBasicInfoCoreEntity.Eating = objBasicInfo.Eating;
                objBasicInfoCoreEntity.ElanUserID = objBasicInfo.ElanUserID;
                objBasicInfoCoreEntity.Gender = objBasicInfo.Gender;
                objBasicInfoCoreEntity.Gothram = objBasicInfo.Gothram;
                objBasicInfoCoreEntity.Height = objBasicInfo.Height;
                objBasicInfoCoreEntity.HoroscopeMatch = objBasicInfo.HoroscopeMatch;
                objBasicInfoCoreEntity.MaritalStatus = objBasicInfo.MaritalStatus;
                objBasicInfoCoreEntity.MotherTongue = objBasicInfo.MotherTongue;
                objBasicInfoCoreEntity.Name = objBasicInfo.Name;
                objBasicInfoCoreEntity.NoOfChildren = objBasicInfo.NoOfChildren;
                objBasicInfoCoreEntity.PartnerExpectation = objBasicInfo.PartnerExpectations;
                objBasicInfoCoreEntity.PhysicalStatus = objBasicInfo.PhysicalStatus;
                objBasicInfoCoreEntity.PlaceOfBirth = objBasicInfo.PlaceOfBirth;
                objBasicInfoCoreEntity.ProfileCreatedBy = objBasicInfo.ProfileCreatedBy;
                objBasicInfoCoreEntity.Raasi = objBasicInfo.Raasi;
                objBasicInfoCoreEntity.Religion = objBasicInfo.Religion;
                objBasicInfoCoreEntity.SangamID = objBasicInfo.SangamID;
                objBasicInfoCoreEntity.Smoking = objBasicInfo.Smoking;
                objBasicInfoCoreEntity.Star = objBasicInfo.Star;
                objBasicInfoCoreEntity.SubCaste = objBasicInfo.SubCaste;
                objBasicInfoCoreEntity.TamilDOB = objBasicInfo.TamilDOB;
                objBasicInfoCoreEntity.TOB = objBasicInfo.TimeOfBirth;
                objBasicInfoCoreEntity.Weight = objBasicInfo.Weight;
                objBasicInfoCoreEntity.Zodiac = objBasicInfo.Zodiac;
                objBasicInfoCoreEntity.ZodiacDay = objBasicInfo.ZodiacDay;
                objBasicInfoCoreEntity.ZodiacMonth = objBasicInfo.ZodiacMonth;
                objBasicInfoCoreEntity.ZodiacYear = objBasicInfo.ZodiacYear;
                objBasicInfoCoreEntity.PhotoPath = objBasicInfo.PhotoPath;
                objBasicInfoCoreEntity.CreatedDate = objBasicInfo.CreatedDate;
                objBasicInfoCoreEntity.Paadham = objBasicInfo.Paadham;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}
