using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    public class DummyScriptPreprocessor : IScriptPreprocessor
    {
        public string Process(string contents)
        {
            return contents;
        }
    }
}
