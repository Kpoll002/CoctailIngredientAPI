using Microsoft.AspNetCore.Mvc;
using CoctailsIngredient.Client;
using CoctailsIngredient.Models;



namespace CoctailsIngredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomCoctailController : ControllerBase
    {
        [HttpGet(Name = "RandomCoctai")]
        public RandomCoctail RandomCoctails()
        {
            CoctailClient client = new CoctailClient();
            return client.GetRandomCoctailsAsync().Result;
        }
       
    }
}
