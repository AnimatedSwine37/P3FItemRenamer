using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    // Converts a file with the item names (dumped from cheat engine) to a list of ItemNames
    class NameListConverter
    {
        public static List<Item> ConvertFile(string filePath, long startAddress)
        {
            string text = File.ReadAllText(filePath);
            List<Item> names = new List<Item>();
            string currentName = "";
            char lastChar = '\0';
            int startIndex = 0;
            for(int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (ch != 0)
                {
                    if (lastChar == 0)
                        startIndex = i;
                    currentName += ch;
                }
                else if(ch == 0 && lastChar != 0)
                {
                    names.Add(new Item(currentName, startIndex + startAddress, startIndex + startAddress + currentName.Length));
                    currentName = "";
                }
                lastChar = ch;
            }
            return names;
        }
    }
}
