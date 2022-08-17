#define BSTRING

using BEngine.MathB;
using BEngine.List;

namespace BEngine
{
    public partial struct BString
    {
        public static BString operator +(BString right, char left)
        {
            var x = right.GetResize(right.Length + 1);
            x[right.Length] = left;
            return x;
        }
        public static BString operator +(BString right, char[] left)
        {
            var x = right.metin;
            var z = new char[x.Length + left.Length];

            for (var i = 0; i < x.Length; i++)
            {
                z[i] = x[i];
            }
            for (var i = 0; i < left.Length; i++)
            {
                z[i + x.Length] = left[i];
            }

            return new BString(z);
        }
        public static BString operator +(BString b1, BString b2)
        {
            var x = b1.metin;
            var y = b2.metin;
            var z = new char[x.Length + y.Length];

            for(var i = 0; i < x.Length; i++)
            {
                z[i] = x[i];
            }
            for (var i = 0; i < y.Length; i++)
            {
                z[i + x.Length] = y[i];
            }

            return new BString(z);
        }
        public static BString operator +(BString b1, object obj) => b1 + new BString(obj);
        public static BString operator +(object obj, BString b1) => new BString(obj) + b1;
        public static implicit operator BString(bool Bool) => new BString(Bool);
        public static implicit operator BString(char[] title) => new BString(title);
        public static implicit operator BString(char word) => new BString(word);
        public static implicit operator BString(string title) => new BString(title);
        public static implicit operator BString(float nums) => new BString(nums);
        public static implicit operator BString(double nums) => new BString(nums);
        public static implicit operator BString(int nums) => new BString(nums);
        public static implicit operator BString(long nums) => new BString(nums);
        public static implicit operator BString(byte nums) => new BString(nums);
        public static implicit operator BString(short nums) => new BString(nums);
        public static implicit operator BString(uint nums) => new BString(nums);
        public static implicit operator BString(ulong nums) => new BString(nums);
        public static implicit operator BString(sbyte nums) => new BString(nums);
        public static implicit operator BString(ushort nums) => new BString(nums);
        public static implicit operator BString(Irr32 nums) => new BString(nums);
        public static explicit operator char[](BString bString) => bString.metin;
        public static implicit operator string(BString bString) => bString.ToString();

        internal char[] metin;

        public int Length => (metin != null) ? metin.Length : 0;

        public char this[int i]
        {
            get
            {
                return metin[i];
            }
            set
            {
                metin[i] = value;
            }
        }
        public BString this[int start, int end] => GetBetween(start, end);

        private BString(char[] titles)
        {
            metin = new char[titles.Length];

            for (var x = 0; x < metin.Length; x++)
            {
                metin[x] = titles[x];
            }
        }

        private BString(object other)
        {
            metin = other.ToString().ToCharArray();
        }

        internal BString(BChar bChar)
        {
            metin = new char[]{ bChar };
        }

        internal BString(params BChar[] bChars)
        {
            metin = new char[bChars.Length];
            for (var x = 0; x < metin.Length; x++)
            {
                metin[x] = bChars[x];
            }
        }

