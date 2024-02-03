using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ查询方法
{
    public class Person
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return string.Format("id=:{0},name=:{1},title=:{2}", this.Id, this.Name, this.Title);
        }
    }
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return string.Format("ID={0},Name={1},Title={2}", this.Id, this.Name
                , this.Title);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> listPerson = new List<Person>() {
                new Person(){Id = 2, Name = "张三", Title = "好人" },
                new Person(){Id = 3, Name = "李四", Title = "坏人" },
                new Person(){Id = 4, Name = "王五", Title = "渣男" },
                new Person(){Id = 1, Name = "赵六", Title = "贱人" },
                new Person(){Id = 5, Name = "田七", Title = "痞子" },
                new Person(){Id = 6, Name = "小坏蛋", Title = "痞子" },
            };
            List<Student> listStu = new List<Student>()
            {
                new Student(){Id="A",Name="张三",Title="坏人"},
                new Student(){Id="C",Name="田七",Title="坏人"},
                new Student(){Id="D",Name="李四",Title="好人"},
                new Student(){Id="B",Name="王五",Title="好人"},
                new Student(){Id="E",Name="赵六",Title="坏人"},
            };
            Console.WriteLine("****************************************");
            /////////////////////////1、表达式的写法//////////////////////////
            Console.WriteLine("1、表达式查询");
            var s = from m in listPerson      //from后面设置查询的集合
                    where m.Id > 3            //where后面跟上查询的条件
                    select m;                 //selet表示把查询的结果返回
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("2、表达式查询");
            var s1 = from m in listPerson      //from后面设置查询的集合
                     where m.Id > 3            //where后面跟上查询的条件
                     select m.Name;            //selet表示把查询的结果返回
            foreach (var item in s1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            /////////////////////////2、扩展方法的写法//////////////////////////
            Console.WriteLine("4、扩展方法查询");
            Func<Person, bool> f = m => m.Id > 2;    //过滤方法
            var s2 = listPerson.Where(f);  //扩展方法where中参数是一个方法，可以传入lambda
            var s3 = listPerson.Where(m => m.Id > 2 && m.Title == "痞子");
            foreach (var item in s2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("5、扩展方法之两个条件查询");
            foreach (var item in s3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            //////////////////////3，联合查询////////////////////////////////
            Console.WriteLine("6、联合查询");
            var s4 = from m in listPerson
                     from n in listStu
                     select new { Per = m, Stu = n };
            foreach (var item in s4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("7、联合查询之限制条件");
            var s5 = from m in listPerson
                     from n in listStu
                     where m.Name == n.Name
                     select new { Per = m, Stu = n };
            foreach (var item in s5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("8、联合查询之限制条件");
            var s6 = from m in listPerson
                     from n in listStu
                     where m.Name == n.Name && m.Title == "好人"
                     select m;
            foreach (var item in s6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("9、联合查询之扩展方法查询");
            //var s7 = listPerson.SelectMany(m => listStu, (m, k) => new { Per = m, Stu = k });
            var s7 = listPerson.SelectMany(m => listStu, (m, k) => new { Per = m, Stu = k }).Where(x => x.Per.Title == "好人");
            foreach (var item in s7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("10、orderby/descending排序查询");
            var s8 = from m in listPerson
                     orderby m.Id  //默认从小到大排序，可设置多个字段排序，如果第一个字段相同则按照第二个字段排序
                     select m;
            foreach (var item in s8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("11、倒序排序descending排序查询");
            var s9 = from m in listPerson
                     orderby m.Id descending  //按年龄倒排序，先排序，然后倒序排序
                     select m;
            foreach (var item in s9)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("12、扩展方法排序查询");
            var s10 = listStu.Where(m => m.Title == "坏人").OrderBy(m => m.Id);
            //var s11 = listStu.Where(m => m.Title == "坏人").OrderBy(m => m.Id).ThenBy(m => m.Name);//先按id排，如id相同在按ThenBy中的name排
            foreach (var item in s10)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("13、jion on 集合联合查询");
            var s11 = from m in listPerson
                      join n in listStu on m.Name equals n.Name   //on后跟条件
                      where m.Id > 3
                      select new { Per = m, Stu = n };
            foreach (var item in s11)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("14、分组查询");
            var s12 = from m in listStu
                      join n in listPerson on m.Title equals n.Title
                      into groups
                      select new { Per = m, count = groups.Count() };
            foreach (var item in s12)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("15、any all 量词查询");
            //any判断至少有一个满足
            bool res1 = listPerson.Any(m => m.Name == "张三");
            bool res2 = listPerson.All(n => n.Title == "好人");
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine("****************************************");
            Console.WriteLine("**********以下为定义测试实现**************");
            Console.WriteLine("****************************************");
            Console.WriteLine("16、Select、OrderBy词查询");
            int[] arry = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var lis = arry.Where(num => num < 10).Select(num => num * num).OrderByDescending(num => num);
            List<int> list = new List<int>();
            foreach (var item in lis)
            {
                Console.Write(item);
                Console.Write("\t");
                list.Add(item);
            }
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item);
                Console.Write("\t");
            }
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("17、GroupBy分组查询");
            List<string> lstr = new List<string>() { "张三", "李四", "张二", "张一", "王五", "赵六", "赵七", "李八" };
            var ls = lstr.Select(itme => itme).GroupBy(i => i.Substring(0, 1));
            foreach (var item in ls)
            {
                Console.WriteLine(".......................");
                Console.WriteLine("分组字段:{0}", item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("18、Count()查询统计");
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ar1 = (from i in ar
                       where i > 7
                       select i
                     ).Count();
            Console.WriteLine(ar1);
            Console.ReadKey(true);
        }
    }
}
