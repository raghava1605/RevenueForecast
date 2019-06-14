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
            var msa = (from m in _OperationalPortalEntities.MSAs
                       join ms in _OperationalPortalEntities.Customers
                       on m.CustomerID equals ms.CustomerID
                       select new MSAModel()
                       {
                           CustomerID = ms.CustomerID,
                           CustomerName = ms.CustomerName,
                           Description = ms.Description,
                           StartDate = m.StartDate,
                           EndDate = m.EndDate,
                           ContractType = m.ContractType,
                           MSAID = m.MSAID,
                           MSAEntity = m.MSAEntity,
                           Owner = ms.Owner
                       }).ToList();

            //List<MSA> msa = _OperationalPortalEntities.MSAs.Include("Customer").ToList();
           // List<MSAModel> msaList = Mapper.Map<List<MSA>, List<MSAModel>>(msa);
            return msa;
        }
        public MSAModel GetMSAById(int msaId)
        {
            var msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.MSAID == msaId);
            MSAModel msaObj = Mapper.Map<MSA, MSAModel>(msa);
            return msaObj;
        }

        public string SaveMSADetails(MSAModel msaModel)
        {
            string result = string.Empty;
            try
            {

                MSA msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.MSAID == msaModel.MSAID);
                if (msa != null)
                {
                    Mapper.Map(msaModel, msa);
                    result = "MSA Updated Successfully";
                }
                else
                {
                    msa = new MSA();
                  
                    Mapper.Map(msaModel, msa);
                    msa.Customer = null;
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
                MSA msa = _OperationalPortalEntities.MSAs.FirstOrDefault(x => x.MSAID == msaId);
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
