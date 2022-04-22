using Core.DataAccess.EntityFramework;
using EntityFrameworkMigration.DataAccess.Abstract;
using EntityFrameworkMigration.DataAccess.Contexts;
using EntityFrameworkMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Operations
{
    public class EFSchoolTypeDao : EfEntityRepositoryBase<SchoolType, MigrationContext>,ISchoolTypeDao
    {
    }
}
