using BEngine.List;

namespace BEngine
{
    public struct BStringPtr : IListable<BChar>
    {
        public static unsafe implicit operator BStringPtr(BChar* words) => new BStringPtr(words);
        public static unsafe implicit operator BStringPtr(char* words) => new BStringPtr(words);
        public static implicit operator BStringPtr(BChar word) => new BStringPtr(word);
        public static implicit operator BStringPtr(char word) => new BStringPtr(word);
        public static implicit operator BStringPtr(BString bString) => new BStringPtr(bString);
        public static implicit operator BStringPtr(string str) => new BStringPtr(str);
        public static unsafe implicit operator BChar*(BStringPtr bStringPtr) => bStringPtr.ts;
        public static implicit operator BChar[](BStringPtr bStringPtr) => bStringPtr.ToArray();

        private unsafe BChar* ts;
        private int length;

        unsafe BChar this[int i]
        {
            get => *(ts + i);
            set => *(ts + i) = value;
        }

        public unsafe BStringPtr(char* words)
        {
            length = BFuncs.GetSize<char>(words);
            BChar* newTs = stackalloc BChar[length + 1];

            for (var x = 0; x < length; x++)
            {
                *(newTs + x) = *(words + x);
            }
            *(newTs + length) = '\0';
            ts = newTs;
        }

        public unsafe BStringPtr(BChar* words)
        {
            length = BFuncs.GetSize<BChar>(words);
            ts = words;
        }

        public unsafe BStringPtr(BChar word)
        {
            length = 1;
            BChar* newTs = stackalloc BChar[2] { word, '\0' };
            ts = newTs;
        }

        public unsafe BStringPtr(char word)
        {
            length = 1;
            BChar* newTs = stackalloc BChar[2] { word, '\0' };
            ts = newTs;
        }

        public unsafe BStringPtr(BString txt)
        {
            length = txt.Length;
            BChar* newTs = stackalloc BChar[length + 1];
            for (var x = 0; x < length; x++)
            {
                *(newTs + x) = txt[x];
            }
            *(newTs + length) = '\0';
            ts = newTs;
        }

        public unsafe BStringPtr(string txt)
        {
            length = txt.Length;
            BChar* newTs = stackalloc BChar[length + 1];
            for (var x = 0; x < length; x++)
            {
                *(newTs + x) = txt[x];
            }
            *(newTs + length) = '\0';
            ts = newTs;
        }

        public int Length() => length;

        public unsafe BChar* ToPointerArray() => ts;

        public unsafe BChar[] ToArray()
        {
            BChar[] bChars = new BChar[length];
            for (var x = 0; x < length; x++)
            {
                bChars[x] = *(ts + x);
            }
            return bChars;
        }

        public override unsafe string ToString()
        {
            BString txt = "";
            for (var x = 0; x < length; x++)
            {
                txt += *(ts + x);
            }
            return txt;
        }

        public BArray<BChar> ToBArray()
        {
            return ToArray();
        }

        public RepeatableList<BChar> GetRepeatableList()
        {
            throw new System.NotImplementedException();
        }
    }
}
