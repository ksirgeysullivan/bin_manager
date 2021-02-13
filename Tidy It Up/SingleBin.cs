using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidy_It_Up
{
    public class SingleBin
    {
        public string Room { get; set; }
        public string Category { get; set; }
        public List<string> ItemList { get; private set; }

        public SingleBin()
        {
            ItemList = new List<string>();
        }

        public void AddToItemList(string item)
        {
            ItemList.Add(item);
        }

        public bool DeleteFromItemList(string item)
        {
            return ItemList.Remove(item);
        }

        public bool DeleteItemInItemList(string removeItem)
        {
            string deleteItem = null;

            foreach (string item in ItemList)
            {
                if (item.Equals(removeItem, StringComparison.OrdinalIgnoreCase))
                {
                    deleteItem = item;
                    break;
                }
            }

            if (deleteItem != null)
            {
                ItemList.Remove(deleteItem);
                Console.WriteLine($"\nYour item {deleteItem} has been successfully deleted");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
