using System;

namespace rpg.data
{
    public class Character
    {
        // no default vals would be assigned...
        public int id { get; set; } 
        public string name { get; set; }
        public string HitPoints { get; set; }
        public int Strength { get; set; } 
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        // we will work with enum val of classes 
        public RpgClass rgpclass { get; set; }



    }
}
