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

        public IEnumerable<News> GetNews(bool isFake)
        {
            return _dbContext.News.Where(x => x.IsFake == isFake);
        }

        public void UpdateSingleNews(News news)
        {
            var singleNews = _dbContext.News.FirstOrDefault(x => x.Id == news.Id);
            
            singleNews.IsFake = news.IsFake;
            singleNews.Text = news.Text;
            singleNews.Title = news.Title;
            singleNews.AuthorName = news.AuthorName;

            _dbContext.SaveChanges();
        }

        public void UpdateAllNews(List<News> news)
        {
            var currentNews = _dbContext.News.ToList();
            _dbContext.RemoveRange(currentNews);
            _dbContext.AddRange(news);

            _dbContext.SaveChanges();
        }

        public void AddNews(News news)
        {
            if (!_dbContext.News.Any(x => x.Id == news.Id))
            {
                _dbContext.Add(news);
            }

            _dbContext.SaveChanges();
        }
    }
}
