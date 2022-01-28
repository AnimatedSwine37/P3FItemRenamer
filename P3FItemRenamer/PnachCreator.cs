using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    class PnachCreator
    {
        public static void CreatePnach(List<Item> items)
        {
            string pnachText = "gametitle=Persona 3 FES [SLUS_216.21] [94A82AAA]\n" +
                               "comment=Auto Generated Rename Pnach\n" +
                               "author= AnimatedSwine37\n" +
                               "version=1\n\n";
            string pnachPath = "94A82AAA_RenameStuff.pnach";
            if (AppendToExistingPnach())
                pnachText = File.ReadAllText(pnachPath) + "\n";
            foreach (Item item in items)
            {
                pnachText += $"// {item.Name}\n";
                // Write the new name in 4 byte section patches
                for (int i = 0; i < Math.Ceiling((double)(item.EndAddress - item.StartAddress) / 4); i++)
                {
                    string subString;
                    if (i * 4 >= item.Name.Length)
                        subString = "";
                    else if ((i + 1) * 4 >= item.Name.Length)
                        subString = item.Name.Substring(i * 4);
                    else
                        subString = item.Name.Substring(i * 4, 4);
                    subString = subString.PadRight(4, '\0');
                    var byteArray = Encoding.UTF8.GetBytes(subString).Reverse().ToArray();
                    string hexString = Convert.ToHexString(byteArray);
                    pnachText += $"patch=1,EE,{item.StartAddress + i * 4:X},word,{hexString}\n";
                }
                pnachText += "\n";
            }
            File.WriteAllText(pnachPath, pnachText);
            Console.WriteLine($"Successfully wrote rename pnach to {pnachPath}");
        }

        private static bool AppendToExistingPnach()
        {
            if (!File.Exists("94A82AAA_RenameStuff.pnach"))
                return false;
            return UserInterface.GetBool("I've detected an existing 94A82AAA_RenameStuff.pnach." +
                "\nWould you like to apppend your changes to this? If not it will be overwritten (y/n)");
        }
    }
}
