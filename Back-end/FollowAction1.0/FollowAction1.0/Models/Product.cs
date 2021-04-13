using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }
        public int idDepartment { get; set; }
        public string Info { get; set; }
    }
}
