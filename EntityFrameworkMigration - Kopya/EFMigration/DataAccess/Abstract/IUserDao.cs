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
    public interface IUserDao : IEntityRepository<User>
    {
        List<UserDetail> GetUsersWithDetails(Expression<Func<User, bool>> filter = null);
    }
}
