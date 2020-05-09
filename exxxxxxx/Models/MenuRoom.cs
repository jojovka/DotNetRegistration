using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class MenuRoom
    {
        public int MenuRoomId { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
