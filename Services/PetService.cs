using PetStore.API.Database.Context;
using PetStore.API.Database.Entities;
using PetStore.API.Interfaces;
using PetStore.API.Models;
using PetStore.API.Models.Pet.CreateModels;
using PetStore.API.Models.Pet.UpdateModels;
using PetStore.API.Models.Pet.ViewModels;

namespace PetStore.API.Services
{
    public class PetService : IPetService
    {
        private readonly PetShopContext db;

        public PetService(PetShopContext db)
        {
            this.db = db;
        }

        CustomResponseModel<IEnumerable<PetViewModel>> IPetService.GetAll()
        {
            var pets = db.Pet.ToList();

            var petViewModels = new List<PetViewModel>();

            foreach (var pet in pets)
            {
                petViewModels.Add(new()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Age = pet.Age,
                    Breed = pet.Breed,
                    Price = pet.Price
                });
            }

            return new CustomResponseModel<IEnumerable<PetViewModel>>()
            {
                StatusCode = 200,
                Result = petViewModels
            };
        }

        CustomResponseModel<PetViewModel> IPetService.GetById(int id)
        {
            var pet = db.Pet.FirstOrDefault(x => x.Id == id);

            if (pet == null)
                return new CustomResponseModel<PetViewModel>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Not found in Database"
                };
            
            var petViewModel = new PetViewModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                Breed = pet.Breed,
                Price = pet.Price
            };

            return new CustomResponseModel<PetViewModel>()
            {
                StatusCode = 200,
                Result = petViewModel
            };
        }

        CustomResponseModel<bool> IPetService.Create(PetCreateModel petCreateModel)
        {
            var pet = new Pet()
            {
                Name = petCreateModel.Name,
                Age = petCreateModel.Age,
                Breed = petCreateModel.Breed,
                Price = petCreateModel.Price
            };

            db.Pet.Add(pet);
            db.SaveChanges();

            return new CustomResponseModel<bool>()
            {
                StatusCode = 200,
                Result = true
            };
        }

        CustomResponseModel<bool> IPetService.Update(PetUpdateModel petUpdateModel)
        {
            var pet = db.Pet.FirstOrDefault(x => x.Id == petUpdateModel.Id);

            if (pet == null)
                return new CustomResponseModel<bool>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Not found in Database",
                    Result = false
                };
            
            var resultPet = new Pet()
            {
                Id = petUpdateModel.Id,
                Name = petUpdateModel.Name,
                Age = petUpdateModel.Age,
                Breed = petUpdateModel.Breed,
                Price = petUpdateModel.Price
            };

            db.Update(resultPet);
            db.SaveChanges();

            return new CustomResponseModel<bool>()
            {
                StatusCode = 200,
                Result = true
            };
        }

        CustomResponseModel<bool> IPetService.Delete(int id)
        {
            var pet = db.Pet.FirstOrDefault(x => x.Id == id);

            if (pet == null)
                return new CustomResponseModel<bool>()
                {
                    StatusCode = 400,
                    ErrorMessage = "Not found in Database",
                    Result = false
                };

            db.Pet.Remove(pet);
            db.SaveChanges();

            return new CustomResponseModel<bool>()
            {
                StatusCode = 200,
                Result = true
            };
        }
    }
}
