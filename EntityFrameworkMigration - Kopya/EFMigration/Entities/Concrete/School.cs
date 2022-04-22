using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Entities
{
    public class School : IEntity
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int SchoolTypeId { get; set; }
        //public SchoolType SchoolType { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
    }
}
