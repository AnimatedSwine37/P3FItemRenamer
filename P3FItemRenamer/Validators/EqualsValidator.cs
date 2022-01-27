using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer.Validators
{
    public class EqualsValidator : IValidator
    {
        private object comparisonValue;

        public EqualsValidator(object comparisonValue)
        {
            this.comparisonValue = comparisonValue;
        }

        public bool Validate(object value)
        {
            return value == comparisonValue;
        }
    }
}
