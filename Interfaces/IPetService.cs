using PetStore.API.Models;
using PetStore.API.Models.Pet.CreateModels;
using PetStore.API.Models.Pet.UpdateModels;
using PetStore.API.Models.Pet.ViewModels;

namespace PetStore.API.Interfaces
{
    public interface IPetService
    {
        CustomResponseModel<IEnumerable<PetViewModel>> GetAll();
        CustomResponseModel<PetViewModel> GetById(int id);
        CustomResponseModel<bool> Create(PetCreateModel petCreateModel);
        CustomResponseModel<bool> Update(PetUpdateModel petUpdateModel);
        CustomResponseModel<bool> Delete(int id);
    }
}
