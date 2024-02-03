using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLists的自实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.Add(1); //0
            list.Add(2); //1
            list.Add(3); //2
            list.Add(4); //3
            list.Add(5); //4
            try
            {
                list.Insert(2, 100);
            }
            catch (Exception)
            {

                Console.WriteLine("抛出了异常");
            }
            finally
            {
                Console.WriteLine("插入完成");
            }
            Console.WriteLine("**************************************");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
