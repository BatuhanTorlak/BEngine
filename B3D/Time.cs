namespace BEngine.B3D
{
    public struct Time
    {
        public static Time operator+ (Time left, Time right) => new Time(left.TotalMilisecond() + right.TotalMilisecond());
        public static Time operator- (Time left, Time right) => new Time(left.TotalMilisecond() - right.TotalMilisecond());

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
        public byte Second
        {
            get => _Second;
            set
            {
                if (value >= 60)
                {
                    Minute += (byte)(value / 60);
                    value = (byte)(value % 60);
                }
                _Second = value;
            }
        }
        private byte _Minute;
        public byte Minute
        {
            get => _Minute;
            set
            {
                if (value >= 60)
                {
                    Hour += (byte)(value / 60);
                    value = (byte)(value % 60);
                }
                _Minute = value;
            }
        }
        private byte _Hour;
        public byte Hour
        {
            get => _Hour;
            set
            {
                if (value >= 24)
                {
                    Day += (value / 24);
                    value = (byte)(value % 24);
                }
                _Hour = value;
            }
        }
        private int _Day;
        public int Day
        {
            get => _Day;
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

        public int TotalMilisecond()
        {
            int milis = Milisecond;
            milis += Second * 1000;
            milis += Minute * 60 * 1000;
            milis += Hour * 60 * 60 * 1000;
            milis += Day * 24 * 60 * 60 * 1000;
            milis += Year * 365 * 24 * 60 * 60 * 1000;
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

        public Time(int milisecond)
        {
            _Second = 0;
            _Minute = 0;
            _Hour = 0;
            _Day = 0;
            _Milisecond = 0;
            Year = 0;
            Minute = 0;
            Second = 0;
            Hour = 0;
            Day = 0;
            if (milisecond <= 0)
            {
                Milisecond = 0;
                return;
            }
            Milisecond = milisecond;
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
                return new Time(x.Millisecond);
            }
        }
    }
}