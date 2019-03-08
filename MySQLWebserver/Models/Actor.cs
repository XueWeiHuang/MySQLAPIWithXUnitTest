using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWebserver.Models
{
    
    public class Actor
    {
        [Key]
        public int actor_id { get; set; }
        public  string last_name { get; set; }
        public string first_name { get; set; }
    }
}
