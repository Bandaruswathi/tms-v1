using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Models
{
    public class MstStaff
    {
        [Key]
        public Int32 Id { get; set; }
        public String StaffName { get; set; }
        public String ContactNumber { get; set; }
        public Boolean IsLocked { get; set; }
    }
}