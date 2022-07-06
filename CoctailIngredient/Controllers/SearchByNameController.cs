using Microsoft.AspNetCore.Mvc;
using CoctailsIngredient.Client;
using CoctailsIngredient.Models;


namespace CoctailsIngredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchByNameController : ControllerBase
    {

        [HttpGet(Name = "SearchByName")]

        public SearchByName SearchByName(string NameOfCoctail)
        {
            CoctailClient client = new CoctailClient();
            return client.GetSearchByNameAsync(NameOfCoctail).Result;
         
        }

    }
}
