using System.Threading.Tasks;
using CookApp.API.Data;
using CookApp.API.Dtos;
using CookApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookApp.API.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly DataContext _context;
        public RecipesController(DataContext context)
        {
            _context = context;
        }
    


    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
            var recipes = await _context.recipes.ToListAsync();

            return Ok(recipes);
    }


    [HttpPost("addNewRecipe")]

    public async Task<IActionResult> AddRecipe([FromBody]RecipeForAddToLocalDatabaseDto recipeForAddToLocalDatabaseDto)
    {

         var recipeToCreate = new Recipe
            {
                name = recipeForAddToLocalDatabaseDto.name,
                time = recipeForAddToLocalDatabaseDto.time,
                lvl = recipeForAddToLocalDatabaseDto.lvl,
                quality = recipeForAddToLocalDatabaseDto.quality,
                description = recipeForAddToLocalDatabaseDto.description
            };

        if (!ModelState.IsValid)
                return BadRequest(ModelState);

        


            await _context.recipes.AddAsync(recipeToCreate);
            await _context.SaveChangesAsync();
            return StatusCode(201);

    }



    [HttpPost("deleteRecipeById")]
    public async Task<IActionResult> DeleteRecipe([FromBody]int id)
    {

        Recipe recipeToDelete = await _context.recipes.FirstOrDefaultAsync(x => x.Id.Equals(id));



        if (!ModelState.IsValid)
           return BadRequest(ModelState);



            _context.recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
            return StatusCode(201);   
    }




    [HttpPost("rateRecipeById")]
    public async Task<IActionResult> RateRecipe([FromBody]RecipeForRateDto recipeForRateDto)
    {
        Recipe recipeToRate = await _context.recipes.FirstOrDefaultAsync(x => x.Id.Equals(recipeForRateDto.Id));

        var recipeToRating = new Recipe {
               rate = recipeForRateDto.rate
        };


        if (!ModelState.IsValid)
           return BadRequest(ModelState);
    

        recipeToRate.rate = recipeToRating.rate;

        _context.Entry(recipeToRate).State = EntityState.Modified;


            await _context.SaveChangesAsync();
            return StatusCode(201);   
    }




}
}
