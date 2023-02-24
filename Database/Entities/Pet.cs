namespace PetStore.API.Database.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public decimal Price { get; set; }
    }
}
