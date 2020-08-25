using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer.Tags {
    // represents an array of unnamed tags. the tags in the array are also not prefixed by their tag type
    public class NbtList : NbtTag {
        public IList<NbtTag> Value { get; }
        public TagType Type { get; set; }

        public NbtList(string name, TagType type) {
            Name = name;
            Type = type;
            Value = new List<NbtTag>();
        }

        public NbtList(string name, TagType type, IEnumerable<NbtTag> value) {
            Name = name;
            Type = type;
            Value = new List<NbtTag>(value);
        }

        public override void PrettyPrint(StringBuilder sb, string indentString, int currentIndentAmount) {
            sb.Insert(sb.Length, indentString, currentIndentAmount);
            sb.Append("TAG_List('" + Name + "'): " + Value.Count + " entries\n");
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
