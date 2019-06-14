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
    public class PoHeaderRepository : IPoHeader
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        #endregion

        #region Constructors
        public PoHeaderRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            _OperationalPortalEntities = OperationalPortalEntities;
        }
        #endregion

        #region Members
        /// <summary>
        /// Get PoHeaders List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PoHeaderModel> GetPoHeaders()
        {
            List<PoHeader> poHeaders = _OperationalPortalEntities.PoHeaders.ToList();
            List<PoHeaderModel> poHeadersList = Mapper.Map<List<PoHeader>, List<PoHeaderModel>>(poHeaders);
            return poHeadersList;
        }
        public PoHeaderModel GetPoHeadersById(int poId)
        {
            var poHeaders = _OperationalPortalEntities.PoHeaders.FirstOrDefault(x => x.PoHeaderID == poId);
            PoHeaderModel poHeaderObj = Mapper.Map<PoHeader, PoHeaderModel>(poHeaders);
            return poHeaderObj;
        }

        public string SavePoHeadersDetails(PoHeaderModel poHeaderModel)
        {
            string result = string.Empty;
            try
            {

                PoHeader poHeader = _OperationalPortalEntities.PoHeaders.FirstOrDefault(x => x.PoHeaderID == poHeaderModel.PoHeaderID);
                if (poHeader != null)
                {
                    Mapper.Map(poHeaderModel, poHeader);
                    result = "PoHeader Updated Successfully";
                }
                else
                {
                    poHeader = new PoHeader();
                    poHeader.SowHeader = null;
                    Mapper.Map(poHeaderModel, poHeader);
                    _OperationalPortalEntities.PoHeaders.Add(poHeader);
                    result = "PoHeader Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeletePoHeaders(int poId)
        {
            string result = string.Empty;
            try
            {
                PoHeader poHeader = _OperationalPortalEntities.PoHeaders.FirstOrDefault(x => x.PoHeaderID == poId);
                if (poHeader != null)
                {
                    _OperationalPortalEntities.PoHeaders.Remove(poHeader);
                    _OperationalPortalEntities.SaveChanges();
                    result = "PoHeader Removed Successfully";
                }
                else
                {
                    result = "PoHeader Does not exist";
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
