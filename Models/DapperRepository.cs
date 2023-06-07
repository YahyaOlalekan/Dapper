using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CodingPie.Models;
using CodingPie3.DbContext;
using Dapper;

namespace CodingPie3.Models
{
    public class DapperRepository : IPieRepository
    {
        private readonly DapperContext _dapperContext;
        public DapperRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public Pie AddPie(Pie pie)
        {
            var query = "INSERT INTO pie (Id, Name, Description, Price, IsAvailable, PiePicturePath) VALUES(@id, @name, @description, @price, @isAvailable, @piePicturePath)";

            var parameters = new DynamicParameters();
            parameters.Add("id", pie.Id, DbType.Int32);
            parameters.Add("name", pie.Name, DbType.String);
            parameters.Add("description", pie.Description, DbType.String);
            parameters.Add("price", pie.Price, DbType.Decimal);
            parameters.Add("isAvailable", pie.IsAvailable, DbType.Boolean);
            parameters.Add("piePicturePath", pie.PiePicturePath, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
            return pie;
        }

        public void DeletePie(Pie pie)
        {
            var query = "DELETE FROM Pie WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new { Id = pie.Id });
            }

        }

        public void DeletePie(int id)
        {
            var query = "DELETE FROM Pie WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var pie = connection.QuerySingleOrDefault<Pie>(query, new { Id = id });

            }
        }

        public IEnumerable<Pie> GetAll()
        {
            var query = "SELECT * FROM Pie";
            using (var connection = _dapperContext.CreateConnection())
            {
                var pies = connection.Query<Pie>(query);
                return pies;
            }


        }

        public Pie GetPie(int id)
        {
            var query = "SELECT * FROM Pie WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var pie = connection.QuerySingleOrDefault<Pie>(query, new { Id = id });
                return pie;
            }
        }

        public Pie UpdatePie(Pie pie)
        {
            var query = "UPDATE pie SET Name = @name, Description = @description, Price = @price WHERE Id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", pie.Id, DbType.Int32);
            parameters.Add("name", pie.Name, DbType.String);
            parameters.Add("description", pie.Description, DbType.String);
            parameters.Add("price", pie.Price, DbType.Decimal);
            //parameters.Add("isAvailable", pie.IsAvailable, DbType.Boolean);
            //parameters.Add("piePicturePath", pie.PiePicturePath, DbType.String);


            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
            return pie;
        }

        public Pie UpdatePie(int id, Pie pie)
        {
            throw new NotImplementedException();

        }
    }
}