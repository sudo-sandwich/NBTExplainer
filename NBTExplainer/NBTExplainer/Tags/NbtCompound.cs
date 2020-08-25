using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents an array of named tags
    public class NbtCompound : NbtTag {
        public IList<NbtTag> Value { get; }

        public NbtCompound(string name) {
            Name = name;
            Value = new List<NbtTag>();
        }

        public NbtCompound(string name, IEnumerable<NbtTag> value) {
            Name = name;
            Value = new List<NbtTag>(value);
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Compound('" + Name + "'): " + Value.Count + " entries\n");
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("{\n");

            foreach (NbtTag element in Value) {
                element.PrettyPrint(sb, indentString, currentIndentAmount + 1);
            }

            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("}\n");
        }
    }
}
