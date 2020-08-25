using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a singed long (8 bytes)
    public class NbtLong : NbtTag {
        public long Value { get; set; }

        public NbtLong(string name, long value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Long('" + Name + "'): " + Value + "L\n");
        }
    }
}
