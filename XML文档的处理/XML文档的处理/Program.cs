using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML文档的处理
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.XmlWrite();
            Console.WriteLine("****************************************");
            Program.XmlAppand();
            Console.ReadKey();
        }
        #region XML文档的写入方法
        //XML文档的写入方法
        public static void XmlWrite()
        {
            //1、导入命名空间  using System.Xml;
            //2、创建XML对象
            XmlDocument xmlDoc = new XmlDocument();
            //3、创建第一行的文档信息并且添加到xmlDoc文档中
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //将第一行信息添加到文档中
            xmlDoc.AppendChild(xmlDec);
            //4、创建根节点
            XmlElement books = xmlDoc.CreateElement("Books");
            //将根节点添加到文档中
            xmlDoc.AppendChild(books);
            //******************以下为创建子节点*********************//
            //5、给根节点books创建子节点book1
            XmlElement book1 = xmlDoc.CreateElement("Book");
            //将子节点添加到根节点下
            books.AppendChild(book1);
            //6、给子节点book1添加孙子节点
            XmlElement name1 = xmlDoc.CreateElement("Name");
            name1.InnerText = "读书破万卷";
            book1.AppendChild(name1);
            XmlElement price1 = xmlDoc.CreateElement("Price");
            price1.InnerText = "18";
            book1.AppendChild(price1);
            XmlElement des1 = xmlDoc.CreateElement("Des");
            des1.InnerText = "行万里路，读万卷书";
            book1.AppendChild(des1);
            ////////////////////////////////////////////////
            //给根节点books创建子节点book2
            XmlElement book2 = xmlDoc.CreateElement("Book");
            //将子节点添加到根节点下
            books.AppendChild(book2);
            //给子节点book2创建孙子节点
            XmlElement name2 = xmlDoc.CreateElement("Name");
            name2.InnerText = "资治通鉴";
            book2.AppendChild(name2);
            XmlElement price2 = xmlDoc.CreateElement("Price");
            price2.InnerText = "20";
            book2.AppendChild(price2);
            XmlElement des2 = xmlDoc.CreateElement("Des");
            des2.InnerText = "以史为镜";
            book2.AppendChild(des2);
            //添加属性节点方法如下
            XmlElement itme = xmlDoc.CreateElement("Item");
            itme.SetAttribute("Name", "HelloWorld");
            itme.SetAttribute("Count", "10");
            book2.AppendChild(itme);
            //添加一个标签的方法
            XmlElement flag = xmlDoc.CreateElement("Flag");
            flag.InnerXml = "<p>这是一个标签</p>";
            book2.AppendChild(flag);
            //保存
            xmlDoc.Save("Books.xml");
            Console.WriteLine("保存成功");
        }//XmlWrite end
        #endregion
        #region XML文档的追加写入方法
        public static void XmlAppand()
        {
            //XML文件追加的方法
            XmlDocument doc = new XmlDocument();
            if (File.Exists("NewBooks.xml"))
            {
                //如果文件存在加载文件
                doc.Load("NewBooks.xml");
                //获取文件的根节点
                XmlElement books = doc.DocumentElement;
                //*************然后写入
            }
            else
            {
                //如果文件不存在创建第一行
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(dec);
                //创建根节点
                XmlElement books = doc.CreateElement("Book");
                doc.AppendChild(books);
                // 根节点下创建子节点book1
                XmlElement book1 = doc.CreateElement("Book");
                books.AppendChild(book1);
                //给子节点创建孙子节点
                XmlElement name1 = doc.CreateElement("Name");
                name1.InnerText = "三国演义";
                book1.AppendChild(name1);
                XmlElement number1 = doc.CreateElement("Number");
                number1.InnerText = "110";
                book1.AppendChild(number1);
                XmlElement des1 = doc.CreateElement("Des");
                des1.SetAttribute("作者", "罗贯中");
                des1.SetAttribute("年代", "不详");
                book1.AppendChild(des1);
                //************************************************
                //根节点下创建子节点book2
                XmlElement book2 = doc.CreateElement("Book");
                books.AppendChild(book2);
                //给子节点创建孙子节点
                XmlElement name2 = doc.CreateElement("Name");
                name2.InnerText = "红楼梦";
                book2.AppendChild(name2);
                XmlElement number2 = doc.CreateElement("Number");
                number2.InnerText = "210";
                book2.AppendChild(number2);
                XmlElement des2 = doc.CreateElement("Des");
                des2.SetAttribute("作者", "曹雪芹");
                des2.SetAttribute("年代", "清");
                des2.SetAttribute("内容", "君子之泽，五世而斩");
                book2.AppendChild(des2);
                doc.Save("NewBooks.xml");
                Console.WriteLine("追加保存成功");
            }//Xml Appand() end
            #endregion
        }
    }

}
