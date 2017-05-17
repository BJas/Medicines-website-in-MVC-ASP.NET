using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emde.kz.Models
{
    public class Hospital
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string SrcYandex { get; set; }
        public string SrcYandexLarge { get; set; }
        public int CityID { get; set; }

        public virtual City City { get; set; }
    }

}