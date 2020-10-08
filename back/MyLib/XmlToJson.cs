using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml;

namespace MyLib
{
    public class XmlToJson
    {
        public XmlDocument CreateXmlDocument(string str)
        {
            try
            {
                var document = new XmlDocument();

                XmlReaderSettings settings = new XmlReaderSettings
                {
                    IgnoreComments = true,
                    IgnoreWhitespace = true,
                    IgnoreProcessingInstructions = true
                };

                using var reader = XmlReader.Create(new StringReader(str), settings);
                document.Load(reader);

                XmlElement root = document.DocumentElement;
                root.RemoveAllAttributes();

                if (document.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                    document.RemoveChild(document.FirstChild);

                return document;
            }
            catch (Exception ex)
            {
                throw new MyLibraryException(ex.Message, ex);
            }
        }

        public string ConvertXmlToJson(string input)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(input))
                    throw new MyLibraryException("Please enter an XML string.");

                XmlDocument document = CreateXmlDocument(input);

                var json = JsonConvert.SerializeXmlNode(document);
                var jsonFormatted = JToken.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);
                
                return jsonFormatted;
            }
            catch (Exception ex)
            {
                throw new MyLibraryException(ex.Message, ex);
            }
        }
    }
}