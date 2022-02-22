using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using constructionM2M.Models;
using constructionM2M.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace constructionM2M.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _coms;
        public CompaniesController(CompaniesService coms)
        {
            _coms = coms;
        }

        // ANCHOR GETALL
        [HttpGet]
        public ActionResult<List<Company>> getAll()
        {
            try
            {
                return Ok(_coms.getAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GETBYID
        [HttpGet("{id}")]
        public ActionResult<Company> getById(int id)
        {
            try
            {
                return Ok(_coms.getById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR CREATE
        [Authorize]
        [HttpPost]
        public ActionResult<Company> create([FromBody] Company newCompany)
        {
            try
            {
                return Ok(_coms.create(newCompany));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _coms.remove(id);
                return Ok("Company Removed");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR EDIT
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> edit([FromBody] Company updated, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                updated.Id = id;
                return Ok(_coms.edit(updated));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}