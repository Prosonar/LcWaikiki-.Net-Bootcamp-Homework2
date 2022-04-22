using Core.DataAccess.BaseRepositories;
using EntityFrameworkMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Abstract
{
    public interface ISchoolTypeDao : IEntityRepository<SchoolType>
    {
    }
}
