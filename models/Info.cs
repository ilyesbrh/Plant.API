using System;

namespace Plant.API.models
{
    public class Info
    {
        public int id {set;get;}
        public string Version { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool ReadyToUse { get; set; }
        public double HowMuchDone { get; set; }
        public int UsersNumber { get; set; }
        public int AdminsNumber { get; set; }



    }
}