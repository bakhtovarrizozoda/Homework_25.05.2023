using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CategorieController : ControllerBase
{
    private CategorieService _categorieService;

    public CategorieController()
    {
        _categorieService = new CategorieService();
    }

    [HttpGet("Category")]
    public List<CategorieDto> GetCategories()
    {
        return _categorieService.GetCategories();
    } 

    [HttpPost("Get By Id")]
    public CategorieDto GetById(int Id)
    {
        return _categorieService.GetById(Id);
    }

    [HttpPost("insert")]
    public CategorieDto AddCaterotie(CategorieDto categorie)
    {
        return _categorieService.AddCaterotie(categorie);
    }

    [HttpPost("Delete")]
    public CategorieDto Delete(CategorieDto categorie)
    {
        return _categorieService.Delete(categorie);
    }

    [HttpPost("Update")]
    public CategorieDto Update(CategorieDto categorie)
    {
        return _categorieService.Update(categorie);
    }

    [HttpGet("Join")]
    public List<CategorieDto> Join()
    {
        return _categorieService.Join();
    }

}
