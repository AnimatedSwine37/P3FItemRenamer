// See https://aka.ms/new-console-template for more information
using P3FItemRenamer;

//Utils.CheckForUpdates();
ItemRenamer itemRenamer = new ItemRenamer();
itemRenamer.Start();
Console.WriteLine("Thanks for using my pnach creator. To use this pnach simply copy it to your cheats folder in PCSX2 and play!");
Console.WriteLine("All of the renamed items have their new names as comments above their patch so if you'd like to disable any one you can comment out the patch lines below it.");
Console.WriteLine("Press any key to exit");
Console.ReadKey();