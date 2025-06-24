using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Application.Dishes.Queries.GetDish;

namespace FirstNetApi.Controllers
{
    [ApiController]
    [Route("api/restaurant/{restaurantId}/dishes")]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDishe([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantsId = restaurantId;
            int dishId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetDishByRestaurantId), new { dishId , restaurantId }, null);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDtos>>> GetAllDishesForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }
        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDtos>> GetDishByRestaurantId([FromRoute] int dishId, [FromRoute] int restaurantId)
        {
            var dish = await mediator.Send(new GetOneDishByIdQuery(restaurantId, dishId));
            return Ok(dish);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllDishesByRestaurantId([FromRoute] int restaurantId)
        {
            await mediator.Send(new DeleteAllDishesFromRestaurantQuery(restaurantId));
            return NoContent();
        }
        
    }
}
