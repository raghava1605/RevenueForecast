using AutoMapper;
using RevenueForecast.Common.Data;
using RevenueForecast.Common.Models;
using RevenueForecast.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Business
{
    public class SowPlannedRepository : ISowPlanned
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        #endregion

        #region Constructors
        public SowPlannedRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            _OperationalPortalEntities = OperationalPortalEntities;
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SowPlannedModel> GetSowPlannedDetails()
        {
            List<SowDetail> sow = _OperationalPortalEntities.SowDetails.ToList();
            List<SowPlannedModel> sowList = Mapper.Map<List<SowDetail>, List<SowPlannedModel>>(sow);
            return sowList;
        }
        public SowPlannedModel GetSowPlannedDetailsById(int sowdetailId)
        {
            var sowDetail = _OperationalPortalEntities.SowDetails.FirstOrDefault(x => x.SowDetailId == sowdetailId);
            SowPlannedModel sowDetailObj = Mapper.Map<SowDetail, SowPlannedModel>(sowDetail);
            return sowDetailObj;
        }

        public string SaveSowPlannedDetails(SowPlannedModel sowDetailModel)
        {
            string result = string.Empty;
            try
            {

                SowDetail sowDetail = _OperationalPortalEntities.SowDetails.FirstOrDefault(x => x.SowDetailId == sowDetailModel.SowDetailId);
                if (sowDetail != null)
                {
                    Mapper.Map(sowDetailModel, sowDetail);
                    result = "SowDetails Updated Successfully";
                }
                else
                {
                    sowDetail = new SowDetail();
                    Mapper.Map(sowDetailModel, sowDetail);
                    _OperationalPortalEntities.SowDetails.Add(sowDetail);
                    result = "SowDetails Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteSowPlannedDetail(int sowdetailId)
        {
            string result = string.Empty;
            try
            {
                SowDetail sow = _OperationalPortalEntities.SowDetails.FirstOrDefault(x => x.SowDetailId == sowdetailId);
                if (sow != null)
                {
                    _OperationalPortalEntities.SowDetails.Remove(sow);
                    _OperationalPortalEntities.SaveChanges();
                    result = "SowDetails Removed Successfully";
                }
                else
                {
                    result = "SowDetail Does not exist";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }


        #endregion
    }
}
