using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Models;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AutorService _autorService;
        public AutorController(AutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        [Route("obtener")] //api/autor/obtener
        public IActionResult Obtener()
        {
            var resultado = _autorService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")] //api/autor/agregar
        public IActionResult Agregar([FromBody] Autor _autor)
        {
            var resultado = _autorService.AgregarAutor(_autor);
            if (resultado)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar")] //api/autor/editar
        public IActionResult Editar([FromBody] Autor _autor)
        {
            var resultado = _autorService.EditarAutor(_autor);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar/{autorID}")] // api/autor/eliminar/1
        
        public IActionResult Eliminar(int autorID)
        {
            var resultado = _autorService.EliminarAutor(autorID);
            if (resultado)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}
