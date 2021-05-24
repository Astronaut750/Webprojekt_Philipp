using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Models.DB
{
    interface IRepositoryItems
    {
        void Open();

        void Close();

        Item GetItemByID(int ID);

        List<Item> GetAllItems();

        bool Insert(Item item);

        bool Delete(int ID);

        bool Update(int ID, Item newItemData);
    }
}
