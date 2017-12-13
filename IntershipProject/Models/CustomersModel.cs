using IntershipProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject.Models
{
    class CustomersModel
    {

        #region Customers queries

        public static async Task<List<Customers>> getCustomersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          select o.Customers).ToListAsync();
        }

        public static async Task<List<Customers>> getAllCustomers()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Customers select o)
                                .ToListAsync();
        }


        public static async Task<List<Customers>> getCustomerByIdAndUserId(int CustomerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          && o.CustomerId.Equals(CustomerId)
                          select o.Customers)
                           .ToListAsync();
        }

        public static async Task<List<Customers>> getAllCustomersByCompanyAndUserId(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          && o.Customers.CompanyName.Equals(CompanyName)
                          select o.Customers)
                           .ToListAsync();
        }


        public static async Task<List<Customers>> getCustomerById(int CustomerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from c in ordersEntities.Customers
                          where c.Id.Equals(CustomerId)
                          select c)
                           .ToListAsync();
        }

        public static async Task<List<Customers>> getAllCustomersByCompany(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from c in ordersEntities.Customers
                          where c.CompanyName.Equals(CompanyName)
                          select c)
                           .ToListAsync();
        }


        #endregion
    }
}
