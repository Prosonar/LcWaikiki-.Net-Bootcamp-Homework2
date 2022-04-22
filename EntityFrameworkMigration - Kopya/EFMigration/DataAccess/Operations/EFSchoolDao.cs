using Core.DataAccess.EntityFramework;
using EntityFrameworkMigration.DataAccess.Abstract;
using EntityFrameworkMigration.DataAccess.Contexts;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Operations
{
    public class EFSchoolDao : EfEntityRepositoryBase<School, MigrationContext>, ISchoolDao
    {
        public List<SchoolDetail> GetSchoolsWithDetails(Expression<Func<School, bool>> filter = null)
        {
            var schools = this.GetAll(filter);
            using (MigrationContext context = new MigrationContext())
            {
                var result = from c in schools
                             join b in context.Cities
                             on c.CityId equals b.Id
                             join r in context.SchoolTypes
                             on c.SchoolTypeId equals r.Id
                             select new SchoolDetail
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 CityName = b.Name,
                                 SchoolTypeName = r.Name,
                             };

                return result.ToList();
            }
        }
    }
}
