using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Pays
    {
        public Pays()
        {
            Adresse = new HashSet<Adresse>();
            Ville = new HashSet<Ville>();
        }

        public int Id { get; set; }
        public int? Code { get; set; }
        public string Libelle { get; set; }

        public ICollection<Adresse> Adresse { get; set; }
        public ICollection<Ville> Ville { get; set; }
    }
}
