using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Employee_Mg_Angular.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Mg_Angular.Controllers
{
    //[Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        DepartmentDataAccessLayer objdep = new DepartmentDataAccessLayer();
        // GET: api/<controller>


        [HttpGet("[action]")]
        [Route("api/Department/Index")]
        public IEnumerable<DepartmentMaster1> Index()
        {
            return objdep.GetAllDepartment();
        }

        [HttpPost]
        [Route("api/Department/Create")]
        public int Create([FromBody] DepartmentMaster1 department)
        {
            return objdep.AddDepartment(department);
        }

        [HttpGet]
        [Route("api/Department/Details/{id}")]
        public DepartmentMaster1 Details(int id)
        {
            return objdep.GetdDepartmentData(id);
        }

        [HttpPut]
        [Route("api/Department/Edit")]
        public int Edit([FromBody]DepartmentMaster1 department)
        {
            return objdep.UpdatedDepartment(department);
        }

        [HttpDelete]
        [Route("api/Department/Delete/{id}")]
        public int Delete(int id)
        {
            return objdep.DeletedDepartment(id);
        }

    }
}