        public bool Contains(params char[] words)
        {
            foreach (var x in metin)
            {
                foreach(var i in words)
                {
                    if (i == x)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Contains(char words)
        {
            foreach (var x in metin)
            {
                if (x == words)
                    return true;
            }
            return false;
        }

        public bool Contains(string words)
        {
            var ct = words.Length;

            for (var x = 0; x < metin.Length; x++)
            {
                var i = true;
                for (var y = 0; y < ct; y++)
                {
                    if (metin[x + y] != words[y])
                    {
                        i = false;
                        break;
                    }
                }
                if (i)
                    return true;
            }
            return false;
        }

        public bool Contains(BString words)
        {
            var ct = words.Length;

            for (var x = 0; x < metin.Length; x++)
            {
                var i = true;
                for (var y = 0; y < ct; y++)
                {
                    if (metin[x + y] != words[y])
                    {
                        i = false;
                        break;
                    }
                }
                if (i)
                    return true;
            }
            return false;
        }

        public BString[] Cut(CutType cutType, BList<char> filter)
        {
            var x = new BList<BString>();
            var i = "";
            if (!Contains(filter))
                return new BString[1] { ToString() };

            foreach (var a in metin)
            {
                if (filter.Contains(a))
                {
                    switch (cutType)
                    {
                        case (CutType.Ignore):
                            x.Add(i);
                            i = "";
                            break;
                        case (CutType.Add):
                            x.Add(i);
                            x.Add(a);
                            i = "";
                            break;
                        case (CutType.AddFirst):
                            x.Add(i + a);
                            i = "";
                            break;
                        case (CutType.AddNext):
                            x.Add(i);
                            i = "" + a;
                            break;
                    }
                    continue;
                }
                i += a;
            }
            if (i.Length != 0)
                switch (cutType)
                {
                    case (CutType.Add):
                        x.Add(i);
                        break;
                    case (CutType.AddFirst):
                        x.Add(i);
                        break;
                    case (CutType.AddNext):
                        x.Add(i);
                        break;
                }
            x.Add(i);
            return x.ToArray();
        }

        public BString GetBetween(int endIndex)
        {
            if (endIndex == Length)
            {
                return this;
            }
            if (endIndex < 0)
            {
                throw new System.Exception("Not Allowed Negative Size");
            }
            if (endIndex > Length)
            {
                throw new System.Exception("Index Out Of Range");
            }
            if (endIndex == 0)
            {
                return "";
            }

            BString newTitle = "";

            for (var x = 0; x < endIndex; x++)
            {
                newTitle += metin[x];
            }

            return newTitle;
        }

        public BString GetBetween(int startIndex, int endIndex)
        {
            if (startIndex < 0 | endIndex < 0)
            {
                throw new System.Exception("Not Allowed Negative Size");
            }
            if (startIndex > Length | endIndex > Length)
            {
                throw new System.Exception("Index Out Of Range");
            }
            if (startIndex == endIndex)
            {
                return metin[startIndex];
            }
            if (startIndex == 0 & endIndex == Length)
            {
                return this;
            }
            if (endIndex == 0 & startIndex == Length)
            {
                return GetReverse();
            }

            BString NormalTitle = metin;
            if (startIndex > endIndex)
            {
                NormalTitle = GetReverse();
                var x = Length - 1 - endIndex;
                endIndex = Length - 1 - startIndex;
                startIndex = x;
            }
            BString title = new BString();

            for (var x = startIndex; x < endIndex; x++)
            {
                title += NormalTitle[x];
            }

            return title;
        }

        public BString GetReverse()
        {
            if (Length == 0)
                return "";
            if (Length == 1)
                return this;

            char[] vs = new char[Length];

            for (var x = 0; x < Length; x++)
            {
                vs[x] += metin[Length - 1 - x];
            }

            return vs;
        }

        public BString Resize(int len)
        {
            if (len == Length)
            {
                return this;
            }
            if (len < 0)
            {
                throw new System.Exception("Not Allowed Negative Size");
            }
            if (len == 0)
            {
                return "";
            }

            var newMetin = new char[len];

            for (var x = 0; x < len; x++)
            {
                if (x >= Length)
                {
                    newMetin[x] = ' ';
                    continue;
                }
                newMetin[x] = metin[x];
            }

            this = newMetin;
            return newMetin;
        }

        public BString GetResize(int len)
        {
            if (len == Length)
            {
                return this;
            }
            if (len < 0)
            {
                throw new System.Exception("Not Allowed Negative Size");
            }
            if (len == 0)
            {
                return "";
            }

            var newMetin = new char[len];

            for (var x = 0; x < len; x++)
            {
                if (x >= Length)
                {
                    newMetin[x] = ' ';
                    continue;
                }
                newMetin[x] = metin[x];
            }
            
            return newMetin;
        }

        public override string ToString()
        {
            string i = "";

            if (metin == null)
                metin = new char[0];
             
            foreach (var x in metin)
                i += x;
            
            return i;
        }

        public char[] ToCharArray()
        {
            return metin;
        }
    }
}
