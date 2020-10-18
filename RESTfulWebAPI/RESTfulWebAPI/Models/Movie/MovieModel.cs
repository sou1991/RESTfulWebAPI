using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Models
{
    public class MovieModel
    {
        public int id { get; set; }

        public string title { get; set; }

        public string film_director { get; set; }

        public DateTime release_date { get; set; }
    }
}
