using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson2.Models
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews(bool isFake);

        void UpdateSingleNews(News news);

        void UpdateAllNews(List<News> news);

        void AddNews(News news);
    }
}
