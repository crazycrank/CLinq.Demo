using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CLinq.Demo.Database;

namespace CLinq.Demo.Expressions
{
    public static class StoreExpressions
    {
        public static Expression<Func<Customer, bool>> CustomerHasOrders => c => c.SalesOrderHeaders.Any();

        public static Expression<Func<Store, bool>> HasOrders => s => s.Customers.Any(c => CustomerHasOrders.Pass(c));

        public static Expression<Func<Store, bool>> HasCustomers => s => s.Customers.Any();

        public static Expression<Func<Store, IEnumerable<SalesOrderHeader>>> OrdersOfStore => s => s.Customers.SelectMany(c => c.SalesOrderHeaders);

        public static Expression<Func<Store, IEnumerable<RevenuePerYear>>> RevenuePerYear => s => OrdersOfStore.Pass(s)
                                                                                                               .GroupBy(oh => oh.OrderDate.Year)
                                                                                                               .Select(grouped => new RevenuePerYear
                                                                                                                                  {
                                                                                                                                      Year = grouped.Key,
                                                                                                                                      Revenue = RevenueOfOrders.Pass(grouped.Select(od => od))
                                                                                                                                  });

        public static Expression<Func<IEnumerable<SalesOrderHeader>, decimal>> RevenueOfOrders => orders => orders.Select(o => SalesExpressions.OrderPrice.Pass(o)).Sum();
    }
}
