using BEngine.List;

namespace BEngine
{
    public enum CutType
    {
        Ignore = 0,
        AddFirst = 2,
        AddNext = 3,
        Add = 1
    }

    public static class Text
    {
        internal static readonly BList<char> numbers = new char[]
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9'
        };

        internal static readonly BList<char> Words = new char[]
        {
            'A', 'a', 'B', 'b', 'C', 'c', 'Ç', 'ç', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'Ğ', 'ğ', 'H', 'h', 'I', 'ı', 'İ', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'Ö', 'ö', 'P', 'p', 'R', 'r', 'S', 's', 'Ş', 'ş', 'T', 't', 'U', 'u', 'Ü', 'ü', 'V', 'v', 'Y', 'y', 'Z', 'z', 'W', 'w', 'X', 'x'
        };

        public static string[] Cut(BString title, CutType cutType, BList<char> words)
        {
            var x = new BList<string>();
            var i = "";
            if (!Contains(title, words))
                return new string[1] { title };

            foreach (var a in title.ToCharArray())
            {
                if (words.Contains(a))
                {
                    switch (cutType)
                    {
                        case (CutType.Ignore):
                            x.Add(i);
                            i = "";
                            break;
                        case (CutType.Add):
                            x.Add(i);
                            x.Add(a.ToString());
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

        public static bool Contains(string title, params char[] words)
        {
            bool i = false;

            foreach (var x in words)
            {
                if (title.Contains(x))
                    i = true;
            }

            return i;
        }

        public static bool Contains(string title, params string[] words)
        {
            bool i = false;

            foreach (var x in words)
            {
                if (title.Contains(x))
                    i = true;
            }

            return i;
        }

        public static string GetBetween(string title, string first)
        {
            var x = "";

            return x;
        }
        public static string GetBetween(string title, string first, string second)
        {
            var x = "";

            int c = -2;

            for (var i = 0; i < title.Length / first.Length; i++)
            {
                var d = "";
                for (var z = i * first.Length; z < (i + 1) * first.Length; z++)
                {
                    d += title[z];
                }

                if (d == first)
                {
                    x += d;
                    c++;
                }
                else if (d == second)
                {
                    if (c == -1)
                    {
                        x += d;
                        break;
                    }
                    c--;
                }
                else
                {
                    x += d;
                }
            }

            return x;
        }
        public static string GetBetween(string title, int startIndex, int endIndex)
        {
            var x = "";

            for (var i = startIndex; i < endIndex; i++)
            {
                x += title[i];
            }

            return x;
        }

        public static string Remove(string title, BList<char> notWords)
        {
            var x = "";

            foreach(var i in title)
            {
                if (notWords.Contains(i))
                    continue;

                x += i;
            }

            return x;
        }

        public static int GetEndIndex(string title, int startIndex, char endWord, BList<char> ExpectWords)
        {
            var c = 0;

            foreach (var x in title)
            {
                if (x == endWord)
                {
                    if (c-- == -1)
                    {
                        return c;
                    }
                }
                else if (ExpectWords.Contains(x))
                {
                    c++;
                }
            }

            throw null;
        }
    }
}
