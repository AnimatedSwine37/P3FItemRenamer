// See https://aka.ms/new-console-template for more information
using P3FItemRenamer;
using System.Reflection;

string itemFile = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"P3F Items.CEM");
List<Item> originalItemNames = NameListConverter.ConvertFile(itemFile, 0x205DD2F0);
ItemRenamer itemRenamer = new ItemRenamer(originalItemNames);
itemRenamer.Start();