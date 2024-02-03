using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLists的自实现
{
    internal class MyList
    {
        private int[] arry;    //声明容器变量
        private int count = 0; //声明当前元素个数
        public int Count       //count的属性(获取当前元素个数）
        {
            get { return count; }
        }
        private int capacity;  //声明当前容量
        public int Capacity    //capacity属性（获取当前容器大小）
        {
            get { return capacity; }
        }
        //////////////////////////////////////////////////////////////////////////
        public MyList()        //默认构造函数,默认开辟容量为5
        {
            capacity = 5;
            arry = new int[capacity];
        }
        public MyList(int size)//有参构造
        {
            if (size >= 0)
            {
                capacity = size;
                arry = new int[this.Capacity];
            }
            else  //申请开辟为0个则创建空容器
            {
                arry = new int[0];//创建失败
                capacity = 0;
            }
        }
        ///////////////////////////////////////////////////////////////
        //容器中添加数据
        public void Add(int value)            //添加数据
        {
            if (this.Count == this.Capacity)  //容器满了或是空容器时
            {
                if (Capacity == 0)    //当容器容量为0时，扩大为容量为5
                {
                    capacity = 5;
                    arry = new int[this.Capacity];
                    arry[this.Count] = value;   //添加元素
                    count++;
                }
                else  //不是容器空间为0,而是容器满了时
                {
                    capacity += 5;   //容量扩容5
                    var newArry = new int[this.Capacity];      //创建新容器
                    Array.Copy(this.arry, newArry, this.Count);//将原容器拷贝到新容器
                    arry = newArry;             //修改新容器变量
                    arry[this.Count] = value;   //添加元素
                    count++;
                }
            }
            else//容器没有满
            {
                arry[this.Count] = value; //直接添加元素
                count++;
            }
        }
        ///////////////////////////////////////////////////////////////
        //方法实现索引获取容器中元素
        public int GetItem(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return arry[index];
            }
            else //索引超出
            {
                throw new Exception("索引超出了范围");
            }
        }
        /////////////////////////////////////////////////////////////////
        /////////////////////////索引器实现访问元素////////////////////////
        public int this[int index]
        {
            get //当用[]取值的时候调用
            {
                if (index >= 0 && index < this.Count)
                {
                    return arry[index];
                }
                else
                {
                    throw new Exception("索引超出了范围");
                }
            }
            set//当用[]设置值时调用
            {
                if (index >= 0 && index < this.Count)
                {
                    arry[index] = value;
                }
                else
                {
                    throw new Exception("索引超出了范围");
                }
            }
        }//索引器结束
        //////////////////////////////////////////////////
        ///插入元素方法
        public void Insert(int index, int value)
        {
            if (index >= 0 && index <= this.Count)//index是否合法
            {
                if (this.Count == this.Capacity) //判断容量是否满
                {
                    capacity += 5;
                    var newArry = new int[this.Capacity];      //创建新容器
                    Array.Copy(this.arry, newArry, this.Count);//将原容器拷贝到新容器
                    arry = newArry;//新容器赋值给新容器？？？？
                }
                //移动插入数据
                for (int i = this.Count - 1; i >= index; i--)//从最后向前拷贝
                {
                    arry[i + 1] = arry[i];//把i的值放在你后面就是向后移动一个单位      
                }
                arry[index] = value;
                count++;
            }
            else { throw new Exception("插入失败抛出异常"); }
        }
        //查询MyList的indexof第一次出现的位置
        public int IndexOf(int value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arry[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;//没找到返回-1
        }
        //查询MyList的LastIndexof最后一次出现的位置
        public int LastIndexOf(int value)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.arry[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;//没找到返回-1
        }
        //MyList的排序Sort
        public void Sort()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                for (int j = 0; j < this.Count - i - 1; j++)
                {
                    if (arry[j] > arry[j + 1])
                    {
                        arry[j] ^= arry[j + 1];
                        arry[j + 1] ^= arry[j];
                        arry[j] ^= arry[j + 1];
                    }
                }
            }
        }//结束排序
        //移除索引
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                for (int i = index + 1; i < this.Count; i++)
                {
                    arry[i - 1] = arry[i];
                }
                this.count--;
            }
            else
            {
                throw new Exception("移除索引超出了范围");
            }
        }

    }//类 end
}
