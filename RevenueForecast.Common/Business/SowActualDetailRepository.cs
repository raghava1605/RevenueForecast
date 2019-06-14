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
    public class SowActualDetailRepository : ISowActualDetail
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public SowActualDetailRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            // logger.Info("OperationalPortalEntities Instance is going to create");
            _OperationalPortalEntities = OperationalPortalEntities;
            //  logger.Info("OperationalPortalEntities Instance is created successfully");
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SowDetailActualModel> GetActualSows()
        {
            //logger.Info("Start Fetch Customer");
            var sowActualList = (from sd in _OperationalPortalEntities.SowDetails
                       join sda in _OperationalPortalEntities.SowDetailActuals
                       on sd.SowDetailID equals sda.SowDetailID
                       select new SowDetailActualModel()
                       {
                          SowDetailActualID = sda.SowDetailActualID,
                          SowDetailID = sda.SowDetailID,
                          UtilizationPercentage = sda.UtilizationPercentage,
                          TotalAmount = sd.BillRate * sd.HrsPerDay * sda.NoOfDays,
                          NoOfDays = sda.NoOfDays,
                          Month = sda.Month,
                          Year = sda.Year
                       }).ToList();
            return sowActualList;
        }

        public SowDetailActualModel GetActualSowDetailById(int sowActualID)
        {
            var sowActual = _OperationalPortalEntities.SowDetailActuals.FirstOrDefault(x => x.SowDetailActualID == sowActualID);
            SowDetailActualModel sowActualObj = Mapper.Map<SowDetailActual, SowDetailActualModel>(sowActual);
            return sowActualObj;
        }

        public string SaveActualSowDetails(SowDetailActualModel sowActualModel)
        {
            string result = string.Empty;
            try
            {

                SowDetailActual sowActual = _OperationalPortalEntities.SowDetailActuals.FirstOrDefault(x => x.SowDetailActualID == sowActualModel.SowDetailActualID);
                if (sowActual != null)
                {
                    Mapper.Map(sowActualModel, sowActual);
                    result = "SowActualDetails Updated Successfully";
                }
                else
                {
                    sowActual = new SowDetailActual();
                    Mapper.Map(sowActualModel, sowActual);
                    _OperationalPortalEntities.SowDetailActuals.Add(sowActual);
                    result = "SowActualDetails Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteActualSowDetail(int customerId)
        {
            string result = string.Empty;
            try
            {
                SowDetailActual sowActual = _OperationalPortalEntities.SowDetailActuals.FirstOrDefault(x => x.SowDetailActualID == customerId);
                if (sowActual != null)
                {
                    _OperationalPortalEntities.SowDetailActuals.Remove(sowActual);
                    _OperationalPortalEntities.SaveChanges();
                    result = "SowActualDetails Removed Successfully";
                }
                else
                {
                    result = "SowActualDetails Does not exist";
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
