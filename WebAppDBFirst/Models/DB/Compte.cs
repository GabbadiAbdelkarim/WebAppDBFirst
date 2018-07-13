using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Compte
    {
        public Compte()
        {
            Citoyen = new HashSet<Citoyen>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }

        public ICollection<Citoyen> Citoyen { get; set; }
    }
}
