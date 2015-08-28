using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage.Models
{
    public class FordonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Fordontype Fordontyp { get; set; }
        public string Färg { get; set; }
        public string Regnr { get; set; }
        public string Märke { get; set; }
        public string Modell { get; set; }
        public string Ägare { get; set; }
        public DateTime Parkerad { get; set; }
    }

    public class FordonModelPagedList
    {
        public PagedList.IPagedList<FordonModel> list;
        public Fordontype fordonType;
    }
}