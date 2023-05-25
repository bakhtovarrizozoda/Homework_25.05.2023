using Dapper;
using Domain.Dtos;
using Npgsql;

public class CategorieService
{
    string connectionString = "Server =localhost;Port=5432;User id=postgres; Database=Quotes;Password=23022002;";
    public CategorieService()
    {

    }

    public List<CategorieDto> GetCategories()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select id as Id, category_name as CategoryName from Categories";
            var result = conn.Query<CategorieDto>(sql);
            return result.ToList();
        }
    }

    // Get By Id
    public CategorieDto GetById(int Id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"select id as Id, category_name as CategoryName from Categories where id = {Id}";
            var result = conn.QuerySingle<CategorieDto>(sql);
            return result;
        }
    }

    // insert
    public CategorieDto AddCaterotie(CategorieDto categorie)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into Categories (id, category_name ) values (@Id, @CategoryName)";
            var result = conn.Execute(sql, categorie);
            return categorie;
        }
    }

    // Delete
    public CategorieDto Delete(CategorieDto categorie)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"delete from Categories where id = {categorie.Id}";
            var result = conn.Execute(sql);
            return categorie;
        }
    }

    // Update
    public CategorieDto Update(CategorieDto categorie)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"update Categories set category_name = '{categorie.CategoryName}' where id = {categorie.Id}";
            var result = conn.Execute(sql);
            return categorie;
        }
    }

    // Join 
    public List<CategorieDto> Join()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select qu.id as Id, author as Author, quote_text as QuoteText, category_id as CategoryId, cat.category_name as CategoryName from "+
            " Categories as cat join Quotes as qu on cat.id = qu.id";
            var result = conn.Query<CategorieDto>(sql).ToList();
            return result;
        }
    } 
}