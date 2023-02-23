using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module.Models
{
    public class SongArtist
    {
        public int SongId { get; set; }
        public int ArtistId { get; set;}
        public virtual Song Song { get; set; }
        public virtual Artist Artist { get; set; }  
    }
}
