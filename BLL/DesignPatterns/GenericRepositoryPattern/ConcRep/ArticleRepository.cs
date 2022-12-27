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
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
