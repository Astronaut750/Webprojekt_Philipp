using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Models.DB
{
    public class RepositoryItemsDB : IRepositoryItems
    {
        private string _connectionString = "server=localhost;database=skatemania;uid=root;pwd=root";
        private MySqlConnection _conn = null;

        public void Open()
        {
            if(this._conn == null)
            {
                this._conn = new MySqlConnection(this._connectionString);
            }
            if(this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }
        public void Close()
        {
            if((this._conn != null) && (this._conn.State == ConnectionState.Open))
            {
                this._conn.Close();
            }
        }

        public List<Item> GetAllItems()
        {
            if(this._conn.State == ConnectionState.Open)
            {
                List<Item> items = new List<Item>();

                DbCommand cmdSelectAll = this._conn.CreateCommand();
                cmdSelectAll.CommandText = "select * from skatemania.Item order by ID;";

                using(DbDataReader reader = cmdSelectAll.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        items.Add(new Item
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Manufacturer = Convert.ToString(reader["Manufacturer"]),
                            Size = Convert.ToString(reader["Size"]),
                            Image = Convert.ToString(reader["Image"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Description = Convert.ToString(reader["Description"]),
                            ItemType = (ItemType)Convert.ToInt32(reader["ItemType"])
                        });
                    }
                }

                if(items.Count < 1)
                {
                    return null;
                }

                return items;
            }
            else
            {
                throw new Exception("Datenbankverbindung ist nicht geöffnet!");
            }
        }

        public bool Insert(Item item)
        {
            if(item == null)
            {
                return false;
            }

            if(this._conn.State == ConnectionState.Open)
            {
                DbCommand cmdInsert = this._conn.CreateCommand();

                cmdInsert.CommandText = "insert into item values(null, @Manufacturer, @Size, @Image, @Price, @Description, @ItemType);";

                DbParameter paramManufacturer = cmdInsert.CreateParameter();
                paramManufacturer.ParameterName = "Manufacturer";
                paramManufacturer.DbType = DbType.String;
                paramManufacturer.Value = item.Manufacturer;

                DbParameter paramSize = cmdInsert.CreateParameter();
                paramSize.ParameterName = "Size";
                paramSize.DbType = DbType.String;
                paramSize.Value = item.Size;

                DbParameter paramImage = cmdInsert.CreateParameter();
                paramImage.ParameterName = "Image";
                paramImage.DbType = DbType.String;
                paramImage.Value = item.Image;

                DbParameter paramPrice = cmdInsert.CreateParameter();
                paramPrice.ParameterName = "Price";
                paramPrice.DbType = DbType.Decimal;
                paramPrice.Value = item.Price;

                DbParameter paramDescription = cmdInsert.CreateParameter();
                paramDescription.ParameterName = "Description";
                paramDescription.DbType = DbType.String;
                paramDescription.Value = item.Description;

                DbParameter paramItemType = cmdInsert.CreateParameter();
                paramItemType.ParameterName = "ItemType";
                paramItemType.DbType = DbType.Int32;
                paramItemType.Value = item.ItemType;

                cmdInsert.Parameters.Add(paramManufacturer);
                cmdInsert.Parameters.Add(paramSize);
                cmdInsert.Parameters.Add(paramImage);
                cmdInsert.Parameters.Add(paramPrice);
                cmdInsert.Parameters.Add(paramDescription);
                cmdInsert.Parameters.Add(paramItemType);

                return cmdInsert.ExecuteNonQuery() == 1;
            }

            return false;
        }

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }


        public Item GetItemByID(int ID)
        {
            throw new NotImplementedException();
        }


        public bool Update(int ID, Item newItemData)
        {
            throw new NotImplementedException();
        }
    }
}
