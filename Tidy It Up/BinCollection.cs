using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidy_It_Up
{
    public class BinCollection
    {
        private List<SingleBin> bins;

        private Dictionary<string, SingleBin> binLookUp;

        public BinCollection()
        {
            
            bins = new List<SingleBin>();
            binLookUp = new Dictionary<string, SingleBin>();
        }

        public int Count
        {
            get { return bins.Count; }
        }

        public void Add(SingleBin bin)
        {
            bins.Add(bin);
            binLookUp.Add(bin.Category.ToLower(), bin);
        }

        public SingleBin Add(string category, string room)
        {
            SingleBin newBin = new SingleBin();
            newBin.Category = category;
            newBin.Room = room;
            Add(newBin);
            
            return newBin;
        }

        public string DisplayBins()
        {
            string ReturnValue = String.Empty;
            
            foreach(SingleBin bin in bins)
            {
                ReturnValue += $"{bin.Category} ({bin.Room}) {bin.ItemList.Count} items\n";
            }

            return ReturnValue;
        }

        public bool DeleteBinByCategory(string removeCategory)
        {

            if (binLookUp.ContainsKey(removeCategory.ToLower()))
            {
                SingleBin removeBin = binLookUp[removeCategory.ToLower()];
                bins.Remove(removeBin);
                binLookUp.Remove(removeCategory.ToLower());
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SearchBins(string searchItem)
        {
            int matchCounter = 0;
            string returnValue = String.Empty;

            foreach(SingleBin bin in bins)
            {
                if(bin.Category.Contains(searchItem))
                {
                    matchCounter++;
                    returnValue += $"{bin.Category} ({bin.Room})\n";
                }
            }

            return $"You have {matchCounter} matches:\n {returnValue}";
        }

        public SingleBin GetBin(string binCategory)
        {
            SingleBin myBin = binLookUp[binCategory.ToLower()];
            return myBin;

            //foreach (SingleBin bin in bins)
            //{
            //    if (bin.Category.Equals(binCategory, StringComparison.OrdinalIgnoreCase))
            //    {
            //        return bin;
            //    }
            //}

            //return null;
        }

        public string SearchForItem(string desiredItem)
        {
            foreach(SingleBin bin in bins)
            {
                foreach(string item in bin.ItemList)
                {
                    if (item.Equals(desiredItem,StringComparison.OrdinalIgnoreCase))
                    {
                        return $"\nYour item {item} is in bin {bin.Category}.";
                    }
                }
            }
            return $"\nYour item {desiredItem} is not in any bins.";
        }
        
    }
}
