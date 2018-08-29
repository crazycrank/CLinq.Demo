using System;
using System.Linq;
using System.Linq.Expressions;
using CLinq.Demo.Database;

namespace CLinq.Demo.Expressions
{
    public static class SalesExpressions
    {
        public static Expression<Func<SalesOrderHeader, decimal>> OrderPrice => o => o.SalesOrderDetails.Sum(od => PricePerItem.Pass(od));

        public static Expression<Func<SalesOrderDetail, decimal>> PricePerItem => od => od.OrderQty * od.UnitPrice - (od.OrderQty * od.UnitPrice * od.UnitPriceDiscount);
    }
}