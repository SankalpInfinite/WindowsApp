using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment_API.Models;

namespace Assignment_API.Controllers
{
    public class CountryCaptialController : ApiController
    {
        static List<Country> ct = new List<Country>()
        {
            new Country{ID=1,CountryName="India",Captail="New Delhi"},
            new Country{ID=2,CountryName="Russia",Captail="Moscow"},
            new Country{ID=3,CountryName="Nepal",Captail="Kathmandu"},
            new Country{ID=4,CountryName="France",Captail="Paris"},
            new Country{ID=5,CountryName="Bhutan",Captail="Thimphu"},
            new Country{ID=6,CountryName="Bangladesh",Captail="Dhaka"},
            new Country{ID=7,CountryName="Afghanistan",Captail="Kabul"},

        };
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ct);
            return response;
        }

        public HttpResponseMessage GetId(int id)
        {
            var country = ct.Find(c => c.ID == id);
            if (country != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, country);
                return response;
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public IHttpActionResult Post([FromBody] Country c)
        {
            ct.Add(c);
            return Ok(ct);
        }
        public IHttpActionResult Update(int id, [FromUri] Country c)
        {
            var count = ct.Find(a => a.ID == id);
            if (count != null)
            {
                ct[id - 1].CountryName = c.CountryName;
                ct[id - 1].Captail = c.Captail;
                return Ok(ct);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int id)
        {
            var count = ct.Find(c => c.ID == id);
            if (count != null) {
                ct.RemoveAt(id - 1);
                return Ok(ct);
            }
            return NotFound();
            
        }
    }
}
