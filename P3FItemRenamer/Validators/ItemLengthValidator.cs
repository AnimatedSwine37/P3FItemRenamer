using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer.Validators
{
    public class ItemLengthValidator : IValidator
    {
        private Item originalItem;

        public ItemLengthValidator(Item originalItem)
        {
            this.originalItem = originalItem;
        }

        public bool Validate(object value)
        {
            string newName = (string)value;
            long maxLength = originalItem.EndAddress - originalItem.StartAddress + 1;
            if (newName.Length > maxLength)
            {
                Console.WriteLine($"{newName} is too long to fit. The maximum size is {maxLength} characters.");
                return false;
            }
            return true;
        }
    }
}
