using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copiloting.debugging;

public class Example
{
    public void Run(string[] args)
    {
        int value = Int32.Parse(args[0]);
        List<String> names = null;
        if (value > 0)
            names = new List<String>();

        names.Add("Major Major Major");
    }
}