using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternFinder;

namespace PatternFinderTest
{
    class Program
    {
        public static void Test()
        {
            var pattern = Pattern.Transform("456?89?B");
            var data1 = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };
            long o1;
            if (!(Pattern.Find(data1, pattern, out o1) && o1 == 2))
                Console.WriteLine("Test 1 failed...");
            var data2 = new byte[] { 0x01, 0x23, 0x45, 0x66, 0x89, 0x6B, 0xCD, 0xEF };
            long o2;
            if (!(Pattern.Find(data2, pattern, out o2) && o2 == 2))
                Console.WriteLine("Test 2 failed...");
            var data3 = new byte[] { 0x11, 0x11, 0x11, 0x11, 0x11, 0x11, 0x11, 0x11 };
            long o3;
            if (Pattern.Find(data3, pattern, out o3))
                Console.WriteLine("Test 3 failed...");
            Console.WriteLine("Done testing!");
        }

        public static void SignatureTest()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };
            var signatures = new[]
            {
                new Signature("pattern1", "456?89?B"),
                new Signature("pattern2", "1111111111"),
                new Signature("pattern3", "AB??EF"),
            };

            var result = Pattern.Scan(data, signatures);
            foreach (var signature in result)
                Console.WriteLine("found {0} at {1}", signature.Name, signature.FoundOffset);
        }

        static void Main(string[] args)
        {
            Test();
            SignatureTest();
        }
    }
}
