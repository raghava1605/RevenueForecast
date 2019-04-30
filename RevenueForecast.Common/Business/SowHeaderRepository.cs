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
    public class SowHeaderRepository : ISowHeader
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        #endregion

        #region Constructors
        public SowHeaderRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            _OperationalPortalEntities = OperationalPortalEntities;
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SowHeaderModel> GetSowHeaders()
        {
            List<SowHeader> sowHeaders = _OperationalPortalEntities.SowHeaders.ToList();
            List<SowHeaderModel> sowHeaderList = Mapper.Map<List<SowHeader>, List<SowHeaderModel>>(sowHeaders);
            return sowHeaderList;
        }
        public SowHeaderModel GetSowHeaderById(int sowId)
        {
            var sowHeaders = _OperationalPortalEntities.SowHeaders.FirstOrDefault(x => x.SowId == sowId);
            SowHeaderModel sowheaderObj = Mapper.Map<SowHeader, SowHeaderModel>(sowHeaders);
            return sowheaderObj;
        }

        public string SaveSowHeaderDetails(SowHeaderModel sowHeaderModel)
        {
            string result = string.Empty;
            try
            {

                SowHeader sowHeader = _OperationalPortalEntities.SowHeaders.FirstOrDefault(x => x.SowId == sowHeaderModel.SowId);
                if (sowHeader != null)
                {
                    Mapper.Map(sowHeaderModel, sowHeader);
                    result = "SowHeader Updated Successfully";
                }
                else
                {
                    sowHeader = new SowHeader();
                    Mapper.Map(sowHeaderModel, sowHeader);
                    _OperationalPortalEntities.SowHeaders.Add(sowHeader);
                    result = "SowHeader Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteSowHeader(int sowId)
        {
            string result = string.Empty;
            try
            {
                SowHeader sowHeader = _OperationalPortalEntities.SowHeaders.FirstOrDefault(x => x.SowId == sowId);
                if (sowHeader != null)
                {
                    _OperationalPortalEntities.SowHeaders.Remove(sowHeader);
                    _OperationalPortalEntities.SaveChanges();
                    result = "SowHeader Removed Successfully";
                }
                else
                {
                    result = "SowHeader Does not exist";
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
