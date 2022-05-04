using RestCarStore.Garage.Domain.Enums;

namespace RestCarStore.Garage.Services.Dtos
{
    public struct CarDto
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Acessories Acessories { get; set; }
    }
}
