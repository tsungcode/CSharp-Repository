using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 事件之观察者设计模式的实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("TOM", "橘黄色");
            Mouse mike = new Mouse("MICKEY", "灰色", cat);  //传入猫对象实现注册事件
            Mouse jrr = new Mouse("JERRY", "黑色", cat);     //传入猫对象实现注册事件
            #region 笨实现注册方法
            //cat.catCome = mike.MouseRunging; //注册事件
            //cat.catCome += jrr.MouseRunging; //注册事件
            #endregion
            cat.CatComing();    //猫的状态发生改变，从而触发事件
            //cat.catCome();    //如果被观察中声明的是委托不是事件的话，这儿就可以直接调用委托调用，会不安全，如果被观察中声明的是事件此处就不能调用
            Console.ReadKey();
        }
    }
}
