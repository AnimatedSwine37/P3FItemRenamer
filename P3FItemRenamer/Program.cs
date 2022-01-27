// See https://aka.ms/new-console-template for more information
using P3FItemRenamer;
using System.Reflection;

string basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
List<Item> originalItems = new List<Item>();
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Weapons.CEM"), 0x205DD2F0));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Key Items.CEM"), 0x205E2A80));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Short Items.CEM"), 0x207CB690));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Items.CEM"), 0x205E1A20));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Armour.CEM"), 0x205DF1D8));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Boots.CEM"), 0x205E0428));
originalItems.AddRange(NameListConverter.ConvertFile(Path.Combine(basePath, "Accessories.CEM"), 0x205E1068));
ItemRenamer itemRenamer = new ItemRenamer(originalItems);
itemRenamer.Start();
Console.WriteLine("Thanks for using my pnach creator. To use this pnach simply copy it to your cheats folder in PCSX2 and play!");
Console.WriteLine("All of the renamed items have their new names as comments above their patch so if you'd like to disable any one you can comment out the patch lines below it.");
Console.WriteLine("Press any key to exit");
Console.ReadKey();