using Microsoft.AspNetCore.Mvc;
using CoctailsIngredient.Client;
using CoctailsIngredient.Models;

namespace CoctailsIngredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListOfIngredientsController : ControllerBase
    {
        [HttpGet(Name = "ListOfIngredients")]
        public ListOfIngredients GetListOfIngredients()
        {
            CoctailClient client = new CoctailClient();
            return client.GetListOfIngredientsAsync().Result;
        }

    }
}
