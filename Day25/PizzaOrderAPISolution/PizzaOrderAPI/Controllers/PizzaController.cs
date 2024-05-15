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
        public PizzaController(IPizzaServices pizzaServices)
        {
            _pizzaServices = pizzaServices;
        }

        [HttpGet("GetAllPizzas")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaServices.GetAllPizza();
                return Ok(pizzas.ToList());
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpGet("GetAvailablePizza")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Pizza>>> GetAvailablePizzas()
        {
            try
            {
                var pizzas = await _pizzaServices.GetAvailablePizza();
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("GetPizzasByName")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Get([FromBody] string name)
        {
            try
            {
                var pizzas = await _pizzaServices.GetPizzaByName(name);
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("DeletPizza")]
        [HttpDelete]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Delete([FromBody] int id)
        {
            try
            {
                var pizzas = await _pizzaServices.DeletePizzaById(id);
                return Ok(pizzas);
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

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
                return Ok(UpdatedPizza);
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

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
                return Ok(UpdatedPizza);
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }


    }
}
