using IntershipProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject.Models
{
    class OrdersModel
    {

        #region Companies queries

        public static async Task<List<String>> getCompaniesByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          select o.Customers.CompanyName).Distinct().ToListAsync();
        }
        
        public static async Task<List<String>> getAllСompanies()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          select o.Customers.CompanyName).Distinct().ToListAsync();
        }

        #endregion

        #region Orders queries

        public static async Task<List<Orders>> getOrdersByCompanyNameAndUserId(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.CompanyName.Equals(CompanyName)
                                        && o.EmployeeId.Equals(MainViewModel.CurrentUserId))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllOrdersByCompanyName(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.CompanyName.Equals(CompanyName))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getOrdersByCustomerIdAndUserId(int customerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                        && o.Customers.Id.Equals(customerId))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllOrdersByCustomerId(int customerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.Id.Equals(customerId))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllOrders()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .ToListAsync());
        }

        public async static Task<List<String>> getStatuses()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from s in ordersEntities.OrderStatuses select s.StatusName).ToListAsync(); ;
        }

        #endregion

    }
}
