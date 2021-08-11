using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class SinhVien
    {
        public string tensv;
        public SinhVien(string _tensv)
        {
            tensv = _tensv;
        }
    }

    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int tg = a;
            a = b;
            b = tg;
        }

        static void Swap(SinhVien a, SinhVien b)
        {
            string tensv = a.tensv;
            a.tensv = b.tensv;
            b.tensv = tensv;
        }

        static void Main(string[] args)
        {
            Console.Write("Hello World!\n");
            int a, b;
            Console.Write("a = ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("b = ");
            b = Convert.ToInt32(Console.ReadLine());

            Swap(ref a, ref b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            SinhVien sv1 = new SinhVien("Nguyen Van A");
            SinhVien sv2 = new SinhVien("Do Thi B");
            Swap(sv1, sv2);
            Console.WriteLine("sv1 = " + sv1.tensv);
            Console.WriteLine("sv2 = " + sv2.tensv);
            Console.ReadKey();
        }
    }
}
