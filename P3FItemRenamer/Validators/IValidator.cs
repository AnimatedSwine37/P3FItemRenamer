using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    public interface IValidator
    {
        bool Validate(object value);
    }
}
