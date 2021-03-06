using Pizza_StoreV9.Models;
using Pizza_StoreV9.Interfaces;
using Pizza_StoreV9.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_StoreV9.Services
{
    public class PizzaJson : IPizzaRepository
    {
      const string JsonFileName = @"Data\JsonPizzas.json";

        public void AddPizza(Pizza pizza)
        {
            Dictionary<int, Pizza> pizzas = JsonFileReader.ReadJson(@"Data\JsonPizzas.json");
            pizzas.Add(pizza.Id, pizza);
            JsonFileWritter.WriteToJson(pizzas,JsonFileName);
        }

        public Dictionary<int, Pizza> AllPizzas()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }


        public Dictionary<int, Pizza> FilterPizza(string criteria)
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();
                Dictionary<int, Pizza> filteredPizzas = new Dictionary<int, Pizza>();
            if (criteria != null)
            {
                foreach (var p in pizzas.Values)
                {
                    if (p.Name.StartsWith(criteria))
                    {
                        filteredPizzas.Add(p.Id, p);
                    }
                }
            }
                return filteredPizzas;
            
        }
        public Pizza GetPizza(int id)
        {
            // not implemented yet;
            //return new Pizza();
            Dictionary<int, Pizza> pizzas = JsonFileReader.ReadJson(JsonFileName);
            return pizzas[id];
        }
        public Pizza GetPizza2(int id)
        {
            Dictionary<int, Pizza> pizzas = JsonFileReader.ReadJson(JsonFileName);
            foreach(var p in pizzas)
            {
                if (p.Key == id)
                    return p.Value;
            }
            return new Pizza();
        }
        public void UpdatePizza(Pizza pizza)
        {
            // not implemented yet
            Dictionary<int, Pizza> pizzas = JsonFileReader.ReadJson(JsonFileName);
            if(pizzas != null)
            {
                pizzas[pizza.Id] = pizza;
            }
            JsonFileWritter.WriteToJson(pizzas, JsonFileName);
        }

        public void DeletePizza(Pizza pizza)
        {
            // not implemented;
            Dictionary<int, Pizza> pizzas = JsonFileReader.ReadJson(@"Data\JsonPizzas.json");
            pizzas.Remove(pizza.Id);
            JsonFileWritter.WriteToJson(pizzas, JsonFileName);
        }

    }
}
