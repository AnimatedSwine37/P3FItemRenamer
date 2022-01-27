using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer.Validators
{
    public class ItemValidator: IValidator
    {
        private List<Item> originalItems;

        public ItemValidator(List<Item> originalItems)
        {
            this.originalItems = originalItems;
        }

        public bool Validate(object value)
        {
            string? name = value as string;
            if (name == null)
                return false;
            if (name == "!")
                return true;
            bool isValid = originalItems.Any(item => item.Name.ToLower() == name.ToLower());
            if(!isValid)
                Console.WriteLine($"Unknown item {value}");
            return isValid;
        }
    }
}
