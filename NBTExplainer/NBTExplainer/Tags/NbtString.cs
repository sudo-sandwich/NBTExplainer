using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents a UTF8 encoded string
    public class NbtString : NbtTag {
        public string Value { get; set; }

        public NbtString(string name, string value) {
            Name = name;
            Value = value;
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_String('" + Name + "'): '" + Value + "'\n");
        }
    }
}
