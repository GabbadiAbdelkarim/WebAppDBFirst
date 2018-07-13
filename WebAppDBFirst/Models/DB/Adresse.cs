using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Adresse
    {
        public Adresse()
        {
            Citoyen = new HashSet<Citoyen>();
        }

        public int Id { get; set; }
        public int IdPays { get; set; }
        public string Rue { get; set; }
        public int? CodePostal { get; set; }
        public bool? AdresseActuelle { get; set; }

        public Pays IdPaysNavigation { get; set; }
        public ICollection<Citoyen> Citoyen { get; set; }
    }
}
