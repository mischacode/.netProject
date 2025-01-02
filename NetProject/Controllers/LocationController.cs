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
        public ActionResult<IEnumerable<Location>> Get()
        {
            return Ok(locations); // מחזיר את כל המיקומים עם קוד סטטוס 200 (OK)
        }

        // GET api/Location/5
        [HttpGet("{id}")]
        public ActionResult<Location> Get(int id)
        {
            var location = locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound(); // אם המיקום לא נמצא, מחזיר קוד 404
            }
            return Ok(location); // מחזיר את המיקום עם קוד סטטוס 200 (OK)
        }

        // POST api/Location
        [HttpPost]
        public ActionResult<Location> Post([FromBody] Location newLocation)
        {
            newLocation.Id = locations.Any() ? locations.Max(l => l.Id) + 1 : 1;
            locations.Add(newLocation);
            return CreatedAtAction(nameof(Get), new { id = newLocation.Id }, newLocation); // מחזיר קוד 201 עם המיקום שנוצר
        }

        // PUT api/Location/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Location updatedLocation)
        {
            var existingLocation = locations.FirstOrDefault(l => l.Id == id);
            if (existingLocation == null)
            {
                return NotFound(); // אם המיקום לא נמצא, מחזיר קוד 404
            }

            // עדכון המיקום
            existingLocation.Name = updatedLocation.Name;
            existingLocation.Address = updatedLocation.Address;
            existingLocation.Status = updatedLocation.Status;

            return NoContent(); // מחזיר קוד 204 (אין תוכן) לאחר עדכון מוצלח
        }

        // DELETE api/Location/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var location = locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound(); // אם המיקום לא נמצא, מחזיר קוד 404
            }

            locations.Remove(location);
            return NoContent(); // מחזיר קוד 204 (אין תוכן) לאחר מחיקה מוצלחת
        }
    }
}
