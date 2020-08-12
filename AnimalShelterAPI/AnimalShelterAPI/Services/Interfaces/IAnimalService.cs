using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalShelterAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelterAPI.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<AnimalDto> GetById(int id);
        Task<ICollection<AnimalListItemDto>> GetAll();
        Task<AnimalDto> Create(AnimalDto newItem);
        Task Update(int id, AnimalDto updateData);
        Task<bool> PartialUpdate(int id, JsonPatchDocument<AnimalDto> itemPatch);
        Task<bool> Delete(int id);
    }
}
