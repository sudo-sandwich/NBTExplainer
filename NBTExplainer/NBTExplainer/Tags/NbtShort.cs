using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a signed short (2 bytes)
    public class NbtShort : NbtTag {
        public short Value { get; set; }

        public NbtShort(string name, short value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Short('" + Name + "'): " + Value + '\n');
        }
    }
}
