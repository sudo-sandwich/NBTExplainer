using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer {
    public class NbtByteReader {
        private BinaryReader Input { get; }
        private bool RequiresReverse { get; set; }

        public NbtByteReader(Stream input, Endian endianness) {
            Input = new BinaryReader(input);

            // the BitConverter class provided by .NET interprets bytes as little endian or big endian depending on the underlying CPU, so we need to reverse the bytes if we have a big endian file on a little endian system, and vice versa
            RequiresReverse = (BitConverter.IsLittleEndian && endianness == Endian.Big) || (!BitConverter.IsLittleEndian && endianness == Endian.Little);
        }

        // check for EOF
        public bool HasNext() {
            // stolen from here: https://stackoverflow.com/a/18084062/7787764
            return Input.BaseStream.Position != Input.BaseStream.Length;
        }

        public int PeekNext() {
            return Input.PeekChar();
        }

        // gets the next byte, then interprets it as a tag type and returns
        public TagType ReadTagType() {
            byte nextByte = Input.ReadByte();

#if DEBUG
            Console.WriteLine(nextByte.ToString("X2"));
#endif

            TagType retValue;
            if (Enum.IsDefined(typeof(TagType), nextByte)) {
                retValue = (TagType)nextByte;
            } else {
                throw new Exception("Next byte does not match any known tag types.");
            }

#if DEBUG
            Console.WriteLine("Next tag type: " + retValue + ".");
#endif

            return retValue;
        }

        // read next byte as unsigned byte
        public byte ReadByte() {
            byte nextByte = Input.ReadByte();

#if DEBUG
            Console.WriteLine(nextByte.ToString("X2"));
            Console.WriteLine("Parsed as " + nextByte + ".");
#endif

            return nextByte;
        }

        // read next bytes as unsigned bytes
        public byte[] ReadBytes(int count) {
            byte[] nextBytes = Input.ReadBytes(count);

#if DEBUG
            foreach (byte b in nextBytes) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Parsed as an array of unsigned bytes.");
#endif

            return nextBytes;
        }

        // read next byte as signed byte
        public sbyte ReadSByte() {
            sbyte nextSByte = Input.ReadSByte();

#if DEBUG
            Console.WriteLine(nextSByte.ToString("X2"));
            Console.WriteLine("Parsed as " + nextSByte + ".");
#endif

            return nextSByte;
        }

        // read next bytes as signed bytes
        public sbyte[] ReadSBytes(int count) {
            sbyte[] nextSBytes = new sbyte[count];

            for (int i = 0; i < count; i++) {
                nextSBytes[i] = ReadSByte();
            }

#if DEBUG
            foreach (byte b in nextSBytes) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Parsed as an array of signed bytes.");
#endif

            return nextSBytes;
        }

        // read next 2 bytes as signed short
        public short ReadShort() {
            byte[] nextShort = Input.ReadBytes(2);

#if DEBUG
            foreach (byte b in nextShort) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif
            
            if (RequiresReverse) {
                Array.Reverse(nextShort);
            }

            short retValue = BitConverter.ToInt16(nextShort, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next 2 bytes as unsigned short
        public ushort ReadUShort() {
            byte[] nextUShort = Input.ReadBytes(2);

#if DEBUG
            foreach (byte b in nextUShort) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            if (RequiresReverse) {
                Array.Reverse(nextUShort);
            }

            ushort retValue = BitConverter.ToUInt16(nextUShort, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next 4 bytes as signed int
        public int ReadInt() {
            byte[] nextInt = Input.ReadBytes(4);

#if DEBUG
            foreach (byte b in nextInt) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            if (RequiresReverse) {
                Array.Reverse(nextInt);
            }

            int retValue = BitConverter.ToInt32(nextInt, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next 8 bytes as signed long
        public long ReadLong() {
            byte[] nextLong = Input.ReadBytes(8);

#if DEBUG
            foreach (byte b in nextLong) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            if (RequiresReverse) {
                Array.Reverse(nextLong);
            }

            long retValue = BitConverter.ToInt64(nextLong, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next 4 bytes as single precision float
        public float ReadFloat() {
            byte[] nextFloat = Input.ReadBytes(4);

#if DEBUG
            foreach (byte b in nextFloat) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            if (RequiresReverse) {
                Array.Reverse(nextFloat);
            }

            float retValue = BitConverter.ToSingle(nextFloat, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next 8 bytes as double precision float
        public double ReadDouble() {
            byte[] nextDouble = Input.ReadBytes(8);

#if DEBUG
            foreach (byte b in nextDouble) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            if (RequiresReverse) {
                Array.Reverse(nextDouble);
            }

            double retValue = BitConverter.ToDouble(nextDouble, 0);

#if DEBUG
            Console.WriteLine("Parsed as " + retValue + ".");
#endif

            return retValue;
        }

        // read next bytes as UTF8 encoded string
        public string ReadString(int length) {
            byte[] nextString = Input.ReadBytes(length);

#if DEBUG
            foreach (byte b in nextString) {
                Console.Write(b.ToString("X2") + " ");
            }
            Console.WriteLine();
#endif

            string retValue = Encoding.UTF8.GetString(nextString);

#if DEBUG
            Console.WriteLine("Parsed as '" + retValue + "'.");
#endif

            return retValue;
        }
    }
}
