using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class BuyerAction
    {
        [Key]
        public int idAction { get; set; }
        public int idBuyer { get; set; }
        public string actionType { get; set; }
        public string actionTarget { get; set; }
    }
}
