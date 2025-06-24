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
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDtos>>> GetAll()
        {
            var restaurants = await mediator.Send(new GetRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{restaurantId}")]
        public async Task<ActionResult<RestaurantDtos?>> GetRestaurant([FromRoute] int restaurantId)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(restaurantId));
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
            await mediator.Send(new DeleteRestaurantCommand(restaurantId));
            return NoContent();
        }

        [HttpPatch("{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int restaurantId, UpdateRestaurantCommand command)
        {
            command.restaurantId = restaurantId;
            await mediator.Send(command);
            return NoContent();
        }
    }
}
