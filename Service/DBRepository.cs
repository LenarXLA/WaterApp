using System;
using System.Collections.Generic;
using System.Linq;
using WaterApp.Model;

namespace WaterApp.Service
{
    public class DBRepository
    {
        DataContext _context = new DataContext();

        public List<History> GetHistorys()
        {
            var time = DateTime.Now.ToShortDateString();

            var elements = _context.Historys.Where(s =>
                s.CurrentDate.Contains(time)
            );

            return elements.ToList();
        }

        public void AddHistory(History history)
        {
            _context.Historys.Add(history);
            _context.SaveChanges();
        }

        public void RemoveHistory(History history)
        {
            _context.Historys.Remove(history);
            _context.SaveChanges();
        }
    }
}
