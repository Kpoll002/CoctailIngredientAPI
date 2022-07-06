using Microsoft.AspNetCore.Mvc;
using CoctailsIngredient.Client;
using CoctailsIngredient.Models;

namespace CoctailsIngredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListOfPopularCoctailsController : ControllerBase
    {
        [HttpGet(Name = "ListOfPopularCoctails")]
        public ListOfPopularCoctails ListOfPopularCoctails()
        {
            CoctailClient client = new CoctailClient();
            return client.GetListOfPopularCoctailsAsync().Result;
        }


    }
}
