using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件之观察者设计模式的实现
{
    internal class Mouse //观察者
    {
        private string _name;
        private string _color;
        public Mouse(string name, string color, Cat cat)//传入猫对象实现注册事件
        {
            this._name = name;
            this._color = color;
            /////////////////注册///////////////
            cat.catCome += this.MouseRunging;
        }
        public void MouseRunging()
        {
            Console.WriteLine("大花猫来了！！！{0}：的小老鼠：{1}，跑呀跑呀跑！", this._color, this._name);
        }
    }
}
