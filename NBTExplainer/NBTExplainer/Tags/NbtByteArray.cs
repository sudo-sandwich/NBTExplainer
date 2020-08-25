using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents an array of signed bytes
    public class NbtByteArray : NbtTag {
        public IList<sbyte> Value { get; }

        public NbtByteArray(string name) {
            Name = name;
            Value = new List<sbyte>();
        }

        public NbtByteArray(string name, IEnumerable<sbyte> value) {
            Name = name;
            Value = new List<sbyte>(value);
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_Byte_Array('" + Name + "'): " + Value.Count + " entries\n");
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("{\n");

            foreach (sbyte element in Value) {
                sb.Insert(sb.Length, indentString, currentIndentAmount + 1);
                sb.Append(element + ",\n");
            }

            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("}\n");
        }
    }
}
