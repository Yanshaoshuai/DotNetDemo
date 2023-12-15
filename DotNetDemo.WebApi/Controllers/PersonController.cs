using DotNetDemo.WebApi.DAO;
using DotNetDemo.WebApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotNetDemo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController
    {
        private MysqlEfContext _context;
        public PersonController(MysqlEfContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getPersons")]
        public JsonResult getPersons()
        {
            string connectionStr = "Data Source=localhost;Database=test; UserId=root; PWD=123456;";
            string cmdText = "select * from person";
            DataTable dataTable = MySqlHelper.GetDataTable(connectionStr, CommandType.Text, cmdText);
            List<Person> people = ModelTool.DataTableToModels<Person>(dataTable);
            return new JsonResult(people);
        }

        [HttpGet]
        [Route("getPersonsWithEf")]
        public JsonResult getPersonsWithEf()
        {
            _context.person.Add(new Person() { Id = 100, Email = "1446999156@qq.com" });
            _context.SaveChanges();
            //List<Person> people = _context.person.ToList();
            //linq表达式写法
            IQueryable<Person> peopleResult = from people in _context.person
                                              select people;
            return new JsonResult(peopleResult);
        }
    }
}
