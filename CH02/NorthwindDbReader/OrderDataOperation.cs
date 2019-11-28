using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDbReader
{
    public class OrderDataOperation : IDataOperation<Order>
    {
        private string _connectionString =
           @"Data Source=.;Initial Catalog=Northwind;"
       + "Integrated Security=true;";
        public void Create(Order Item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"INSERT INTO Orders
                    (OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,
                    ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
                    VALUES(@OrderID,@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,
                    @ShipVia,@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry)");
            cmd.Connection = connection;
            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.OrderID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@CustomerID", DBNull.Value)
                : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@EmployeeID", DBNull.Value)
                : new SqlParameter("@EmployeeID", Item.EmployeeID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@OrderDate", DBNull.Value)
                : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@RequiredDate", DBNull.Value)
                : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShippedDate", DBNull.Value)
                : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipVia", DBNull.Value)
                : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@Freight", DBNull.Value)
                : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipName", DBNull.Value)
                : new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipAddress", DBNull.Value)
                : new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipCity", DBNull.Value)
                : new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipRegion", DBNull.Value)
                : new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipPostalCode", DBNull.Value)
                : new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipCountry", DBNull.Value)
                : new SqlParameter("@ShipCountry", Item.ShipCountry));
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Order Item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"DELETE FROM Orders WHERE OrderID = @OrderID");
            cmd.Connection = connection;
            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.OrderID));
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Order> Get()
        {
            IDbConnection connection = new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand("SELECT * FROM Orders");
            cmd.Connection = connection;
            connection.Open();
            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);
            while (reader.Read())
            {
                Order order = new Order()
                {
                    OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID"))),
                    CustomerID = reader.GetValue(reader.GetOrdinal("OrderID")).ToString(),
                    EmployeeID=(reader.IsDBNull(reader.GetOrdinal("EmployeeID")))
                        ? new Nullable<int>()
                        :Convert.ToInt32(reader.GetValue(reader.GetOrdinal("EmployeeID"))),
                    OrderDate = (reader.IsDBNull(reader.GetOrdinal("OrderDate")))
                        ? new Nullable<DateTime>()
                        : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDate"))),
                    RequiredDate = (reader.IsDBNull(reader.GetOrdinal("RequiredDate")))
                        ? new Nullable<DateTime>()
                        : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("RequiredDate"))),
                    ShippedDate = (reader.IsDBNull(reader.GetOrdinal("ShippedDate")))
                        ? new Nullable<DateTime>()
                        : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShippedDate"))),
                    ShipVia = (reader.IsDBNull(reader.GetOrdinal("ShipVia")))
                        ? new Nullable<int>()
                        : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ShipVia"))),
                    Freight = (reader.IsDBNull(reader.GetOrdinal("Freight")))
                        ? new Nullable<double>()
                        : Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Freight"))),
                    ShipName = reader.GetValue(reader.GetOrdinal("ShipName")).ToString(),
                    ShipAddress = reader.GetValue(reader.GetOrdinal("ShipAddress")).ToString(),
                    ShipCity = reader.GetValue(reader.GetOrdinal("ShipCity")).ToString(),
                    ShipRegion = reader.GetValue(reader.GetOrdinal("ShipRegion")).ToString(),
                    ShipPostalCode = reader.GetValue(reader.GetOrdinal("ShipPostalCode")).ToString(),
                    ShipCountry = reader.GetValue(reader.GetOrdinal("ShipCountry")).ToString(),
                };
                yield return order;
            }
            connection.Close();
        }

        public void Update(Order Item)
        {
            IDbConnection connection = new SqlConnection(this._connectionString);
            IDbCommand cmd = new SqlCommand(
                @"UPDATE Orders SET
                    CustomerID=@CustomerID,EmployeeID=@EmployeeID,OrderDate=@OrderDate,RequiredDate=@RequiredDate,
                    ShippedDate=@ShippedDate,ShipVia=@ShipVia,Freight=@Freight,ShipName=@ShipName,ShipAddress=@ShipAddress,
                    ShipCity=@ShipCity,ShipRegion=@ShipRegion,ShipPostalCode=@ShipPostalCode,ShipCountry=@ShipCountry
                    WHERE OrderID=@OrderID");
            cmd.Connection = connection;
            cmd.Parameters.Add(
                new SqlParameter("@OrderID", Item.OrderID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@CustomerID", DBNull.Value)
                : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@EmployeeID", DBNull.Value)
                : new SqlParameter("@EmployeeID", Item.EmployeeID));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@OrderDate", DBNull.Value)
                : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@RequiredDate", DBNull.Value)
                : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShippedDate", DBNull.Value)
                : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipVia", DBNull.Value)
                : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@Freight", DBNull.Value)
                : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipName", DBNull.Value)
                : new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipAddress", DBNull.Value)
                : new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipCity", DBNull.Value)
                : new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipRegion", DBNull.Value)
                : new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipPostalCode", DBNull.Value)
                : new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(
                (Item.CustomerID == null)
                ? new SqlParameter("@ShipCountry", DBNull.Value)
                : new SqlParameter("@ShipCountry", Item.ShipCountry));
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
