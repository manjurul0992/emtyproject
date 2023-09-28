using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace emtyproject.Models.ViewModels
{
    public class EmployeeViewModel
    {

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Required, StringLength(100), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, DataType(DataType.Date), Column("date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }
        [Required, EnumDataType(typeof(Grade))]
        public Grade Grade { get; set; }
        public string Tanure
        {
            get
            {
                var y = (DateTime.Now - this.JoinDate).Days / 365;
                int m = (DateTime.Now - this.JoinDate).Days % 365 / 30;
                return $"{y} Year {m} Month";
            }
        }
    }
}