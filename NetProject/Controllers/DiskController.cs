using Microsoft.AspNetCore.Mvc;
using NetProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiskController : ControllerBase
    {
        private static List<Disk> disks = new List<Disk>
        {
            new Disk { Id = 1, SerialNumber = "SN12345", Status = "Waiting", LocationId = 1, ClientId = 1 },
            new Disk { Id = 2, SerialNumber = "SN67890", Status = "Collected", LocationId = 2, ClientId = 2 },
            new Disk { Id = 3, SerialNumber = "SN54321", Status = "Waiting", LocationId = 1, ClientId = 3 }
        };

        // GET: api/Disk
        [HttpGet]
        public IEnumerable<Disk> Get()
        {
            return disks;
        }

        // GET api/Disk/5
        [HttpGet("{id}")]
        public Disk Get(int id)
        {
            return disks.FirstOrDefault(d => d.Id == id);
        }

        // POST api/Disk
        [HttpPost]
        public void Post([FromBody] Disk newDisk)
        {
            newDisk.Id = disks.Any() ? disks.Max(d => d.Id) + 1 : 1;
            disks.Add(newDisk);
        }

        // PUT api/Disk/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Disk updatedDisk)
        {
            foreach (var existingDisk in disks)
            {
                if (existingDisk.Id == id)
                {
                    // עדכון הערכים של הדיסק
                    existingDisk.SerialNumber = updatedDisk.SerialNumber;
                    existingDisk.Status = updatedDisk.Status;
                    existingDisk.LocationId = updatedDisk.LocationId;
                    existingDisk.ClientId = updatedDisk.ClientId;
                }
            }
        }

        // DELETE api/Disk/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            for (int i = 0; i < disks.Count; i++)
            {
                if (disks[i].Id == id)
                {
                    // מחיקת הדיסק מהרשימה
                    disks.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
