using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson2.Models
{
    public class SqlNewsRepository : INewsRepository
    {
        private readonly NewsDbContext _dbContext;

        public SqlNewsRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<News> GetNews()
        {
            return _dbContext.News;
        }
    }
}
