using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage.Models
{
    public class NyhetModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Ämne { get; set; }
        [Required]
        public string Innehåll { get; set; }
        private DateTime? skapad;
        [Required]
        public DateTime Skapad
        {
            get
            {
                if (skapad == null)
                {
                    skapad = DateTime.Now;
                }
                return skapad.Value;
            }
            private set { skapad = value; }
        }
    }
}