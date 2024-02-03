using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML文档的读取
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.XmlAnalyze();
            Console.WriteLine("*****************************");
            Program.XMLAnalyzeP();
            Console.WriteLine("*****************************");
            Program.DeleXmlNode();
            Console.ReadKey();
        }
        public static void XmlAnalyze()
        {
            //1、XmlDocument是专门用来解析XML文档的
            XmlDocument doc = new XmlDocument();
            //2、加载要解析的XML文档
            doc.Load("Books.xml");
            //3、获取根节点（XmlNode代表一个节点）
            XmlElement books = doc.DocumentElement;           
            //4、获得根节点下面节点的子节点的集合
            XmlNodeList xnl = books.ChildNodes;//获取当前节点下面的所有子节点,返回节点集合
            //变量子节点
            foreach (XmlNode itme in xnl)
            {
                Console.WriteLine(itme.InnerText);
            }         
        }
        /// /////////////////////////////////////////////////////
        //读取属性节点的值方法
        public static void XMLAnalyzeP()
        {
            //1、XmlDocument是专门用来解析XML文档的
            XmlDocument doc = new XmlDocument();
            //2、加载要解析的XML文档
            doc.Load("Books.xml");
            //xpath
            XmlNodeList xnl = doc.SelectNodes("Books/Book/Item");
            foreach (XmlNode itme in xnl)
            {
                Console.WriteLine(itme.Attributes["Name"].Value);
                Console.WriteLine(itme.Attributes["Count"].Value);
            }
        }
        //删除节点
        public static void DeleXmlNode()
        {
            //1、XmlDocument是专门用来解析XML文档的
            XmlDocument doc = new XmlDocument();
            //2、加载要解析的XML文档
            doc.Load("DeleXml.xml");
            //xpath
            XmlNode xnl = doc.SelectSingleNode("Books/Book/Item");
            xnl.RemoveAll();
            doc.Save("DeleXml.xml");
            Console.WriteLine("删除成功");
        }
    }
}
