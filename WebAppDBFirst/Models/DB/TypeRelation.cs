using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class TypeRelation
    {
        public TypeRelation()
        {
            Relation = new HashSet<Relation>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public ICollection<Relation> Relation { get; set; }
    }
}
