using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestApp
{
    public class DateTimeModel
    {   
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required]
        public string DateTimePressed { get; set; }
    }
}
