using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a single precision float (4 bytes)
    public class NbtFloat : NbtTag {
        public float Value { get; set; }

        public NbtFloat(string name, float value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Float('" + Name + "'): " + Value + '\n');
        }
    }
}
