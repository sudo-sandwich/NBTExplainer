using NBTExplainer.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer {
    public static class NbtParser {
        // parses an nbt file into an NbtTag object, either TAG_Compound or TAG_List
        public static NbtTag ReadFromFile(string filename, Endian endianness) {
#if DEBUG
            Console.WriteLine("Original bytes:");
            foreach (byte b in File.ReadAllBytes(filename)) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.Write("\n\n");
#endif

            using (FileStream originalFileStream = new FileInfo(filename).OpenRead()) {
                int firstByte = originalFileStream.ReadByte();
                originalFileStream.Position = 0;
                // check if this file is valid and if it needs to be decompressed
                switch (firstByte) {
                    case -1:
                        throw new EndOfStreamException();
                    case 0x0A:
                    case 0x09:
                        // first byte is either TAG_Compound or TAG_List, so this file is uncompressed
                        return ReadFromStream(originalFileStream, endianness);
                    case 0x1F:
                        // magic number for gzip
                        using (Stream decompressedBytes = DecompressGZip(originalFileStream)) {
                            return ReadFromStream(decompressedBytes, endianness);
                        }
                    default:
                        throw new Exception("Could not read first byte.");
                }
            }
        }

        public static NbtTag ReadFromStream(Stream inputStream, Endian endianness) {
            NbtByteReader reader = new NbtByteReader(inputStream, endianness);

            TagType firstTagType = reader.ReadTagType();

            // first byte should always be the TAG_Compound ID or TAG_List ID
            switch (firstTagType) {
                case TagType.Compound:
                    return ParseNbtCompound(reader);
                case TagType.List:
                    return ParseNbtList(reader);
                default:
                    throw new Exception("Unknown first byte.");
            }
        }

        // decompress gzipped file
        private static Stream DecompressGZip(Stream compressedStream) {
            MemoryStream decompressedFileStream = new MemoryStream();
            using (GZipStream decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress)) {
                decompressionStream.CopyTo(decompressedFileStream);
            }

            decompressedFileStream.Position = 0;

#if DEBUG
            Console.WriteLine("Decompressed bytes:");
            int nextByte = decompressedFileStream.ReadByte();
            while (nextByte != -1) {
                Console.Write(nextByte.ToString("X2") + " ");
                nextByte = decompressedFileStream.ReadByte();
            }
            Console.Write("\n\n");

            decompressedFileStream.Position = 0;
#endif

            return decompressedFileStream;
        }

        // this is unused, but here in case I actually find a file that uses DEFLATE
        private static Stream DecompressZLib(Stream compressedStream) {
            MemoryStream decompressedFileStream = new MemoryStream();
            using (DeflateStream decompressionStream = new DeflateStream(compressedStream, CompressionMode.Decompress)) {
                decompressionStream.CopyTo(decompressedFileStream);
            }

            decompressedFileStream.Position = 0;

#if DEBUG
            Console.WriteLine("Decompressed bytes:");
            int nextByte = decompressedFileStream.ReadByte();
            while (nextByte != -1) {
                Console.Write(nextByte.ToString("X2") + " ");
                nextByte = decompressedFileStream.ReadByte();
            }
            Console.Write("\n\n");

            decompressedFileStream.Position = 0;
#endif

            return decompressedFileStream;
        }

        // get the next value prefixed by tag type (1 byte) and name length (unsigned short, 2 bytes)
        public static NbtTag ParseNextValueType(NbtByteReader reader) {
            TagType nextTagType = reader.ReadTagType();

            switch (nextTagType) {
                case TagType.Byte:
                    return new NbtByte(ParseString(reader), reader.ReadSByte());
                case TagType.Short:
                    return new NbtShort(ParseString(reader), reader.ReadShort());
                case TagType.Int:
                    return new NbtInt(ParseString(reader), reader.ReadInt());
                case TagType.Long:
                    return new NbtLong(ParseString(reader), reader.ReadLong());
                case TagType.Float:
                    return new NbtFloat(ParseString(reader), reader.ReadFloat());
                case TagType.Double:
                    return new NbtDouble(ParseString(reader), reader.ReadDouble());
                case TagType.ByteArray:
                    return ParseNbtByteArray(reader);
                case TagType.String:
                    return new NbtString(ParseString(reader), ParseString(reader));
                case TagType.List:
                    return ParseNbtList(reader);
                case TagType.Compound:
                    return ParseNbtCompound(reader);
                case TagType.IntArray:
                    return ParseNbtIntArray(reader);
                case TagType.LongArray:
                    return ParseNbtLongArray(reader);
                default:
                    throw new Exception("Should never get here.");
            }
        }

        // get the next non prefixed value. this should only happen in elements of TAG_List
        public static NbtTag ParseNextValueType(NbtByteReader reader, TagType nextTagType) {
            switch (nextTagType) {
                case TagType.Byte:
                    return new NbtByte("", reader.ReadSByte());
                case TagType.Short:
                    return new NbtShort("", reader.ReadShort());
                case TagType.Int:
                    return new NbtInt("", reader.ReadInt());
                case TagType.Long:
                    return new NbtLong("", reader.ReadLong());
                case TagType.Float:
                    return new NbtFloat("", reader.ReadFloat());
                case TagType.Double:
                    return new NbtDouble("", reader.ReadDouble());
                case TagType.ByteArray:
                    return ParseNbtByteArray(reader, false);
                case TagType.String:
                    return new NbtString("", ParseString(reader));
                case TagType.List:
                    return ParseNbtList(reader, false);
                case TagType.Compound:
                    return ParseNbtCompound(reader, false);
                case TagType.IntArray:
                    return ParseNbtIntArray(reader, false);
                case TagType.LongArray:
                    return ParseNbtLongArray(reader, false);
                default:
                    throw new Exception("Should never get here.");
            }
        }

        // strings are prefixed by an unsigned short signifying the length of the string
        public static string ParseString(NbtByteReader reader) {
            ushort nameLength = reader.ReadUShort();
            return reader.ReadString(nameLength);
        }

        // get the next byte array, prefixed by array length (signed int, 4 bytes)
        public static NbtByteArray ParseNbtByteArray(NbtByteReader reader, bool parseName = true) {
            NbtByteArray byteArray = new NbtByteArray(parseName ? ParseString(reader) : "");

            int arrayLength = reader.ReadInt();
            for (int i = 0; i < arrayLength; i++) {
                byteArray.Value.Add(reader.ReadSByte());
            }

            return byteArray;
        }

        // get the next list, prefixed by tag type (1 byte) and array length (signed int, 4 bytes). all elements of TAG_List are not prefixed by tag type or name
        public static NbtList ParseNbtList(NbtByteReader reader, bool parseName = true) {
            NbtList list = new NbtList(parseName ? ParseString(reader) : "", reader.ReadTagType());

            int listLength = reader.ReadInt();
            for (int i = 0; i < listLength; i++) {
                list.Value.Add(ParseNextValueType(reader, list.Type)); // we know the tag type of each element in the list, so we can just pass it in as an argument here
            }

            return list;
        }

        // get the next compound
        public static NbtCompound ParseNbtCompound(NbtByteReader reader, bool parseName = true) {
            NbtCompound compound = new NbtCompound(parseName ? ParseString(reader) : "");

            int nextType = reader.PeekNext();
            // loop until we find TAG_End
            while (nextType != 0x00) {
                compound.Value.Add(ParseNextValueType(reader));

                nextType = reader.PeekNext();
            }
            reader.ReadByte(); //throw away this byte because we know its TAG_End

            return compound;
        }

        // get the next int array, prefixed by array length (signed int, 4 bytes)
        public static NbtIntArray ParseNbtIntArray(NbtByteReader reader, bool parseName = true) {
            NbtIntArray intArray = new NbtIntArray(parseName ? ParseString(reader) : "");

            int arrayLength = reader.ReadInt();
            for (int i = 0; i < arrayLength; i++) {
                intArray.Value.Add(reader.ReadInt());
            }

            return intArray;
        }

        // get the next long array, prefixed by array length (signed int, 4 bytes)
        public static NbtLongArray ParseNbtLongArray(NbtByteReader reader, bool parseName = true) {
            NbtLongArray longArray = new NbtLongArray(parseName ? ParseString(reader) : "");

            int arrayLength = reader.ReadInt();
            for (int i = 0; i < arrayLength; i++) {
                longArray.Value.Add(reader.ReadLong());
            }

            return longArray;
        }
    }
}
