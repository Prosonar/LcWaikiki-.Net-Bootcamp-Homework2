using Core.DataAccess.BaseRepositories;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Abstract
{
    public interface ISchoolDao : IEntityRepository<School>
    {
        List<SchoolDetail> GetSchoolsWithDetails(Expression<Func<School, bool>> filter = null);
    }
}
