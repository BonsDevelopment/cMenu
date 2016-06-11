using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cMenu.Events
{
    public class MenuItemChangedEventArgs
    {
        public DateTime DateAndTime { get; set; }
        public int ChangedCount { get; set; }
    }
}
