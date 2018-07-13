using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Relation
    {
        public Relation()
        {
            Citoyen = new HashSet<Citoyen>();
        }

        public int Id { get; set; }
        public int IdTypeRelation { get; set; }

        public TypeRelation IdTypeRelationNavigation { get; set; }
        public ICollection<Citoyen> Citoyen { get; set; }
    }
}
