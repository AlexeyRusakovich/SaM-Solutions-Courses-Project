using IntershipProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntershipProject.Models
{
    class OrdersModel
    {

        #region Orders Priority queries

        public static async Task<bool> fromActiveToEndedOrder(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            Orders order = await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync();

            int CurrentPriority = await getPriorityById(OrderId);

            foreach (var o in await (from o in ordersEntities.Orders
                                     where o.OrderDetails.Priority > CurrentPriority
                                     select o).ToArrayAsync())
            {
                o.OrderDetails.Priority = o.OrderDetails.Priority - 1;
                ordersEntities.Entry(o).State = EntityState.Modified;
            }


            order.OrderDetails.Priority = -1;
            order.OrderDetails.ClosingOrderDate = DateTime.Now.ToString();
            order.OrderDetails.Status = await getStatusIdByStatusName("Выполнен");   
            ordersEntities.SaveChanges();
            DatabaseChanged();
            return true;
        }

        public static async Task<bool> fromActiveToCanceledOrder(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            Orders order = await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync();

            int CurrentPriority = await getPriorityById(OrderId);

            foreach (var o in await (from o in ordersEntities.Orders
                                     where o.OrderDetails.Priority > CurrentPriority
                                     select o).ToArrayAsync())
            {
                o.OrderDetails.Priority = o.OrderDetails.Priority - 1;
                ordersEntities.Entry(o).State = EntityState.Modified;
            }

            order.OrderDetails.Priority = -1;
            order.OrderDetails.ClosingOrderDate = DateTime.Now.ToString();
            order.OrderDetails.Status = await getStatusIdByStatusName("Отменен");
            ordersEntities.SaveChanges();
            DatabaseChanged();
            return true;
        }

        public static async Task<bool> fromActiveToSuspendedOrder(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            Orders order = await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync();

            int CurrentPriority = await getPriorityById(OrderId);

            foreach (var o in await (from o in ordersEntities.Orders
                                     where o.OrderDetails.Priority > CurrentPriority
                                     select o).ToArrayAsync())
            {
                o.OrderDetails.Priority = o.OrderDetails.Priority - 1;
                ordersEntities.Entry(o).State = EntityState.Modified;
            }


            order.OrderDetails.Priority = -1;
            order.OrderDetails.Status = await getStatusIdByStatusName("Приостановлен");

            ordersEntities.SaveChanges();
            DatabaseChanged();
            return true;
        }

        public static async Task<bool> fromSuspendedToActiveOrder(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            Orders order = await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync();
            order.OrderDetails.Priority = await getMaxPriority() + 1;
            order.OrderDetails.Status = await getStatusIdByStatusName("Выполняется");
            ordersEntities.SaveChanges();
            DatabaseChanged();
            return true;
        }

        public static async Task<bool> fromSuspendedToCanceledOrder(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            Orders order = await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync();
            order.OrderDetails.Priority = -1;
            order.OrderDetails.Status = await getStatusIdByStatusName("Отменен");
            ordersEntities.SaveChanges();
            DatabaseChanged();
            return true;
        }

        public static async Task<int> getStatusIdByStatusName(string StatusName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            switch (StatusName)
            {
                case "Выполняется":
                    return await (from o in ordersEntities.OrderStatuses
                                 where o.StatusName.Equals(StatusName) select o.Id).FirstAsync();
                case "Выполнен":
                    return await (from o in ordersEntities.OrderStatuses
                                  where o.StatusName.Equals(StatusName)
                                  select o.Id).FirstAsync();
                case "Отменен":
                    return await (from o in ordersEntities.OrderStatuses
                                  where o.StatusName.Equals(StatusName)
                                  select o.Id).FirstAsync();
                case "Приостановлен":
                    return await (from o in ordersEntities.OrderStatuses
                                  where o.StatusName.Equals(StatusName)
                                  select o.Id).FirstAsync();

                default: return -1;
            }

        }        

        public static async Task<bool> increasePriority(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            int OrderPriority = await getPriorityById(OrderId);

            if ((await getMaxPriority()).Equals(OrderPriority))
                return true;
            else
            {
                Orders nextOrder = await (from o in ordersEntities.Orders
                                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                          && o.OrderDetails.Priority.Equals(OrderPriority + 1)
                                          select o).FirstAsync();

                Orders order = (await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync());

                int o2Priority = nextOrder.OrderDetails.Priority;
                nextOrder.OrderDetails.Priority = order.OrderDetails.Priority;
                order.OrderDetails.Priority = o2Priority;
                
                await ordersEntities.SaveChangesAsync();
                DatabaseChanged();
                return true;
            }
        }

        public static async Task<bool> decreasePriority(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            int OrderPriority = await getPriorityById(OrderId);

            if ((await getMinPriority()).Equals(OrderPriority))
                return true;
            else
            {
                Orders nextOrder = await (from o in ordersEntities.Orders
                                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                          && o.OrderDetails.Priority.Equals(OrderPriority - 1)
                                          select o).FirstAsync();

                Orders order = (await ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync());

                int o2Priority = nextOrder.OrderDetails.Priority;
                nextOrder.OrderDetails.Priority = order.OrderDetails.Priority;
                order.OrderDetails.Priority = o2Priority;

                ordersEntities.SaveChanges();
                DatabaseChanged();
                return true;
            }
        }

        public static async Task<int> getMaxPriority()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          select o.OrderDetails.Priority).MaxAsync();
        }

        public static async Task<int> getPriorityById(int OrderId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return (await (ordersEntities.Orders.Where(o => o.Id.Equals(OrderId)).FirstAsync())).OrderDetails.Priority;
        }

        public static async Task<int> getMinPriority()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (from o in ordersEntities.Orders
                          where o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                          select o.OrderDetails.Priority).MinAsync();
        }        

        #endregion

        #region Queue orders queries

        public static async Task<List<Orders>> getActiveOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await ordersEntities.Orders
                                       .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                                 && (o.OrderDetails
                                                    .OrderStatuses
                                                    .StatusName.Equals("Выполняется")))

                                                    .ToListAsync();
        }


        public static async Task<List<Orders>> getSuspendedOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await ordersEntities.Orders
                                       .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                                 && o.OrderDetails
                                                    .OrderStatuses
                                                    .StatusName.Equals("Приостановлен"))
                                                    .ToListAsync();
        }

        public static async Task<List<Orders>> getEndedOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await ordersEntities.Orders
                                       .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                                 && 
                                                 (o.OrderDetails
                                                    .OrderStatuses
                                                    .StatusName.Equals("Выполнен")
                                                ||  o.OrderDetails
                                                    .OrderStatuses
                                                    .StatusName.Equals("Отменен")))
                                                    .ToListAsync();
        }


        #endregion

        #region Event properties

        public delegate void AddChangesHandler();

        public static event AddChangesHandler DatabaseChanged;        

        #endregion

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

        #region History orders queries

        public static async Task<List<Orders>> getHistoryOrdersByCompanyNameAndUserId(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.CompanyName.Equals(CompanyName)
                                        && o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен") 
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllHistoryOrdersByCompanyName(string CompanyName)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.CompanyName.Equals(CompanyName)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен")
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getHistoryOrdersByCustomerIdAndUserId(int customerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                        && o.Customers.Id.Equals(customerId)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен")
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllHistoryOrdersByCustomerId(int customerId)
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.Customers.Id.Equals(customerId)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен")
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getHistoryOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен")
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getAllHistoryOrders()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders.Where(o =>  (o.OrderDetails.OrderStatuses.StatusName.Equals("Отменен")
                                                         || o.OrderDetails.OrderStatuses.StatusName.Equals("Выполнен")))
                         .ToListAsync());
        }



        #endregion

        #region Orders queries


        public static async Task<bool> AddOrder(    
                                                    int CustomerId,
                                                    string OrderDescription,
                                                    int ServieceCost,
                                                    int ServieceCount,
                                                    int Discount  
            
                                               )
        {
            using (OrdersEntities orderEntities = new OrdersEntities())
            {
                using (var transaction = orderEntities.Database.BeginTransaction())
                {
                    try
                    {
                        List<int> PriorityList = await (from o in orderEntities.Orders
                                       where o.CustomerId.Equals(CustomerId)
                                       select o.OrderDetails.Priority).ToListAsync();

                        int priority = 1;

                        if (PriorityList.Count() != 0)
                            priority = PriorityList.Max() + 1;


                        int StatusId = orderEntities.OrderStatuses.Where(s => s.StatusName.Equals("Выполняется")).First().Id;


                        orderEntities.OrderDetails.Add(new OrderDetails() {

                            OrderDescription = OrderDescription,
                            Priority = priority,
                            Status = StatusId,
                            OrderDate = DateTime.Now.ToString(),
                            Quantity = ServieceCount,
                            UnitPrice = ServieceCost,
                            Discount = Discount

                        });

                        if(await orderEntities.SaveChangesAsync() != 0)
                        {
                            int orderDetailsId = await orderEntities.OrderDetails.Select(o => o.Id).MaxAsync();

                            orderEntities.Orders.Add(new Orders()
                            {

                                CustomerId = CustomerId,
                                EmployeeId = MainViewModel.CurrentUserId,
                                OrderDetailsId = orderDetailsId

                            });

                            if (await orderEntities.SaveChangesAsync() != 0)
                            {
                                DatabaseChanged();
                                transaction.Commit();
                                return true;
                            }

                        }


                        transaction.Rollback();
                        return false;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public static async Task<bool> AddOrderWithNewCustomer(
            
                                                    string CustomerCompanyName,
                                                    string CustomerFistName,
                                                    string CustomerLastName,
                                                    string CompanyAdress,
                                                    string PhoneNumber,
                                                    string OrderDescription,
                                                    int ServieceCost,
                                                    int ServieceCount,
                                                    int Discount   
                                                )
        {
        using (OrdersEntities orderEntities = new OrdersEntities())
        {
            using (var transaction = orderEntities.Database.BeginTransaction())
            {
                try
                {

                        orderEntities.Customers.Add(new Customers()
                        {
                            CompanyName = CustomerCompanyName,
                            ContactFirstName = CustomerFistName,
                            ContactLastName = CustomerLastName,
                            ContactAdress = CompanyAdress,
                            ContactPhone = PhoneNumber
                        });

                        await orderEntities.SaveChangesAsync();

                        int customerId = orderEntities.Customers.Select(c => c.Id).Max();

                        int StatusId = orderEntities.OrderStatuses.Where(s => s.StatusName.Equals("Выполняется")).First().Id;

                        List<int> PriorityList = await (from o in orderEntities.Orders
                                                        where o.CustomerId.Equals(customerId)
                                                        select o.OrderDetails.Priority).ToListAsync();

                        int priority = 1;

                        if (PriorityList.Count() != 0)
                            priority = PriorityList.Max() + 1;


                        orderEntities.OrderDetails.Add(new OrderDetails()
                        {

                            OrderDescription = OrderDescription,
                            Priority = priority,
                            Status = StatusId,
                            OrderDate = DateTime.Now.ToString(),
                            Quantity = ServieceCount,
                            UnitPrice = ServieceCost,
                            Discount = Discount

                        });

                        await orderEntities.SaveChangesAsync();
                        
                        int orderDetailsId = await orderEntities.OrderDetails.Select(o => o.Id).MaxAsync();

                        orderEntities.Orders.Add(new Orders()
                        {

                            CustomerId = customerId,
                            EmployeeId = MainViewModel.CurrentUserId,
                            OrderDetailsId = orderDetailsId

                        });

                        await orderEntities.SaveChangesAsync();

                        DatabaseChanged();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
        }

        }


        public static async Task<bool> UpdateOrder(
                                                    int OrderDetailsId,
                                                    int CustomerId,
                                                    string NewCompanyAdress,
                                                    string NewPhoneNumber,
                                                    string NewOrderDescription,
                                                    int NewServieceCost,
                                                    int NewServieceCount,
                                                    int NewDiscount
            )
        {
            using (OrdersEntities orderEntities = new OrdersEntities())
            {
                using (var transaction = orderEntities.Database.BeginTransaction())
                {
                    try
                    {

                        Customers customer = await orderEntities.Customers.Where(c => c.Id.Equals(CustomerId)).FirstAsync();

                        customer.ContactAdress = NewCompanyAdress;
                        customer.ContactPhone = NewPhoneNumber;

                        OrderDetails orderDetails = await orderEntities.OrderDetails.Where(o => o.Id.Equals(OrderDetailsId)).FirstAsync();

                        orderDetails.OrderDescription = NewOrderDescription;
                        orderDetails.UnitPrice = NewServieceCost;
                        orderDetails.Quantity = NewServieceCount;
                        orderDetails.Discount = NewDiscount;

                        await orderEntities.SaveChangesAsync();

                        MessageBox.Show("Заказ успешно изменен");
                        DatabaseChanged();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }


        public static async Task<bool> IsOrderAndCustomerExist(

                                                    int OrderId,
                                                    int CustomerId,
                                                    int OrderDetailsId,
                                                    string NewCompanyAdress,
                                                    string NewPhoneNumber,
                                                    string NewOrderDescription,
                                                    int NewServieceCost,
                                                    int NewServieceCount,
                                                    int NewDiscount
            )
        {

            OrdersEntities orderEntities = new OrdersEntities();

            if (await orderEntities.Orders.Where(o => o.Id.Equals(OrderId)
                                        && o.OrderDetailsId.Equals(OrderDetailsId)
                                        && o.CustomerId.Equals(CustomerId)
                                        && o.Customers.ContactAdress.Equals(NewCompanyAdress)
                                        && o.Customers.ContactPhone.Equals(NewPhoneNumber)
                                        && o.OrderDetails.OrderDescription.Equals(NewOrderDescription)
                                        && o.OrderDetails.UnitPrice.Equals(NewServieceCost)
                                        && o.OrderDetails.Quantity.Equals(NewServieceCount)
                                        && o.OrderDetails.Discount.Equals(NewDiscount)).CountAsync() != 0)
                return true;
            else
                return false;
        }

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

        public static async Task<List<Orders>> getOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders
                                        .Where(o => o.EmployeeId.Equals(MainViewModel.CurrentUserId))
                                        .ToListAsync());
        }

        public static async Task<List<Orders>> getChangeableOrdersByUserId()
        {
            OrdersEntities ordersEntities = new OrdersEntities();

            return await (ordersEntities.Orders.Where( o =>
                                        o.EmployeeId.Equals(MainViewModel.CurrentUserId)
                                        && (o.OrderDetails.OrderStatuses.StatusName.Equals("Выполняется")
                                        || o.OrderDetails.OrderStatuses.StatusName.Equals("Приостановлен")))
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
