using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class SqlStoryRepository : IStoryRepository
    {
        private readonly FictionDbContext _dbContext;

        public SqlStoryRepository(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Story story)
        {
            _dbContext.Add(story);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Story> GetAll()
        {
            return _dbContext.Stories;
        }
    }
}
