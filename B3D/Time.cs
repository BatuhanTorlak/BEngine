namespace BEngine.B3D
{
    using List;
    public struct Time
    {
        public static Time operator +(Time left, Time right)
        {
            Time time = new Time();
            time.Milisecond = left.Milisecond + right.Milisecond;
            time.Second += left.Second + right.Second;
            time.Minute += left.Minute + right.Minute;
            time.Hour += left.Hour + right.Hour;
            time.Day += left.Day + right.Day;
            time.Month += left.Month + right.Month;
            time.Year += left.Year + right.Year;
            return time;
        }
        public static Time operator -(Time left, Time right)
        {
            Time time = new Time();
            time.Milisecond = left.Milisecond - right.Milisecond;
            time.Second = left.Second - right.Second;
            time.Minute = left.Minute - right.Minute;
            time.Hour = left.Hour - right.Hour;
            time.Day = left.Day - right.Day;
            time.Month = left.Month - right.Month;
            time.Year = left.Year - right.Year;
            return time;
        }

        private int _Milisecond;
        public int Milisecond
        {
            get => _Milisecond;
            set
            {
                if (value >= 1000)
                {
                    Second += (byte)(value / 1000);
                    value = value % 1000;
                }
                _Milisecond = value;
            }
        }
        private byte _Second;
        public int Second
        {
            get => _Second;
            set
            {
                if (value >= 60)
                {
                    Minute += (byte)(value / 60);
                    value = (byte)(value % 60);
                }
                _Second = (byte)value;
            }
        }
        private byte _Minute;
        public int Minute
        {
            get => _Minute;
            set
            {
                if (value >= 60)
                {
                    Hour += (byte)(value / 60);
                    value = (byte)(value % 60);
                }
                _Minute = (byte)value;
            }
        }
        private byte _Hour;
        public int Hour
        {
            get => _Hour;
            set
            {
                if (value >= 24)
                {
                    Day += (value / 24);
                    value = (byte)(value % 24);
                }
                _Hour = (byte)value;
            }
        }
        private int _Day;
        public int Day
        {
            get => _Day;
            set
            {
                if (value >= MonthsDays[_Month])
                {
                    Month += (value / MonthsDays[_Month]);
                    value = value % MonthsDays[_Month];
                }
                _Day = value;
            }
        }
        public int _Month;
        public int Month
        {
            get => _Month;
            set
            {
                if (value >= 365)
                {
                    Year += (value / 365);
                    value = value % 365;
                }
                _Day = value;
            }
        }
        public int Year;

        public static readonly int[] MonthsDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public float TotalMilisecond()
        {
            float milis = TotalSecond() * 1000;
            return milis;
        }

        public float TotalSecond()
        {
            float sec = Milisecond / 1000;
            sec += Second;
            sec += Minute * 60;
            sec += Hour * 60 * 60;
            sec += Day * 24 * 60 * 60;
            sec += Year * 365 * 24 * 60 * 60;
            return sec;
        }

        public Time(int totalMilisecond)
        {
            _Second = 0;
            _Minute = 0;
            _Hour = 0;
            _Day = 0;
            _Milisecond = 0;
            _Month = 0;
            Year = 0;
            Minute = 0;
            Second = 0;
            Hour = 0;
            Day = 0;
            if (totalMilisecond <= 0)
            {
                Milisecond = 0;
                return;
            }
            Milisecond = totalMilisecond;
        }

        public Time(int milisecond = 0, int second = 0, int minute = 0, int hour = 0, int day = 0, int month = 0, int year = 0)
        {
            _Second = 0;
            _Minute = 0;
            _Hour = 0;
            _Day = 0;
            _Milisecond = 0;
            _Month = 0;
            Year = 0;
            Minute = 0;
            Milisecond = milisecond;
            Second += second;
            Minute += minute;
            Hour += hour;
            Day += day;
            Month += month;
            Year += year;
        }

        public static float DeltaTime
        {
            internal set;
            get;
        }

        public static Time Now
        {
            get
            {
                var x = System.DateTime.Now;
                return new Time(x.Millisecond, x.Second, x.Minute, x.Hour, x.Day, x.Month, x.Year);
            }
        }

        public override string ToString()
        {
            return $"{_Day}.{_Month}.{Year} {_Hour}:{_Minute}:{_Milisecond}";
        }
    }
}