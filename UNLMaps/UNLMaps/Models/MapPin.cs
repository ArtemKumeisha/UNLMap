using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace UNLMaps.Models
{
    public class MapPin : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int Raiting { get; set; }
    }
}
