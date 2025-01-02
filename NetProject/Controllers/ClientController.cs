using Microsoft.AspNetCore.Mvc;
using NetProject.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private static List<Client> clients = new List<Client>
        {
            new Client { Id = 1, Name = "John Doe", PhoneNumber = "050-1234567" },
            new Client { Id = 2, Name = "Jane Smith", PhoneNumber = "050-7654321" },
            new Client { Id = 3, Name = "David Cohen", PhoneNumber = "052-9876543" }
        };

        // GET: api/Client
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return clients;
        }

        // GET api/Client/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return clients.FirstOrDefault(c => c.Id == id);
        }

        // POST api/Client
        [HttpPost]
        public void Post([FromBody] Client newClient)
        {
            newClient.Id = clients.Any() ? clients.Max(c => c.Id) + 1 : 1;
            clients.Add(newClient);
        }

        // PUT api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client updatedClient)
        {
            foreach (var existingClient in clients)
            {
                if (existingClient.Id == id)
                {
                    // עדכון הערכים של הלקוח
                    existingClient.Name = updatedClient.Name;
                    existingClient.PhoneNumber = updatedClient.PhoneNumber;
                }
            }
        }

        // DELETE api/Client/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == id)
                {
                    // מחיקת הלקוח מהרשימה
                    clients.RemoveAt(i);
                    break;
                }
            }
        }
    }
}