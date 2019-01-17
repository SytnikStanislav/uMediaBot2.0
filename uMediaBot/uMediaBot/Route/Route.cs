using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot
{
    class Route
    {
        public string Name { get; set; }

        public string RawRoute { get; set; }

        public string CompiledRoute { get; set; }

        public Action Handler { get; set; }
    }
}
