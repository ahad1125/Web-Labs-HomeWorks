namespace HW4.Models
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal pricePerDay { get; set; }

        public Car() { }

        public Car(int id, string name, decimal pricePerDay)
        {
            this.id = id;
            this.name = name;
            this.pricePerDay = pricePerDay;
        }
    }
}
