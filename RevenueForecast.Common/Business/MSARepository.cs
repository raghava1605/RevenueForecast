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
    public class MSARepository : IMSA
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        #endregion

        #region Constructors
        public MSARepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            _OperationalPortalEntities = OperationalPortalEntities;
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MSAModel> GetMSA()
        {
            //var w = _OperationalPortalEntities.MSAs.Include("Customer");

            List<MSA> msa = _OperationalPortalEntities.MSAs.Include("Customer").ToList();
            List<MSAModel> msaList = Mapper.Map<List<MSA>, List<MSAModel>>(msa);
            return msaList;
        }
        public MSAModel GetMSAById(int msaId)
        {
            var msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.MSAId == msaId);
            MSAModel msaObj = Mapper.Map<MSA, MSAModel>(msa);
            return msaObj;
        }

        public string SaveMSADetails(MSAModel msaModel)
        {
            string result = string.Empty;
            try
            {

                MSA msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.CustomerId == msaModel.MSAId);
                if (msa != null)
                {
                    Mapper.Map(msaModel, msa);
                    result = "MSA Updated Successfully";
                }
                else
                {
                    msa = new MSA();
                    Mapper.Map(msaModel, msa);
                    _OperationalPortalEntities.MSAs.Add(msa);
                    result = "MSA Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteMSA(int msaId)
        {
            string result = string.Empty;
            try
            {
                MSA msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.MSAId == msaId);
                if (msa != null)
                {
                    _OperationalPortalEntities.MSAs.Remove(msa);
                    _OperationalPortalEntities.SaveChanges();
                    result = "MSA Removed Successfully";
                }
                else
                {
                    result = "MSA Does not exist";
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
