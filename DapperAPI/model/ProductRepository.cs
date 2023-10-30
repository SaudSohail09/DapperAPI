using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.model
{
    public class ProductRepository
    {
        private string ConnectionString;
        public ProductRepository()
        {
            ConnectionString = "Server=.\\SQLEXPRESS;Database=DAPPERDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);

            }
        }
        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (ProductID,Name,Quantity,Price) VALUES(@ProductID,@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,prod);
            }
        }
        public IEnumerable<Product> GETALL()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }
        public Product GETByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE ProductID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id}).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products WHERE ProductID=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }
        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name, Quantity=@Quantity, Price=@Price WHERE ProductID=@Productid";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
