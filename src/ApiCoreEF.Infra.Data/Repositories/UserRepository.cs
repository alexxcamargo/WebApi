using ApiCoreEF.Domain.User;
using ApiCoreEF.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCoreEF.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiCoreEFContext context) : base(context)
        {
        }
    }
}
