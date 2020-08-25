using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a signed byte
    public class NbtByte : NbtTag {
        public sbyte Value { get; set; }

        public NbtByte(string name, sbyte value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Byte('" + Name + "'): " + Value + '\n');
        }
    }
}
