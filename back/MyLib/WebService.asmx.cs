using System;
using System.Threading;
using System.Web.Services;

namespace MyLib
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string XmlToJson(string input)
        {
            Thread.Sleep(2000);
            string result;

            try
            {
                var xmlToJson = new XmlToJson();
                result = xmlToJson.ConvertXmlToJson(input);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        [WebMethod]
        public dynamic Fibonnaci(string input)
        {
            Thread.Sleep(2000);
            dynamic result;

            try
            {
                var fibonacci = new Fibonacci();
                result = fibonacci.ComputeSequences(input);
            }
            catch (Exception ex)
            {
               result = ex.Message;
            }

            return result;
        }
    }
}
