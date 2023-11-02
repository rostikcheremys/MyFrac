using System;

namespace Program
{
    public class MyFrac
    {
        private readonly long _numerator;
        private readonly long _denominator;
        private readonly int _pointer;

        public MyFrac(long n, long d)
        {
            if (n == 0)
            {
                _numerator = 0;
                _denominator = 1;
                _pointer = 0;
            }
            else if ((n < 0 && d > 0) || (n > 0 && d < 0))
            {
                _pointer = 1;
                long divider = BiggestDivider(Math.Abs(n), Math.Abs(d));
                _numerator = -Math.Abs(n) / divider;
                _denominator = Math.Abs(d) / divider;
            }
            else
            {
                _pointer = 0;
                long divider = BiggestDivider(Math.Abs(n), Math.Abs(d));
                _numerator = Math.Abs(n) / divider;
                _denominator = Math.Abs(d) / divider;
            }
        }
        
        private long BiggestDivider(long numerator, long denominator)
        {
            while (denominator != numerator)
            {
                if (denominator > numerator)
                {
                    denominator -= numerator;
                }
                else
                {
                    numerator -= denominator;
                }
            }

            return numerator;
        }

        public string ToStringWithIntegerPart()
        {
            if (Math.Abs(_numerator) <= Math.Abs(_denominator)) return ToString();
            
            if (_numerator % _denominator == 0)
            {
                return ToString();
            }

            long integerPart = _numerator / _denominator;
                
            if (_pointer == 1)
            {
                return $"-({Math.Abs(integerPart)} + {Math.Abs(_numerator) % Math.Abs(_denominator)}/{Math.Abs(_denominator)})";
            }
                    
            return $"({integerPart} + {_numerator % _denominator}/{_denominator})";

        }

        public double DoubleValue()
        {
            return Convert.ToDouble(_numerator) / Convert.ToDouble(_denominator);
        }

        public MyFrac Plus(MyFrac frac)
        {
            return new MyFrac(_numerator * frac._denominator + _denominator * frac._numerator, _denominator * frac._denominator);
        }

        public MyFrac Minus(MyFrac frac)
        {
            return new MyFrac(_numerator * frac._denominator - _denominator * frac._numerator, _denominator * frac._denominator);
        }

        public MyFrac Multiply(MyFrac frac)
        {
            return new MyFrac(_numerator * frac._numerator, _denominator * frac._denominator);
        }

        public MyFrac Divide(MyFrac frac)
        {
            return new MyFrac(_numerator * frac._denominator, _denominator * frac._numerator);
        }

        public MyFrac CalcSumFirst(int number)
        {
            MyFrac result = new MyFrac(0, 1);

            for (int i = 1; i <= number; i++)
            {
                MyFrac adding = new MyFrac(1, i * (i + 1));

                result = result.Plus(adding);
            }

            return result;
        }

        public MyFrac CalcSumSecond(int number)
        {
            MyFrac result = new MyFrac(1, 1).Minus(new MyFrac(1, 4));

            for (int i = 3; i <= number; i++)
            {
                MyFrac adding = new MyFrac(1, 1).Minus(new MyFrac(1, i * i));

                result = result.Multiply(adding);
            }

            return result;
        }

        public override string ToString()
        {
            if (_numerator == 0) return "0";
               
            if (_numerator == _denominator && _pointer == 0) return "1";
                
            if (Math.Abs(_numerator) == Math.Abs(_denominator) && _pointer == 1) return "-1";
                
            return $"{_numerator}/{_denominator}";
        }
    }
}
