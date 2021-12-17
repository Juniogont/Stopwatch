using StopWatchesCore.Data;
using StopWatchesCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StopWatchesCore.Services
{
    public class StopWatchService : IStopWatchService
    {
        
        public void CreateStopWatch(SotpWatch input)
        {
            using (var _context = new AppDbContext())
            {
                _context.SotpWatchs.Add(input);
            }
        }

        public SotpWatch GetStopWatch(int id)
        {
            using (var _context = new AppDbContext())
            {
                return _context.SotpWatchs.Find(id);
            }
        }
    }
}
