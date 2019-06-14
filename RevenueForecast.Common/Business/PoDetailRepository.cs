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
    public class PoDetailRepository : IPoDetails
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public PoDetailRepository(OperationalPortalDBEntities OperationalPortalEntities)
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
        public IEnumerable<PoDetailsModel> GetPoDetails()
        {
            //logger.Info("Start Fetch Customer");
            List<PoDetailsModel> podetails = (from p in _OperationalPortalEntities.PoDetails
                                        join pd in _OperationalPortalEntities.PoHeaders
                                        on p.PoHeaderID equals pd.PoHeaderID
                                        select new PoDetailsModel()
                                        {
                                            PoDetailsID = p.PoDetailsID,
                                            PoHeaderID = p.PoHeaderID,
                                            PoNum = pd.PoNum,
                                            MileStones = p.MileStones,
                                            Amount = p.Amount
                                        }).ToList();
           // List<PoDetailsModel> podetailsList = Mapper.Map<List<PoDetail>, List<PoDetailsModel>>(podetails);
            return podetails;
        }

        public PoDetailsModel GetPoDetailsById(int podId)
        {
            var poDetails = _OperationalPortalEntities.PoDetails.FirstOrDefault(x => x.PoDetailsID == podId);
            PoDetailsModel poDetailsObj = Mapper.Map<PoDetail, PoDetailsModel>(poDetails);
            return poDetailsObj;
        }

        public string SavePoDetails(PoDetailsModel poDetailsModel)
        {
            string result = string.Empty;
            try
            {

                PoDetail poDetails = _OperationalPortalEntities.PoDetails.FirstOrDefault(x => x.PoDetailsID == poDetailsModel.PoDetailsID);
                if (poDetails != null)
                {
                    Mapper.Map(poDetailsModel, poDetails);
                    result = "PoDetails Updated Successfully";
                }
                else
                {
                    poDetails = new PoDetail();
                    Mapper.Map(poDetailsModel, poDetails);
                    _OperationalPortalEntities.PoDetails.Add(poDetails);
                    result = "PoDetails Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeletePoDetails(int podId)
        {
            string result = string.Empty;
            try
            {
                PoDetail poDetails = _OperationalPortalEntities.PoDetails.FirstOrDefault(x => x.PoDetailsID == podId);
                if (poDetails != null)
                {
                    _OperationalPortalEntities.PoDetails.Remove(poDetails);
                    _OperationalPortalEntities.SaveChanges();
                    result = "PoDetails Removed Successfully";
                }
                else
                {
                    result = "PoDetails Does not exist";
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
