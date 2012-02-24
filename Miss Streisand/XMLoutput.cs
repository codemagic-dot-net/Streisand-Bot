using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
/*
 * This is the XMLoutput class
* 
* (C) Marcel Flaig codemagic.net
* and 
* (c) Para
*/
namespace Barbara
{
    class XMLoutput
    {    
        
        public      static void read(string strXMLPath)
            {
      

      
            XmlTextReader textReader = new XmlTextReader(strXMLPath);

            textReader.Read();

            // If the node has value

            while (textReader.Read())
            {

                textReader.MoveToElement(); // Move to 1st element
                if (textReader.NodeType.ToString() != "Whitespace" && textReader.NodeType.ToString() != "Element" && textReader.NodeType.ToString() != "EndElement")
                {
                    Console.WriteLine("════════════════════════════════");


             //   Console.WriteLine("Name:" + textReader.Name); 
             //   Console.WriteLine("Base URI:" + textReader.BaseURI);
             //   Console.WriteLine("Local Name:" + textReader.LocalName);
             //   Console.WriteLine("Attribute Count:" + textReader.AttributeCount.ToString());
             //   Console.WriteLine("Depth:" + textReader.Depth.ToString());
             //   Console.WriteLine("Line Number:" + textReader.LineNumber.ToString());
             //   Console.WriteLine("Node Type:" + textReader.NodeType.ToString());

                    Console.WriteLine(textReader.Value.ToString());
             }

            }
            Console.Read();
    }        
            }
}
