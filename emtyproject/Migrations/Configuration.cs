namespace emtyproject.Migrations
{
    using emtyproject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<emtyproject.Models.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(emtyproject.Models.EmployeeDbContext context)
        {
            context.Employees.Add(new Employee { EmployeeName = "Syed", JoinDate = DateTime.Now.AddMonths(-12), Grade = Grade.EX01 });
            context.Employees.Add(new Employee { EmployeeName = "nayem", JoinDate = DateTime.Now.AddMonths(-24), Grade = Grade.Ex02 });
            context.Employees.Add(new Employee { EmployeeName = "aminul", JoinDate = DateTime.Now.AddMonths(-36), Grade = Grade.M01 });
            context.Employees.Add(new Employee { EmployeeName = "salah", JoinDate = DateTime.Now.AddMonths(-48), Grade = Grade.M02 });
            context.Employees.Add(new Employee { EmployeeName = "mohid", JoinDate = DateTime.Now.AddMonths(-60), Grade = Grade.G01 });
            context.SaveChanges();
        }
    }
}
