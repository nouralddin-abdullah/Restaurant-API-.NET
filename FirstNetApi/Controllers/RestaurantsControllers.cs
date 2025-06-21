using Microsoft.AspNetCore.Mvc;
using Resuaurants.Domain.Repositories;
using Restaurants.Application.Restaurants;
using Resuaurants.Domain.Entities;
using Restaurants.Application.Restaurants.Dtos;
using MediatR;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
namespace FirstNetApi.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsControllers(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await mediator.Send(new GetRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurant([FromRoute] int restaurantId)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(restaurantId));
            if (restaurant == null)
            {
                return NotFound("No restaurants found with this id ");
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurant), new { restaurantId = id }, null);
        }

        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int restaurantId)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(restaurantId));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int restaurantId, UpdateRestaurantCommand command)
        {
            command.restaurantId = restaurantId;
            var isUpdated = await mediator.Send(command);
            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
