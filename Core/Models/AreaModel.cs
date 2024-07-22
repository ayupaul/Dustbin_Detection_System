using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AreaModel
    {
        [Key]
        public int AreaId { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress  { get; set; }
        public string? AreaInspector { get; set; }

    }
}
