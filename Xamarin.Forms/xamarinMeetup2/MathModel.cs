// original performance comparition by Егор @Nagg
// https://habrahabr.ru/post/215329/
// source from https://github.com/EgorBo/Xamarin.Android-vs-Java/blob/master/ContactListXamarin/ContactListXamarin/Test1.cs

using System.Collections.Generic;
using System.Text;

namespace xamarinMeetup2
{
    public class MathModel
    {
        public string ArithmeticPerformance { get; set; }

        public string CollectionPerformance { get; set; }

        public string StringPerformance { get; set; }

        public void RunTests()
        {
            long arithmeticAverage = 0;
            long collectionsAverage = 0;
            long stringsAverage = 0;

            for (int i = 0; i < 5; i++)
            {
                arithmeticAverage += CalcArithmetic();
                collectionsAverage += CalcCollections();
                stringsAverage += CalcStrings();
            }

            ArithmeticPerformance = arithmeticAverage / 5 + "ms";
            CollectionPerformance = collectionsAverage / 5 + "ms";
            StringPerformance = stringsAverage / 5 + "ms";
        }

        long CalcArithmetic()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();

            int pans = 0;
            int primes = 0;
            double foo = 0;
            for (int i = 0; i < 12345; i++)
            {
                if (IsPandigital(i))
                    pans++;

                if (IsPrime(i))
                    primes++;

                foo += CalculateFoo(i);
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        long CalcCollections()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();

            var list = new List<FooContainer>(); //let's don't specify initial capacity
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(new FooContainer(i, i));
            }
            var filteredList = new List<FooContainer>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Sum % 2 == 0)
                {
                    filteredList.Add(list[i]);
                }
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        long CalcStrings()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            string result = "";
            var builder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                builder.Append(i);
            }

            result = builder.ToString();
            result = result.Substring(1000);
            result = result.Replace("10", "");
            bool containsSubstring = result.Contains("123");
            string[] parts = result.Split('2');
            int length = parts.Length;
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        bool IsPrime(int n)
        {
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        bool IsPandigital(int n)
        {
            int count = 0;
            int digits = 0;
            int digit;
            int bit;
            do
            {
                digit = n % 10;
                if (digit == 0)
                {
                    return false;
                }
                bit = 1 << digit;

                if (digits == (digits |= bit))
                {
                    return false;
                }

                count++;
                n /= 10;
            } while (n > 0);
            return (1 << count) - 1 == digits >> 1;
        }

        double CalculateFoo(int n)
        {
            double a = 1.0;
            for (int i = 0; i < n; i++)
            {
                a = a * 1.123456789101112 / n;
            }
            return a;
        }
    }

    struct FooContainer
    {
        private readonly int _x;
        private readonly int _y;

        public FooContainer(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int Sum
        {
            get { return _x + _y; }
        }
    }
}