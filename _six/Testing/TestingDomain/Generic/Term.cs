using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDomain.Generic;

public class Term : Entity
{
    public Term(string id) : base(id)
    {
    }

    public string Name { get; set; } = string.Empty;
}