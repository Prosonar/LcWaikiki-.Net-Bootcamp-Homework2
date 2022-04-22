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
    public class EFUserDao : EfEntityRepositoryBase<User, MigrationContext>, IUserDao
    {
        public List<UserDetail> GetUsersWithDetails(Expression<Func<User, bool>> filter = null)
        {
            var users = this.GetAll(filter);
            using (MigrationContext context = new MigrationContext())
            {
                var result = from c in users
                             join b in context.Schools
                             on c.SchoolId equals b.Id
                             select new UserDetail
                             {
                                 Id = c.Id,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 PhoneNumber = c.PhoneNumber,
                                 SchoolName = b.Name
                             };

                return result.ToList();
            }
        }
    }
}
