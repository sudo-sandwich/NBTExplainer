using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represets an array of signed integers
    public class NbtIntArray : NbtTag {
        public IList<int> Value { get; }

        public NbtIntArray(string name) {
            Name = name;
            Value = new List<int>();
        }

        public NbtIntArray(string name, IEnumerable<int> value) {
            Name = name;
            Value = new List<int>(value);
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Int_Array('" + Name + "'): " + Value.Count + " entries\n");
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("{\n");

            foreach (int element in Value) {
                sb.Insert(sb.Length, indentString, currentIndentAmount + 1);
                sb.Append(element + ",\n");
            }

            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("}\n");
        }
    }
}
