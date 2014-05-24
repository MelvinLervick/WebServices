using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
//using GolfEspData;

namespace GolfEspWS
{
    /// <summary>
    /// Summary description for gews
    /// </summary>
    [WebService(Namespace = "http://golfesp.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class gews : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            //var database = new AccessDatabase(ConfigurationManager.AppSettings["PROVIDER"], ConfigurationManager.AppSettings["DSN"]);
            //database.LoadAllTableData( "Courses" );
            //var courses = database.DbDataSet.Tables["Courses"];

            return "Test"; //courses.Rows[0]["Name"].ToString();
        }
    }
}
