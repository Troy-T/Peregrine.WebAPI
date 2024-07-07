using CRUDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        CollegeEntities OE = new CollegeEntities();
        // ..api/Students/
        public IQueryable<student> Get()
        {
            return OE.students;
        }
        // ../api/Students/1
        public student Get(int id)
        {
            student studentObj = OE.students.Find(id);
            return studentObj;
        }

        // ../api/department
        public void Put(int id, student studentObj)
        {
            OE.Entry(studentObj).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        // ../api/department
        public void Delete(int id)
        {
            student studentObj = OE.students.Find(id);
            OE.students.Remove(studentObj);
            OE.SaveChanges();
        }

        // ..api/Students/
        public void Post(student studentObj)
        {
            OE.students.Add(studentObj);
            OE.SaveChanges();
        }
    }
}
