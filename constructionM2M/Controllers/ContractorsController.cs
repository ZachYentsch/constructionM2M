
using System.Collections.Generic;
using constructionM2M.Models;
using constructionM2M.Services;
using Microsoft.AspNetCore.Mvc;

namespace constructionM2M.Controllers
{
    [ApiController]
    [Route("api/[Controller")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cons;
        public ContractorsController(ContractorsService cons)
        {
            _cons = cons;
        }

        // ANCHOR GET ALL
        [HttpGet]
        public ActionResult<List<Contractor>> getAll()
        {
            try
            {
                return Ok(_cons.getAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Contractor> getById(int id)
        {
            try
            {
                return Ok(_cons.getById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR CREATE
        [HttpPost]
        public ActionResult<Contractor> create([FromBody] Contractor newContractor)
        {
            try
            {
                return Ok(_cons.create(newContractor));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> remove(int id)
        {
            try
            {
                _cons.remove(id);
                return Ok("Contractor Removed");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ANCHOR EDIT
        [HttpPut("{id}")]
        public ActionResult<Contractor> edit([FromBody] Contractor updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_cons.edit(updated));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}