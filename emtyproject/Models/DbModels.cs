using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace emtyproject.Models
{
    public enum Grade
    {
        M01=1, M02, G01, G02 ,EX01, Ex02
    }
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Required,StringLength(100),Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required,DataType(DataType.Date),Column("date"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime JoinDate { get; set; }
        [Required,EnumDataType(typeof(Grade))]
        public Grade Grade { get; set; }
    }
    public class EmployeeDbContext : DbContext
    { 
        public DbSet<Employee> Employees { get; set;}
    }
    
}