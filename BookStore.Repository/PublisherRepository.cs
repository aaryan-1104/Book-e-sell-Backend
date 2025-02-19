﻿using BookStore.Models.Models;
using BookStore.Models.ViewModels;

namespace BookStore.Repository
{
    public class PublisherRepository : BaseRepository
    {
        public ListResponse<Publisher> GetPublishers(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Publishers.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalRecords = query.Count();
            List<Publisher> publishers = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Publisher>()
            {
                Results = publishers,
                Totalrecords = totalRecords,
            };
        }

        public Publisher GetPublisher(int id)
        {
            return _context.Publishers.FirstOrDefault(c => c.Id == id);
        }

        public Publisher AddPublisher(Publisher publisher)
        {
            var entry = _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Publisher UpdatePublisher(Publisher publisher)
        {
            var entry = _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeletePublisher(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(c => c.Id == id);
            var entry = _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            return true;
        }


    }
}
