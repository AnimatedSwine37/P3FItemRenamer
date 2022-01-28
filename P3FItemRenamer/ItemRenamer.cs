using P3FItemRenamer.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    class ItemRenamer
    {
        private List<Item> originalItems;

        public ItemRenamer()
        {
            originalItems = GetOriginalItems();
        }

        private List<Item> GetOriginalItems()
        {
            string basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            List<Item> originalItems = new List<Item>();
            string nameListJson = File.ReadAllText(Path.Combine(basePath, "NameLists", "NameLists.json"));
            NameList nameList = JsonSerializer.Deserialize<NameList>(nameListJson);
            foreach (NameFile file in nameList.NameFiles)
            {
                originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "NameLists", file.File), file.StartAddress));
            }
            return originalItems;
        }

        // Start the process of getting new item names
        public void Start()
        {
            Console.WriteLine("Welcome to the very good P3F item rename pnach maker made by AnimatedSwine37.");
            List<Item> items = GetRenamedItems();
            Console.WriteLine("Thanks, that's all I need. I'll generate the pnach now.");
            PnachCreator.CreatePnach(items);
        }

        private List<Item> GetRenamedItems()
        {
            Console.WriteLine("I'm going to ask you for the items you want to rename now, k :)");
            List<Item> items = new List<Item>();
            ItemValidator itemValidator = new ItemValidator(originalItems);
            while (true)
            {
                Item? newItem = GetItem(itemValidator);
                if (newItem == null)
                    break;
                items.Add(newItem);
                Console.WriteLine($"Added {newItem.Name} successfully.");
            }
            return items;
        }

        private Item? GetItem(ItemValidator itemValidator)
        {
            string ogName = UserInterface.GetInput("Enter the original name of the item (or ! to end)", itemValidator);
            if(ogName == "!")
                return null;
            int id = originalItems.FindIndex(item => item.Name.ToLower() == ogName.ToLower()) + 1;
            string name = UserInterface.GetInput($"Enter the new name for {originalItems[id - 1].Name}");
            return new Item(name, originalItems[id - 1].StartAddress, originalItems[id - 1].EndAddress);
        }
    }
}
