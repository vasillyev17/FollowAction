using System;
using System.ComponentModel.DataAnnotations;

namespace FollowAction1._0.Models
{
    public class Buyer
    {
            [Key]
            public int idBuyer { get; set; }
            public string Priority { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
    }
}
