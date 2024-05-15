﻿using Microsoft.EntityFrameworkCore;
using PizzaOrderAPI.contexts;
using PizzaOrderAPI.Exceptions;
using PizzaOrderAPI.Interfaces;
using PizzaOrderAPI.Models;

namespace PizzaOrderAPI.Repositories
{
    public class PizzaRepository :IRepository<int,Pizza>
    {
        private readonly PizzaOrderContext _context;
        public PizzaRepository(PizzaOrderContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int pizzaID)
        {
            var pizza = await Get(pizzaID);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync(true);
                return pizza;
            }
            throw new NoPizzaException();
        }

        public async Task<Pizza> Get(int pizzaId)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(e => e.PizzaId == pizzaId);
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;

        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return pizza;
            }
            throw new NoPizzaException();
        }
    }
}
