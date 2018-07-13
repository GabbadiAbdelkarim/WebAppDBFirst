using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Citoyen
    {
        public int Id { get; set; }
        public int IdCarte { get; set; }
        public int IdAdresse { get; set; }
        public int IdCompte { get; set; }
        public int IdRelation { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }

        public Adresse IdAdresseNavigation { get; set; }
        public CarteIdentite IdCarteNavigation { get; set; }
        public Compte IdCompteNavigation { get; set; }
        public Relation IdRelationNavigation { get; set; }
    }
}
