using AnimalShelterAPI.Models.DTO;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Hubs
{
    public class AnimalHub : Hub
    {
        public async Task SendCreatedProduct(AnimalDto animal)
        {
            await Clients.Others.SendAsync("ReceiveCreatedAnimal", animal);
        }
    }
}
