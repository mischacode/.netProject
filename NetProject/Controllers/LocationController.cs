using Microsoft.AspNetCore.Mvc;
using NetProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private static List<Location> locations = new List<Location>
        {
            new Location { Id = 1, Name = "Tel Aviv Center", Address = "123 Dizengoff St", Status = "Active" },
            new Location { Id = 2, Name = "Jerusalem Mall", Address = "45 Malcha Mall", Status = "Active" },
            new Location { Id = 3, Name = "Haifa Port", Address = "78 HaNamal St", Status = "Closed" }
        };

        // GET: api/Location
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return locations;
        }

        // GET api/Location/5
        [HttpGet("{id}")]
        public Location Get(int id)
        {
            return locations.FirstOrDefault(l => l.Id == id);
        }

        // POST api/Location
        [HttpPost]
        public void Post([FromBody] Location newLocation)
        {
            newLocation.Id = locations.Any() ? locations.Max(l => l.Id) + 1 : 1;
            locations.Add(newLocation);
        }

        // PUT api/Location/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Location updatedLocation)
        {
            foreach (var existingLocation in locations)
            {
                if (existingLocation.Id == id)
                {
                    // עדכון הערכים של המיקום
                    existingLocation.Name = updatedLocation.Name;
                    existingLocation.Address = updatedLocation.Address;
                    existingLocation.Status = updatedLocation.Status;
                }
            }
        }

        // DELETE api/Location/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].Id == id)
                {
                    // מחיקת המיקום מהרשימה
                    locations.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
