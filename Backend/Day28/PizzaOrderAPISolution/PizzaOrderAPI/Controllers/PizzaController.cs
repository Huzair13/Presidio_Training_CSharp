using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderAPI.Exceptions;
using PizzaOrderAPI.Interfaces;
using PizzaOrderAPI.Models;
using PizzaOrderAPI.Models.DTOs;
using System.Numerics;

namespace PizzaOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaServices;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(IPizzaServices pizzaServices,ILogger <PizzaController> logger)
        {
            _pizzaServices = pizzaServices;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("GetAllPizzas")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaServices.GetAllPizza();
                _logger.LogInformation("Successfully retrieved all pizzas");
                return Ok(pizzas.ToList());
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, "No pizzas found");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetAvailablePizza")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Pizza>>> GetAvailablePizzas()
        {
            try
            {
                var pizzas = await _pizzaServices.GetAvailablePizza();
                _logger.LogInformation("Successfully retrieved available pizzas");
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, "No available pizzas found");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [Route("GetPizzasByName")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Get([FromBody] string name)
        {
            try
            {
                var pizzas = await _pizzaServices.GetPizzaByName(name);
                _logger.LogInformation($"Successfully retrieved pizzas by name: {name}");
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, $"No pizzas found with name: {name}");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("DeletPizza")]
        [HttpDelete]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Delete([FromBody] int id)
        {
            try
            {
                var pizzas = await _pizzaServices.DeletePizzaById(id);
                _logger.LogInformation($"Successfully deleted pizza with id: {id}");
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, $"No pizza found with id: {id}");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [Route("UpdatePizzaPrice")]
        [HttpPut]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> UpdatePizzaPrice([FromBody] UpdatePizzaPriceDTO updatePizzaPriceDTO)
        {
            try
            {
                var pizza = await _pizzaServices.GetPizzaById(updatePizzaPriceDTO.Id);
                pizza.Price=updatePizzaPriceDTO.Price;
                var UpdatedPizza = await _pizzaServices.UpdatePizza(pizza);
                _logger.LogInformation($"Successfully updated pizza price for id: {updatePizzaPriceDTO.Id}");
                return Ok(UpdatedPizza);
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, $"No pizza found with id: {updatePizzaPriceDTO.Id}");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize]
        [Route("UpdatePizzaStock")]
        [HttpPut]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> UpdatePizzaStock([FromBody] UpdatePizzStockDTO updatePizzStockDTO)
        {
            try
            {
                var pizza = await _pizzaServices.GetPizzaById(updatePizzStockDTO.Id);
                pizza.PizzasInStock = updatePizzStockDTO.PizzasInStock;
                var UpdatedPizza = await _pizzaServices.UpdatePizza(pizza);
                _logger.LogInformation($"Successfully updated pizza stock for id: {updatePizzStockDTO.Id}");
                return Ok(UpdatedPizza);
            }
            catch (NoPizzasFoundException ex)
            {
                _logger.LogError(ex, $"No pizza found with id: {updatePizzStockDTO.Id}");
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }


    }
}
