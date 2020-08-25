using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a signed double precision float (8 bytes)
    public class NbtDouble : NbtTag {
        public double Value { get; set; }

        public NbtDouble(string name, double value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Double('" + Name + "'): " + Value + '\n');
        }
    }
}
