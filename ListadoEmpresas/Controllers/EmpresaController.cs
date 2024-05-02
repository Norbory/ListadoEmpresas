using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListadoEmpresas.Models;
using ListadoEmpresas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ListadoEmpresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        // Obtiene todas las empresas
        private readonly DataContext _context;
        public EmpresaController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> GetAllEmpresas()
        {
            try
            {
                var empresas = await _context.Empresas.ToListAsync();
                if (empresas == null)
                {
                    return NotFound();
                }
                empresas = empresas.OrderByDescending(x => x.FechaEdicion).ToList();
                return Ok(empresas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            } 
        }

        //GET: Ordenar empresas segun el campo seleccionado
        [HttpGet("ordenar/{campo}")]
        public async Task<ActionResult<List<Empresa>>> OrdenarEmpresas(string campo)
        {
            try
            {
                var empresas = await _context.Empresas.ToListAsync();
                if (empresas == null)
                {
                    return NotFound();
                }
                switch (campo)
                {
                    case "Razon":
                        empresas = empresas.OrderBy(x => x.Razon).ToList();
                        break;
                    case "NombreEmpresa":
                        empresas = empresas.OrderBy(x => x.NombreEmpresa).ToList();
                        break;
                    case "IdentificacionFiscal":
                        empresas = empresas.OrderBy(x => x.IdentificacionFiscal).ToList();
                        break;
                    case "NumeroTelefono":
                        empresas = empresas.OrderBy(x => x.NumeroTelefono).ToList();
                        break;
                    case "CorreoElectronico":
                        empresas = empresas.OrderBy(x => x.CorreoElectronico).ToList();
                        break;
                    case "SitioWeb":
                        empresas = empresas.OrderBy(x => x.SitioWeb).ToList();
                        break;
                    case "Direccion":
                        empresas = empresas.OrderBy(x => x.Direccion).ToList();
                        break;
                    case "Pais":
                        empresas = empresas.OrderBy(x => x.Pais).ToList();
                        break;
                    case "Facturacion":
                        empresas = empresas.OrderBy(x => x.Facturacion).ToList();
                        break;
                    case "FechaEdicion":
                        empresas = empresas.OrderByDescending(x => x.FechaEdicion).ToList();
                        break;
                    default:
                        return BadRequest();
                }
                return Ok(empresas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //GET: Buscar empresas por nombre
        // Proximamente se agregara la autenticacion con bearer token
        [HttpGet("buscar/{nombre}")]
        public async Task<ActionResult<List<Empresa>>> BuscarEmpresas(string nombre)
        {
            try
            {   
                var empresa = await _context.Empresas.FirstOrDefaultAsync(x => x.NombreEmpresa == nombre);
                if (empresa == null)
                {
                    return NotFound();
                }
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: obtener una empresa por id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Empresa>>> GetEmpresaById(int id)
        {
            try
            {
                var empresa = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
                if (empresa == null)
                {
                    return NotFound();
                }
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        // POST: api/Empresa
        // Proximamente se agregara la autenticacion con bearer token
        [HttpPost]
        public async Task<ActionResult<List<Empresa>>> CreateEmpresa(Empresa company)
        {
            try
            {
                _context.Empresas.Add(company);
                await _context.SaveChangesAsync();
                return Ok(await _context.Empresas.ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        // PUT: api/Empresa
        // Proximamente se agregara la autenticacion con bearer token
        [HttpPut]
        public async Task<ActionResult<List<Empresa>>> ActualizaEmpresa(Empresa company)
        {
            try
            {
                var DbEmpresa = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == company.Id);
                if (DbEmpresa == null)
                {
                    return NotFound();
                }
                DbEmpresa.Razon = company.Razon;
                DbEmpresa.NombreEmpresa = company.NombreEmpresa;
                DbEmpresa.IdentificacionFiscal = company.IdentificacionFiscal;
                DbEmpresa.NumeroTelefono = company.NumeroTelefono;
                DbEmpresa.CorreoElectronico = company.CorreoElectronico;
                DbEmpresa.SitioWeb = company.SitioWeb;
                DbEmpresa.Direccion = company.Direccion;
                DbEmpresa.Pais = company.Pais;
                DbEmpresa.Facturacion = company.Facturacion;
                DbEmpresa.FechaEdicion = company.FechaEdicion;

                await _context.SaveChangesAsync();
                return Ok(await _context.Empresas.ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        // DELETE: api/Empresa
        // Proximamente se agregara la autenticacion con bearer token
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Empresa>>> DeleteEmpresa(int id)
        {
            try
            {
                var empresa = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
                if (empresa == null)
                {
                    return NotFound();
                }
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
                return Ok(await _context.Empresas.ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
    }
}
