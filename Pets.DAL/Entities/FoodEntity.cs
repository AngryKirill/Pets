namespace Pets.DAL.Entities
{
    public class FoodEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProducingCountry { get; set; }
        public int Calories { get; set; }
    }
}
