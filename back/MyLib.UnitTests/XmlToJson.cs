using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLib.UnitTests
{
    [TestClass]
    public class XmlToJsonTests
    {
        private static readonly XmlToJson xmlToJson = new XmlToJson();

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void ConvertXmlToJson_EmptyString_ThrowsAnException()
        {
            xmlToJson.ConvertXmlToJson("");
        }

        [TestMethod]
        public void ConvertXmlToJson_XmlStringGoodFormat_ConvertXmlStringToJsonFormat()
        {
            var xml = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
            var result = xmlToJson.ConvertXmlToJson(xml);
           
            Assert.IsTrue(result.StartsWith("{"));
            Assert.IsTrue(result.EndsWith("}"));
        }

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void CreateXmlDocument_XmlStringMissingClosedTag_ThrowsAnException()
        {
            var xml = "<HPAY><EXTRA><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL>";
            xmlToJson.CreateXmlDocument(xml);
        }

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void CreateXmlDocument_XmlStringWIthWeirdCharacters_ThrowsAnException()
        {
            var xml = "<(HPAY><EXTRA><AUTH>031183</AUTH></EXTRA><INT_MSGV/><MLABEL>501767XXXXXX6700</MLABEL)>";
            xmlToJson.CreateXmlDocument(xml);
        }

        [TestMethod]
        public void CreateXmlDocument_XmlStringContaningXmlDeclaration_ShouldReturnXmlDocumentWithoutXmlDeclaration()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><note date=\"12/11/2007\"><to>Tove</to><from>Jani</from></note>";
            var result = xmlToJson.CreateXmlDocument(xml);
            var outerXml = result.OuterXml;
           
            Assert.IsTrue(outerXml.StartsWith("<"));
            Assert.IsTrue(outerXml.EndsWith(">"));
            Assert.IsFalse(outerXml.Contains("?xml version"));
        }

        [TestMethod]
        public void CreateXmlDocument_XmlStringContaningWhiteSpace_ShouldReturnXmlDocumentByIgnoringWhiteSpace()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><note date=\"12/11/2007\">  <to>Tove</to>  <from>Jani</from></note>";
            var result = xmlToJson.CreateXmlDocument(xml);
            var outerXml = result.OuterXml;

            Assert.IsTrue(outerXml.StartsWith("<"));
            Assert.IsTrue(outerXml.EndsWith(">"));
            Assert.IsFalse(outerXml.Contains(" "));
        }

        [TestMethod]
        public void CreateXmlDocument_XmlContaningAttributes_ShouldReturnXmlDocumentWithoutAttributes()
        {
            var xml = "<TRANS attribute=\"attribute_name\"><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
            var result = xmlToJson.CreateXmlDocument(xml);
            var outerXml = result.OuterXml;

            Assert.IsTrue(outerXml.StartsWith("<"));
            Assert.IsTrue(outerXml.EndsWith(">"));
            Assert.IsFalse(outerXml.Contains("@"));
            Assert.IsFalse(outerXml.Contains("attribute"));
        }

        [TestMethod]
        public void CreateXmlDocument_XmlStringGoodFormat_ShouldReturnXmlDocument()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
            var result = xmlToJson.CreateXmlDocument(xml);
            var outerXml = result.OuterXml;

            Assert.IsTrue(outerXml.StartsWith("<"));
            Assert.IsTrue(outerXml.EndsWith(">"));
        }
    }
}
