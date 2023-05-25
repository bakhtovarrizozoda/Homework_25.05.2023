using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuoteController : ControllerBase
{
    private QuoteService _quoteService;

    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpGet("Quote")]
    public List<QuoteDto> Get()
    {
        return _quoteService.Get();
    } 

    [HttpPost("Get By Id Quote")]
    public QuoteDto GetById(int Id)
    {
        return _quoteService.GetById(Id);
    }

    [HttpPost("insert Quote")]
    public QuoteDto Add(QuoteDto quote)
    {
        return _quoteService.Add(quote);
    }

    [HttpPost("Delete Quote")]
    public QuoteDto Delete(QuoteDto quote)
    {
        return _quoteService.Delete(quote);
    }

    [HttpPost("Update Quote")]
    public QuoteDto Update(QuoteDto quote)
    {
        return _quoteService.Update(quote);
    }

    [HttpGet("Join Quote")]
    public List<QuoteDto> Join()
    {
        return _quoteService.Join();
    }

}
