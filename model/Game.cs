using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.model
{
    internal class Game
    {
            public int Id { get; set; }
            public string Title { get; set; } 
            public string Studio { get; set; } 
            public string Genre { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Mode { get; set; }
            public int CopiesSold { get; set; }
    }
}
