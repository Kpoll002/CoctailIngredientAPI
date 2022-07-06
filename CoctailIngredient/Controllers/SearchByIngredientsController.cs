using Microsoft.AspNetCore.Mvc;
using CoctailsIngredient.Client;
using CoctailsIngredient.Models;

namespace CoctailsIngredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchByIngredientsController : ControllerBase
    {
        [HttpGet(Name = "SearchByIngredient")]

        public SearchByIngredient SearchByIngredient(string ingredient)
        {
            CoctailClient client = new CoctailClient();
            return client.GetSearchByIngredientAsync(ingredient).Result;
        }
        
    }
}
