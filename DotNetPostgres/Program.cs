using System.Data;
using Dapper;
using Npgsql;

class Model
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

class Db
{
    private string _conString;

    public Db(string conStr)
    {
        _conString = conStr;
    }

    private static NpgsqlConnection OpenConnection(string cons)
    {
        var con = new NpgsqlConnection(cons);
        con.Open();
        return con;
    }

    public List<Model.UserModel> GetAllUsers()
    {
        using var con = OpenConnection(_conString);
        var sql = "SELECT Name, Password FROM MyUser";
        return con.Query<Model.UserModel>(sql).ToList();
    }

    public List<Model.UserModel> QueryUser(int id)
    {
        using var con = OpenConnection(_conString);
        return con.Query<Model.UserModel>(
            "SELECT Name, Password " +
            "FROM MyUser " +
            "WHERE id = @sql_id"
            , new { sql_id = id }).ToList();
    }

    public List<Model.UserModel> DoQueueUserWithoutDapper(int id)
    {
        using var con = OpenConnection(_conString);
        using var cmd = new NpgsqlCommand(
            "SELECT * FROM MyUser WHERE id = @sql_id",
            con);
        cmd.Parameters.AddWithValue("sql_id", id);
        using var reader = cmd.ExecuteReader();
        List<Model.UserModel> l = new();
        while (reader.Read())
        {
            var u = new Model.UserModel()
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Password = reader.GetString(2)
            };
            l.Add(u);
        }

        return l;
    }

    public void CreateTable()
    {
        using var con = OpenConnection(_conString);
        using var cmd = new NpgsqlCommand(
            "CREATE TABLE IF NOT EXISTS MyUser (" +
            "ID SERIAL," +
            "Name TEXT," +
            "Password TEXT)", con);
        cmd.ExecuteNonQuery();
    }

    public void AddUser(string username, string password)
    {
        using var con = OpenConnection(_conString);
        con.Execute("INSERT INTO MyUser (Name, Password) VALUES (@un, @psw)",
            new
            {
                un = username,
                psw = password
            });
    }
}


class Program
{
    public static void Main()
    {
        var psql = "Host=localhost;Username=postgres;Password=fsad2022;Database=testx";
        var db = new Db(psql);
        db.CreateTable();
        db.AddUser("Kevin", "123456");
        Console.WriteLine("Queried");
        
        //Print(db.DoQueueUserWithoutDapper(0));
        Print(db.QueryUser(1));
        Print(db.DoQueueUserWithoutDapper(1));
    }

    public static void Print( List<Model.UserModel> l)
    {
        foreach (var u in l)
        {
            Console.WriteLine($"{{UN = {u.Name}, PSW = {u.Password}}}");
        }
        
    }
}