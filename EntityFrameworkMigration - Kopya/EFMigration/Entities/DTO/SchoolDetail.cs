using EntityFrameworkMigration.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Entities.DTO
{
    public class SchoolDetail : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SchoolTypeName { get; set; }
        public string CityName { get; set; }
    }
}
