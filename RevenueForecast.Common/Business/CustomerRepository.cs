﻿using RevenueForecast.Common.Models.Interfaces;
using RevenueForecast.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevenueForecast.Common.Models;
using AutoMapper;
using NLog;

namespace RevenueForecast.Common.Business
{
    public class CustomerRepository : ICustomer
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
      //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public CustomerRepository(OperationalPortalDBEntities OperationalPortalEntities)
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
        public IEnumerable<CustomerModel> GetCustomers()
        {
            //logger.Info("Start Fetch Customer");
            List<Customer> customers = _OperationalPortalEntities.Customers.ToList();
            List<CustomerModel> customerList = Mapper.Map<List<Customer>, List<CustomerModel>>(customers);
            return customerList;
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            var customer = _OperationalPortalEntities.Customers.FirstOrDefault(x => x.CustomerID == customerId);
            CustomerModel customerObj = Mapper.Map<Customer, CustomerModel>(customer);
            return customerObj;
        }

        public string SaveCustomerDetails(CustomerModel customerModel)
        {
            string result = string.Empty;
            try
            {
                
                Customer customer = _OperationalPortalEntities.Customers.FirstOrDefault(x => x.CustomerID == customerModel.CustomerID);
                if (customer != null)
                {
                    Mapper.Map(customerModel, customer);
                    result = "Customer Updated Successfully";
                }
                else
                {
                    customer = new Customer();
                    Mapper.Map(customerModel, customer);
                    _OperationalPortalEntities.Customers.Add(customer);
                    result = "Customer Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteCustomer(int customerId)
        {
            string result = string.Empty;
            try
            {
                Customer customer = _OperationalPortalEntities.Customers.FirstOrDefault(x => x.CustomerID == customerId);
                if (customer != null)
                {
                    _OperationalPortalEntities.Customers.Remove(customer);
                    _OperationalPortalEntities.SaveChanges();
                    result = "Customer Removed Successfully";
                }
                else
                {
                    result = "Customer Does not exist";
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
