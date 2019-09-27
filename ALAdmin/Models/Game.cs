using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAdmin.Models
{
    class Game
    {
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string StudioName { get; set; }
        public string ExePath { get; set; }
        public string VideoPath { get; set; }
        //public string LogoPath { get; set; }
        public string Blurb { get; set; }
        public string Engine { get; set; }
        public string Genre { get; set; }
        public string Setting { get; set; }
        public string Rendering { get; set; }
        public string Competition { get; set; }
        public string Physics { get; set; }
        public string Sound { get; set; }
        public string Input { get; set; }
        public string Players { get; set; }
        public string TeamMembers { get; set; }
    }
}
