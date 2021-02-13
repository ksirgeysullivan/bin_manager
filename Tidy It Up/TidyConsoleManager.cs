using System;

namespace Tidy_It_Up
{
    class TidyConsoleManager
    {
        private BinCollection binCollection;
       // private SingleBin singleBin;

        public TidyConsoleManager()
        {
            binCollection = new BinCollection();
          //  singleBin = new SingleBin();
        }


        public void ShowMenu()
        {
            char menuOption;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("MENU");
                Console.WriteLine("Type in the number of the action you wish to perform.");
                Console.WriteLine("1. View Bins");
                Console.WriteLine("2. Add a Bin");
                Console.WriteLine("3. Delete a Bin");
                Console.WriteLine("4. Search for a Bin");
                Console.WriteLine("5. Add an Item to a Bin");
                Console.WriteLine("6. Delete an Item from a Bin");
                Console.WriteLine("7. Search for an Item in a Bin");
                Console.WriteLine("8. Exit the App");
                Console.WriteLine("\n");

                menuOption = Console.ReadKey().KeyChar;

                switch (menuOption)
                {
                    case '1':
                        ViewBinsUI();
                        break;

                    case '2':
                        AddBinUI();
                        break;

                    case '3':
                        DeleteBinUI();
                        break;

                    case '4':
                        SearchForBinUI();
                        break;

                    case '5':
                        AddItemUI();
                        break;

                    case '6':
                        DeleteItemUI();
                        break;

                    case '7':
                        SearchForItemUI();
                        break;
                }
            } while (menuOption != '8');

        }

        private void ViewBinsUI()
        {
            Console.WriteLine($"\n\nYou have {binCollection.Count} bins in your collection.");
            Console.WriteLine(binCollection.DisplayBins());
            Console.Write("Would you like to view the contents of a bin? ");
            string viewItemsYesOrNo = Console.ReadLine();

            if (viewItemsYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Which bin would you like to look in? ");
                string bin = Console.ReadLine();

                SingleBin binToLookIn = binCollection.GetBin(bin);

                Console.WriteLine($"You have {binToLookIn.ItemList.Count} items\n");
                
                foreach(string item in binToLookIn.ItemList)
                {
                    Console.WriteLine(item);
                }

            }
        }

        private void AddBinUI()
        {
            Console.WriteLine("ENTER BIN DETAILS");
            Console.Write("     Bin Category: ");
            string binCategory = Console.ReadLine();
            string binCategoryLower = binCategory.ToLower();
            Console.Write("     Bin Room: ");
            string binRoom = Console.ReadLine();
            string binRoomLower = binRoom.ToLower();

            binCollection.Add(binCategoryLower, binRoomLower);
        }

        private void DeleteBinUI()
        {
            Console.WriteLine("DELETE BINS FROM BELOW");
            Console.WriteLine(binCollection.DisplayBins());
            Console.Write("Type in the category of the bin you wish to remove: ");
            string categoryRemove = Console.ReadLine();
            string categoryRemoveLower = categoryRemove.ToLower();
            
            if(binCollection.DeleteBinByCategory(categoryRemoveLower))
            {
                Console.WriteLine("Bin Category Successfully Removed");
            } else
            {
                Console.Write("Try one more time: ");
                categoryRemove = Console.ReadLine();
                categoryRemoveLower = categoryRemove.ToLower();
            }
        }

        private void SearchForBinUI()
        {
            Console.Write("Type your search item (category name) here: ");
            string searchItem = Console.ReadLine();
            string searchItemLower = searchItem.ToLower();

            if(String.IsNullOrWhiteSpace(searchItemLower))
            {
                Console.Write("Please type in a category name: ");
                searchItem = Console.ReadLine();
                searchItemLower = searchItem.ToLower();

            } else
            {
                Console.WriteLine(binCollection.SearchBins(searchItemLower));
            }

        }

        private void AddItemUI()
        {
            Console.WriteLine(binCollection.DisplayBins());
            Console.Write("\nWhich bin would you like to add an item to? ");
            string binAddItemTo = Console.ReadLine();

            SingleBin bin = binCollection.GetBin(binAddItemTo);

            if (bin != null)
            {
                Console.Write($"\nWhat item would you like to add to {binAddItemTo}? ");
                string itemAddToBin = Console.ReadLine();


                bin.AddToItemList(itemAddToBin);

                Console.WriteLine($"\nYour item {itemAddToBin} has been successfully added.");
            }
            else
            {
                Console.WriteLine("\nNo matching bin found");
            }

            while (true)
            {
                Console.Write("\nWould you like to add another item? ");
                string addAnotherItemYesOrNo = Console.ReadLine();

                if (addAnotherItemYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("\nWhat is the next item you would like to add? ");
                    string nextItemToAdd = Console.ReadLine();

                    bin.AddToItemList(nextItemToAdd);
                    Console.WriteLine($"\nYour item {nextItemToAdd} has been successfully added.");
                } else
                {
                    break;
                }
            } 
        }

        private void DeleteItemUI()
        {
            Console.WriteLine($"You have {binCollection.Count} bins in your collection.");
            Console.WriteLine(binCollection.DisplayBins());
            Console.Write("Which bin would you like to delete an item from? ");
            string binDeleteItemFrom = Console.ReadLine();

            SingleBin bin = binCollection.GetBin(binDeleteItemFrom);

            if (bin == null)
            {
                Console.WriteLine("\nNo matching bin found");
                return;
            }
            
            Console.WriteLine($"\nYou have {bin.ItemList.Count} items in {bin}:\n");

            foreach (string item in bin.ItemList)
            {
                Console.WriteLine(item);
            }

            Console.Write("Which item would you like to delete? ");
            string itemToDelete = Console.ReadLine();

            bin.DeleteItemInItemList(itemToDelete);

            while (true)
            {
                Console.Write("\nWould you like to delete another item? ");
                string deleteAnotherItemYesOrNo = Console.ReadLine();

                if (deleteAnotherItemYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("\nWhat item would you like to delete? ");
                    itemToDelete = Console.ReadLine();

                    bin.DeleteItemInItemList(itemToDelete);

                }
                else
                {
                    break;
                }
            }
        }

        private void SearchForItemUI()
        {
            Console.Write("What item are you searching for? ");
            string desiredItem = Console.ReadLine();

            Console.WriteLine(binCollection.SearchForItem(desiredItem));
            

        }

    }
}
