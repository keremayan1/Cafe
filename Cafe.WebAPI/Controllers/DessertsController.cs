using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cafe.Business.Abstract;
using Cafe.Entities.Concrete;

namespace Cafe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private IDessertService _dessertService;

        public DessertsController(IDessertService dessertService)
        {
            _dessertService = dessertService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dessertService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _dessertService.GetByDessertId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Dessert dessert)
        {
            var result = _dessertService.Add(dessert);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Dessert dessert)
        {
            var result = _dessertService.Delete(dessert);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Dessert dessert)
        {
            var result = _dessertService.Update(dessert);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
