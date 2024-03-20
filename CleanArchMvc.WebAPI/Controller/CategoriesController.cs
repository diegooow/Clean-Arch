using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categories = await _categoryService.GetCategories();
        if(categories == null){
            return NotFound("Categories not found");

        }

        return Ok(categories);
    }

    [HttpGet("{id:int}", Name ="GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetById(int id)
    {
        var category = await _categoryService.GetById(id);
        if(category == null)
            return NotFound("Category not found");

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Create([FromBody] CategoryDTO categoryDTO)
    {
        if(categoryDTO ==null){
            return BadRequest("Invalid Data");
        }else{

        await _categoryService.Add(categoryDTO);      
        return new CreatedAtRouteResult("GetCategory",new {id = categoryDTO.Id},categoryDTO);
        }

    }
}
