﻿namespace Resuaurants.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int? KiloCalories { get; set; }
        public decimal Price { get; set; }

        public int RestaurantsId { get; set; }
    }
}
