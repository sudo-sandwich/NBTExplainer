# NBTExplainer
Explains the structure of an NBT file.

If you want a C# library that is actually useful, use [fNBT](https://github.com/mstefarov/fNbt).
I made this primarily for fun and as a portfolio booster.
It currently tests notch's original hello_world.nbt and bigtest.nbt files, which are downloaded during runtime, but it should work with basically any nbt file you throw at it.

### Resources used during development

https://wiki.vg/NBT

https://web.archive.org/web/20110723210920/http://www.minecraft.net/docs/NBT.txt

https://github.com/mstefarov/fNbt

#### Sample output

```
Original bytes:
0A 00 0B 68 65 6C 6C 6F 20 77 6F 72 6C 64 08 00 04 6E 61 6D 65 00 09 42 61 6E 61 6E 72 61 6D 61 00 

0A
Next tag type: Compound.
00 0B 
Parsed as 11.
68 65 6C 6C 6F 20 77 6F 72 6C 64 
Parsed as 'hello world'.
08
Next tag type: String.
00 04 
Parsed as 4.
6E 61 6D 65 
Parsed as 'name'.
00 09 
Parsed as 9.
42 61 6E 61 6E 72 61 6D 61 
Parsed as 'Bananrama'.
00
Parsed as 0.

TAG_Compound('hello world'): 1 entries
{
  TAG_String('name'): 'Bananrama'
}

Original bytes:
1F 8B 08 00 00 00 00 00 00 00 ED 54 CF 4F 1A 41 14 7E C2 02 CB 96 82 B1 C4 10 63 CC AB B5 84 A5 DB CD 42 11 89 B1 88 16 2C 9A 0D 1A D8 A8 31 86 B8 2B C3 82 2E BB 66 77 B0 F1 D4 4B 7B 6C 7A EB 3F D3 23 7F 43 CF BD F6 BF A0 C3 2F 7B 69 CF BD F0 32 C9 F7 E6 BD 6F E6 7B 6F 26 79 02 04 54 72 4F 2C 0E 78 CB B1 4D 8D 78 F4 E3 70 62 3E 08 7B 1D C7 A5 93 18 0F 82 47 DD EE 84 02 62 B5 A2 AA C7 78 76 5C 57 CB A8 55 0F 1B C8 D6 1E 6A 95 86 86 0D AD 7E 58 7B 8F 83 CF 83 4F 83 6F CF 03 10 6E 5B 8E 3E BE A5 38 4C 64 FD 10 EA DA 74 A6 23 40 DC 66 2E 69 E1 B5 D3 BB 73 FA 76 0B 29 DB 0B E0 EF E8 3D 1E 38 5B EF 11 08 56 F5 DE 5D DF 0B 40 E0 5E B7 FA 64 B7 04 00 8C 41 4C 73 C6 08 55 4C D3 20 2E 7D A4 C0 C8 C2 10 B3 BA DE 58 0B 53 A3 EE 44 8E 45 03 30 B1 27 53 8C 4C F1 E9 14 A3 53 8C 85 E1 D9 9F E3 B3 F2 44 81 A5 7C 33 DD D8 BB C7 AA 75 13 5F 28 1C 08 D7 2E D1 59 3F AF 1D 1B 60 21 59 DF FA F1 05 FE C1 CE FC 9D BD 00 BC F1 40 C9 F8 85 42 40 46 FE 9E EB EA 0F 93 3A 68 87 60 BB EB 32 37 A3 28 0A 8E BB F5 D0 69 63 CA 4E DB E9 EC E6 E6 2B 3B BD 25 BE 64 49 09 3D AA BB 94 FD 18 7E E8 D2 0E DA 6F 15 4C B1 68 3E 2B E1 9B 9C 84 99 BC 84 05 09 65 59 16 45 00 FF 2F 28 AE 2F F2 C2 B2 A4 2E 1D 20 77 5A 3B B9 8C CA E7 29 DF 51 41 C9 16 B5 C5 6D A1 2A AD 2C C5 31 7F BA 7A 92 8E 5E 9D 5F F8 12 05 23 1B D1 F6 B7 77 AA CD 95 72 BC 9E DF 58 5D 4B 97 AE 92 17 B9 44 D0 80 C8 FA 3E BF B3 DC 54 CB 07 75 6E A3 B6 76 59 92 93 A9 DC 51 50 99 6B CC 35 E6 1A FF 57 23 08 42 CB E9 1B D6 78 C2 EC FE FC 7A FB 7D 78 D3 84 DF D4 F2 A4 FB 08 06 00 00 

Decompressed bytes:
0A 00 05 4C 65 76 65 6C 04 00 08 6C 6F 6E 67 54 65 73 74 7F FF FF FF FF FF FF FF 02 00 09 73 68 6F 72 74 54 65 73 74 7F FF 08 00 0A 73 74 72 69 6E 67 54 65 73 74 00 29 48 45 4C 4C 4F 20 57 4F 52 4C 44 20 54 48 49 53 20 49 53 20 41 20 54 45 53 54 20 53 54 52 49 4E 47 20 C3 85 C3 84 C3 96 21 05 00 09 66 6C 6F 61 74 54 65 73 74 3E FF 18 32 03 00 07 69 6E 74 54 65 73 74 7F FF FF FF 0A 00 14 6E 65 73 74 65 64 20 63 6F 6D 70 6F 75 6E 64 20 74 65 73 74 0A 00 03 68 61 6D 08 00 04 6E 61 6D 65 00 06 48 61 6D 70 75 73 05 00 05 76 61 6C 75 65 3F 40 00 00 00 0A 00 03 65 67 67 08 00 04 6E 61 6D 65 00 07 45 67 67 62 65 72 74 05 00 05 76 61 6C 75 65 3F 00 00 00 00 00 09 00 0F 6C 69 73 74 54 65 73 74 20 28 6C 6F 6E 67 29 04 00 00 00 05 00 00 00 00 00 00 00 0B 00 00 00 00 00 00 00 0C 00 00 00 00 00 00 00 0D 00 00 00 00 00 00 00 0E 00 00 00 00 00 00 00 0F 09 00 13 6C 69 73 74 54 65 73 74 20 28 63 6F 6D 70 6F 75 6E 64 29 0A 00 00 00 02 08 00 04 6E 61 6D 65 00 0F 43 6F 6D 70 6F 75 6E 64 20 74 61 67 20 23 30 04 00 0A 63 72 65 61 74 65 64 2D 6F 6E 00 00 01 26 52 37 D5 8D 00 08 00 04 6E 61 6D 65 00 0F 43 6F 6D 70 6F 75 6E 64 20 74 61 67 20 23 31 04 00 0A 63 72 65 61 74 65 64 2D 6F 6E 00 00 01 26 52 37 D5 8D 00 01 00 08 62 79 74 65 54 65 73 74 7F 07 00 65 62 79 74 65 41 72 72 61 79 54 65 73 74 20 28 74 68 65 20 66 69 72 73 74 20 31 30 30 30 20 76 61 6C 75 65 73 20 6F 66 20 28 6E 2A 6E 2A 32 35 35 2B 6E 2A 37 29 25 31 30 30 2C 20 73 74 61 72 74 69 6E 67 20 77 69 74 68 20 6E 3D 30 20 28 30 2C 20 36 32 2C 20 33 34 2C 20 31 36 2C 20 38 2C 20 2E 2E 2E 29 29 00 00 03 E8 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 00 3E 22 10 08 0A 16 2C 4C 12 46 20 04 56 4E 50 5C 0E 2E 58 28 02 4A 38 30 32 3E 54 10 3A 0A 48 2C 1A 12 14 20 36 56 1C 50 2A 0E 60 58 5A 02 18 38 62 32 0C 54 42 3A 3C 48 5E 1A 44 14 52 36 24 1C 1E 2A 40 60 26 5A 34 18 06 62 00 0C 22 42 08 3C 16 5E 4C 44 46 52 04 24 4E 1E 5C 40 2E 26 28 34 4A 06 30 06 00 0A 64 6F 75 62 6C 65 54 65 73 74 3F DF 8F 6B BB FF 6A 5E 00 

0A
Next tag type: Compound.
00 05 
Parsed as 5.
4C 65 76 65 6C 
Parsed as 'Level'.
04
Next tag type: Long.
00 08 
Parsed as 8.
6C 6F 6E 67 54 65 73 74 
Parsed as 'longTest'.
7F FF FF FF FF FF FF FF 
Parsed as 9223372036854775807.
02
Next tag type: Short.
00 09 
Parsed as 9.
73 68 6F 72 74 54 65 73 74 
Parsed as 'shortTest'.
7F FF 
Parsed as 32767.
08
Next tag type: String.
00 0A 
Parsed as 10.
73 74 72 69 6E 67 54 65 73 74 
Parsed as 'stringTest'.
00 29 
Parsed as 41.
48 45 4C 4C 4F 20 57 4F 52 4C 44 20 54 48 49 53 20 49 53 20 41 20 54 45 53 54 20 53 54 52 49 4E 47 20 C3 85 C3 84 C3 96 21 
Parsed as 'HELLO WORLD THIS IS A TEST STRING Ž™!'.
05
Next tag type: Float.
00 09 
Parsed as 9.
66 6C 6F 61 74 54 65 73 74 
Parsed as 'floatTest'.
3E FF 18 32 
Parsed as 0.4982315.
03
Next tag type: Int.
00 07 
Parsed as 7.
69 6E 74 54 65 73 74 
Parsed as 'intTest'.
7F FF FF FF 
Parsed as 2147483647.
0A
Next tag type: Compound.
00 14 
Parsed as 20.
6E 65 73 74 65 64 20 63 6F 6D 70 6F 75 6E 64 20 74 65 73 74 
Parsed as 'nested compound test'.
0A
Next tag type: Compound.
00 03 
Parsed as 3.
68 61 6D 
Parsed as 'ham'.
08
Next tag type: String.
00 04 
Parsed as 4.
6E 61 6D 65 
Parsed as 'name'.
00 06 
Parsed as 6.
48 61 6D 70 75 73 
Parsed as 'Hampus'.
05
Next tag type: Float.
00 05 
Parsed as 5.
76 61 6C 75 65 
Parsed as 'value'.
3F 40 00 00 
Parsed as 0.75.
00
Parsed as 0.
0A
Next tag type: Compound.
00 03 
Parsed as 3.
65 67 67 
Parsed as 'egg'.
08
Next tag type: String.
00 04 
Parsed as 4.
6E 61 6D 65 
Parsed as 'name'.
00 07 
Parsed as 7.
45 67 67 62 65 72 74 
Parsed as 'Eggbert'.
05
Next tag type: Float.
00 05 
Parsed as 5.
76 61 6C 75 65 
Parsed as 'value'.
3F 00 00 00 
Parsed as 0.5.
00
Parsed as 0.
00
Parsed as 0.
09
Next tag type: List.
00 0F 
Parsed as 15.
6C 69 73 74 54 65 73 74 20 28 6C 6F 6E 67 29 
Parsed as 'listTest (long)'.
04
Next tag type: Long.
00 00 00 05 
Parsed as 5.
00 00 00 00 00 00 00 0B 
Parsed as 11.
00 00 00 00 00 00 00 0C 
Parsed as 12.
00 00 00 00 00 00 00 0D 
Parsed as 13.
00 00 00 00 00 00 00 0E 
Parsed as 14.
00 00 00 00 00 00 00 0F 
Parsed as 15.
09
Next tag type: List.
00 13 
Parsed as 19.
6C 69 73 74 54 65 73 74 20 28 63 6F 6D 70 6F 75 6E 64 29 
Parsed as 'listTest (compound)'.
0A
Next tag type: Compound.
00 00 00 02 
Parsed as 2.
08
Next tag type: String.
00 04 
Parsed as 4.
6E 61 6D 65 
Parsed as 'name'.
00 0F 
Parsed as 15.
43 6F 6D 70 6F 75 6E 64 20 74 61 67 20 23 30 
Parsed as 'Compound tag #0'.
04
Next tag type: Long.
00 0A 
Parsed as 10.
63 72 65 61 74 65 64 2D 6F 6E 
Parsed as 'created-on'.
00 00 01 26 52 37 D5 8D 
Parsed as 1264099775885.
00
Parsed as 0.
08
Next tag type: String.
00 04 
Parsed as 4.
6E 61 6D 65 
Parsed as 'name'.
00 0F 
Parsed as 15.
43 6F 6D 70 6F 75 6E 64 20 74 61 67 20 23 31 
Parsed as 'Compound tag #1'.
04
Next tag type: Long.
00 0A 
Parsed as 10.
63 72 65 61 74 65 64 2D 6F 6E 
Parsed as 'created-on'.
00 00 01 26 52 37 D5 8D 
Parsed as 1264099775885.
00
Parsed as 0.
01
Next tag type: Byte.
00 08 
Parsed as 8.
62 79 74 65 54 65 73 74 
Parsed as 'byteTest'.
7F
Parsed as 127.
07
Next tag type: ByteArray.
00 65 
Parsed as 101.
62 79 74 65 41 72 72 61 79 54 65 73 74 20 28 74 68 65 20 66 69 72 73 74 20 31 30 30 30 20 76 61 6C 75 65 73 20 6F 66 20 28 6E 2A 6E 2A 32 35 35 2B 6E 2A 37 29 25 31 30 30 2C 20 73 74 61 72 74 69 6E 67 20 77 69 74 68 20 6E 3D 30 20 28 30 2C 20 36 32 2C 20 33 34 2C 20 31 36 2C 20 38 2C 20 2E 2E 2E 29 29 
Parsed as 'byteArrayTest (the first 1000 values of (n*n*255+n*7)%100, starting with n=0 (0, 62, 34, 16, 8, ...))'.
00 00 03 E8 
Parsed as 1000.
00
Parsed as 0.
3E
Parsed as 62.
22
Parsed as 34.
...
(output omitted)
...
06
Parsed as 6.
30
Parsed as 48.
06
Next tag type: Double.
00 0A 
Parsed as 10.
64 6F 75 62 6C 65 54 65 73 74 
Parsed as 'doubleTest'.
3F DF 8F 6B BB FF 6A 5E 
Parsed as 0.493128713218231.
00
Parsed as 0.

TAG_Compound('Level'): 11 entries
{
  TAG_Long('longTest'): 9223372036854775807L
  TAG_Short('shortTest'): 32767
  TAG_String('stringTest'): 'HELLO WORLD THIS IS A TEST STRING Ž™!'
  TAG_Float('floatTest'): 0.4982315
  TAG_Int('intTest'): 2147483647
  TAG_Compound('nested compound test'): 2 entries
  {
    TAG_Compound('ham'): 2 entries
    {
      TAG_String('name'): 'Hampus'
      TAG_Float('value'): 0.75
    }
    TAG_Compound('egg'): 2 entries
    {
      TAG_String('name'): 'Eggbert'
      TAG_Float('value'): 0.5
    }
  }
  TAG_List('listTest (long)'): 5 entries
  {
    TAG_Long(''): 11L
    TAG_Long(''): 12L
    TAG_Long(''): 13L
    TAG_Long(''): 14L
    TAG_Long(''): 15L
  }
  TAG_List('listTest (compound)'): 2 entries
  {
    TAG_Compound(''): 2 entries
    {
      TAG_String('name'): 'Compound tag #0'
      TAG_Long('created-on'): 1264099775885L
    }
    TAG_Compound(''): 2 entries
    {
      TAG_String('name'): 'Compound tag #1'
      TAG_Long('created-on'): 1264099775885L
    }
  }
  TAG_Byte('byteTest'): 127
  TAG_Byte_Array('byteArrayTest (the first 1000 values of (n*n*255+n*7)%100, starting with n=0 (0, 62, 34, 16, 8, ...))'): 1000 entries
  {
    0,
    62,
    34,
...
(output omitted)
...
    6,
    48,
  }
  TAG_Double('doubleTest'): 0.493128713218231
}

 
