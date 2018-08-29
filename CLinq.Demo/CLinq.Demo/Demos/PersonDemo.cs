using System;
using System.Linq;
using CLinq.Demo.Database;

namespace CLinq.Demo.Demos
{
    public static class PersonDemo
    {
        public static void Run()
        {
            using (var ctx = new Entities())
            {
                var names = ctx.People
                               .Take(100)
                               .Select(p => new
                                            {
                                                p.FirstName,
                                                p.LastName
                                            });

                foreach (var name in names)
                {
                    Console.Out.WriteLine(name);
                }
            }
        }
    }
}