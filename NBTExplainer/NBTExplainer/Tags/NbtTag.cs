using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // base class for all tags
    public abstract class NbtTag {
        public string Name { get; set; }

        public abstract void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount);
    }
}
