using System;
using System.Linq.Expressions;
using CLinq.Demo.Database;

namespace CLinq.Demo.Expressions
{
    public static class PersonExpressions
    {
        public enum FullNameFormat
        {
            LastFirst,
            FirstLast
        }

        public static Expression<Func<Person, string>> FullName => p => p.FirstName + " " + p.LastName;

        public static Expression<Func<Person, string>> FullNameFormatted(FullNameFormat format)
        {
            switch (format)
            {
                case FullNameFormat.LastFirst:
                    return p => p.LastName + ", " + p.FirstName;
                case FullNameFormat.FirstLast:
                    return p => p.FirstName + " " + p.LastName;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public static Expression<Func<Person, bool>> IsEmployee
            => p => p.Employee != null;


        public static Expression<Func<Employee, int>> Age()
        {
            var today = DateTime.Today;
            return e => today.Year - e.BirthDate.Year;
        }
    }
}
