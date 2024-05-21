using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models.ViewModels
{
    public class BookShowVM
    {
        public List<Theatre> Theatres { get; set; } 
        public Movie Movie { get; set; } 
        public Dictionary<Guid, DateTimeData[]> ShowsData { get; set; } 
    }
    public class DateTimeData
    {
        public DateOnly Date { get; set; }
        public Dictionary<TimeOnly, Guid> Time { get; set; }
    }
}
