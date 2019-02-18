using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LR_14
{
    public abstract class XML
    {
        public static void CreateXML()
        {
            XDocument xDocument = new XDocument();

            XElement firstBook = new XElement("book");
            XAttribute firstBookName = new XAttribute("name", "Flowers for Algernon");
            XElement firstBookAuthor = new XElement("author", "Daniel Keyes");
            XElement firstBookYear = new XElement("year", "1959");
            firstBook.Add(firstBookName, firstBookAuthor, firstBookYear);

            XElement secondBook = new XElement("book");
            XAttribute secondBookName = new XAttribute("name", "Telling Lies");
            XElement secondBookAuthor = new XElement("author", "Paul Ekman");
            XElement secondBookYear = new XElement("year", "1985");
            secondBook.Add(secondBookName, secondBookAuthor, secondBookYear);

            XElement books = new XElement("books");
            books.Add(firstBook, secondBook);
            xDocument.Add(books);
            xDocument.Save("Books.xml");
        }

        public static void LinqToXML()
        {
            XDocument xDocument = XDocument.Load("Books.xml");

            var books = xDocument.Element("books").Elements("book").Select(q => new
            {
                name = q.Attribute("name").Value, author = q.Element("author"), year = q.Element("year")
            });

            foreach (var x in books)
            {
                Console.WriteLine($"{x.name} --- {x.author.Value} --- {x.year.Value};");
            }
            Console.WriteLine();
        }

        public static void XPath()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("Books.xml");
            XmlElement xRoot = xmlDocument.DocumentElement;

            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);
            Console.WriteLine();

            childnodes = xRoot.SelectNodes("book");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            Console.WriteLine();

            XmlNode childnode = xRoot.SelectSingleNode("book[@name = 'Telling Lies']");
            Console.WriteLine(childnode.InnerText);
            Console.WriteLine();

            XmlNodeList authors = childnode.SelectNodes("//book/author");
            foreach (XmlNode n in authors)
                Console.WriteLine(n.InnerText);
            Console.WriteLine();

        }
    }
}
