using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Rehabilitation2.Models.Entity;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Rehabilitation2.Controllers
{
    public class ValuesController : ApiController
    {
        RehabilitationDbEntities1 db = new RehabilitationDbEntities1();
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-0FCA3JOQ;Initial Catalog=RehabilitationDb;Integrated Security=True");

        // GET api/values
        //public string Get()
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLSESSION", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return JsonConvert.SerializeObject(dt);
        //}

        public IEnumerable<TBLSESSION> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TBLSESSION;
        }


    }
}
