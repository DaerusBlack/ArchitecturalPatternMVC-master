using BLL.DesignPatterns.GenericRepositoryPattern.BaseRep;
using DAL.Context;
using ENTITIES.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DesignPatterns.GenericRepositoryPattern.ConcRep
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
