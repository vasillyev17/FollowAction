using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class Department
    {
        [Key]
        public int idDepartment { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
