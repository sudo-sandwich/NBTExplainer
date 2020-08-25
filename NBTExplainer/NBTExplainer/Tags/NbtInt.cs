using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a signed integer (4 bytes)
    public class NbtInt : NbtTag {
        public int Value { get; set; }

        public NbtInt(string name, int value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Int('" + Name + "'): " + Value + '\n');
        }
    }
}
