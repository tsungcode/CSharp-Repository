using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件之观察者设计模式的实现
{
    internal class Cat  //被观察者
    {
        private string _name;
        private string _color;
        //public Action catCome;      //声明了委托变量   
        public event Action catCome;  //声明事件
        public Cat(string name, string color)
        {
            this._name = name;
            this._color = color;
        }
        public void CatComing()
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine("{0}:的大花猫:{1},走过来了", this._color, this._name);
            Console.WriteLine("******************************************************");
            if (catCome != null)
            {
                catCome();  //触发事件
            }
            Console.WriteLine("******************************************************");
        }
    }
}
