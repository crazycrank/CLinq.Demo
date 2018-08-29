using System;
using System.Linq;
using CLinq.Demo.Database;
using CLinq.Demo.Expressions;

namespace CLinq.Demo.Demos
{
    static class RevenuePerYearDemo
    {
        public static void Run()
        {
            using (var ctx = new Entities())
            {
                var revenuePerYear = ctx.Stores
                                        .AsComposable()
                                        .Where(s => StoreExpressions.HasOrders.Pass(s))
                                        .OrderByDescending(s => StoreExpressions.RevenueOfOrders.Pass(StoreExpressions.OrdersOfStore.Pass(s)))
                                        .Take(1)
                                        .Select(s => StoreExpressions.RevenuePerYear.Pass(s))
                                        .AsEnumerable()
                                        .Single();


                foreach (var revenue in revenuePerYear.OrderBy(rpy => rpy.Year))
                {
                    Console.Out.WriteLine($"{revenue.Year}: {revenue.Revenue}");
                }
            }
        }
    }
}
