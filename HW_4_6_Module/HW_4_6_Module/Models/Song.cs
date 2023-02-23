﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Module.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int? GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual List<SongArtist> Artist { get; set; } = new List<SongArtist>();
    }
}
