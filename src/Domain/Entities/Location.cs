using System.Collections.Generic;

namespace CloudyMobile.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Keg> Kegs { get; set; }
    }
}
