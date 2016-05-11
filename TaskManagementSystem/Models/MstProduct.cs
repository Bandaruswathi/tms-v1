using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Models
{
    public class MstProduct
    {
        [Key]
        public Int32 Id { get; set; }
        public String ProductCode { get; set; }
        public String ProductDescription { get; set; }
        public Boolean IsLocked { get; set; }
    }
}