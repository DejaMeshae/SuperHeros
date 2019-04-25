using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHerosProject.Models
{
    public class Superheros
    {
        public class SuperherosIn
        {
            [Key]

            public int Id { get; set; } //represents Primary Key

            public string name { get; set; }
            public string alterEgo { get; set; }
            public string primarySuperheroAbility { get; set; }
            public string secondarySuperHeroAbility { get; set; }
            public string catchPhrase { get; set; }

        }
    }

}
}