using System.ComponentModel.DataAnnotations;

namespace PetStore.API.Models.Pet.UpdateModels
{
    public class PetUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
