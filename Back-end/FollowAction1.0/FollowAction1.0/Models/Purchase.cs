using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class Purchase
    {
        [Key]
        public int idPurchase { get; set; }
        public int idBuyer { get; set; }
        public int idProduct { get; set; }
    }
}
