using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class BuyerMovement
    {
        [Key]
        public int idMovement { get; set; }
        public int idBuyer { get; set; }
        public string Duration { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
