using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emde.kz.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string SrcYandexCity { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}