using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MontApi.Models;

namespace MontApi.Controllers
{
    public class SampleController : ApiController
    {
        montEntities db;

        public SampleController()
        {
            db = new montEntities();
        }

        [HttpGet]
        [Route("api/test")]
        public List<crteapi> Getall()
        {
            List<crteapi> lst = db.crteapis.ToList();
            return lst;
        }

        [HttpGet]
        [Route("api/test/{id}")]

        public crteapi GetByID(int id)
        {
            crteapi ca = db.crteapis.Find(id);
            return ca; ;
        }

        [HttpPost]
        [Route("api/test")]
        public string AddStudent(crteapi ca)
        {
            db.crteapis.Add(ca);
            db.SaveChanges();
            return "Data Addedd Successfully";
        }

        [HttpPut]
        [Route("api/test")]

        public string UpdateStudent(crteapi ca)
        {
            db.Entry<crteapi>(ca).State = EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully";
        }

        [HttpDelete]
        [Route("api/test/{id}")]

        public string DeleteStudent(int id)
        {
            crteapi ca = db.crteapis.Find(id);
            db.crteapis.Remove(ca);
            db.SaveChanges();
            return "Studen Deleted Successfully";
        }
    }
}
