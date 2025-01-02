﻿namespace NetProject.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } // Active, Closed
    }
}
