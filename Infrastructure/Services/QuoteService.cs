using Dapper;
using Domain.Dtos;
using Npgsql;

public class QuoteService
{
    string connectionString = "Server =localhost;Port=5432;User id=postgres; Database=Quotes;Password=23022002;";
    public QuoteService()
    {

    }

    public List<QuoteDto> Get()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select id as Id, author as Author, quote_text as QuoteText, category_id as CategoryId from Quotes";
            var result = conn.Query<QuoteDto>(sql);
            return result.ToList();
        }
    }

    // Get By Id
    public QuoteDto GetById(int Id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"select id as Id, author as Author, quote_text as QuoteText, category_id as CategoryId from Quotes where id = {Id}";
            var result = conn.QuerySingle<QuoteDto>(sql);
            return result;
        }
    }

    // insert
    public QuoteDto Add(QuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into Quotes (id, author, quote_text, category_id) values (@Id, @Author, @QuoteText, @CategoryId)";
            var result = conn.Execute(sql, quote);
            return quote;
        }
    }

    // Delete
    public QuoteDto Delete(QuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"delete from Quotes where id = {quote.Id}";
            var result = conn.Execute(sql);
            return quote;
        }
    }

    // Update
    public QuoteDto Update(QuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"update Quotes set author = '{quote.Author}' where id = {quote.Id}";
            var result = conn.Execute(sql);
            return quote;
        }
    }

    // Join 
    public List<QuoteDto> Join()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select qu.id as Id, author Author, quote_text as QuoteText, category_id as CategoryId, cat.category_name as CategoryName from "+
            " Categories as cat join Quotes as qu on cat.id = qu.id";
            var result = conn.Query<QuoteDto>(sql).ToList();
            return result;
        }
    } 
}