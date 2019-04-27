using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHerosProject.Models
{
    public class Superheros
    {
            [Key]
            public int Id { get; set; } //represents Primary Key

            public string Name { get; set; }
            public string AlterEgo { get; set; }
            public string PrimarySuperheroAbility { get; set; }
            public string SecondarySuperHeroAbility { get; set; }
            public string CatchPhrase { get; set; }
    }

}
