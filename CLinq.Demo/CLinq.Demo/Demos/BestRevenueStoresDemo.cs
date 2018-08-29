using System;
using System.Linq;
using CLinq.Demo.Database;
using CLinq.Demo.Expressions;

namespace CLinq.Demo.Demos
{
    public static class BestRevenueStoresDemo
    {
        public static void Run()
        {
            using (var ctx = new Entities())
            {
                var revenues = ctx.Stores
                                  .AsComposable()
                                  .Where(s => StoreExpressions.HasOrders.Pass(s))
                                  .Select(s => new
                                               {
                                                   s.Name,
                                                   Revenue = StoreExpressions.RevenueOfOrders.Pass(StoreExpressions.OrdersOfStore.Pass(s))
                                               })
                                  .OrderByDescending(s => s.Revenue)
                                  .Take(10);

                foreach (var revenue in revenues)
                {
                    Console.Out.WriteLine(revenue);
                }
            }
        }
    }
}