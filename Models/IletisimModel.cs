using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class IletisimModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public IEnumerable<SelectListItem> CinsiyetSecimi { get; set; }
        public string SecilenCinsiyet { get; set; }
   


    }
}