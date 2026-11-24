using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Api.Data;
using CarRental.Api.Dto;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutosController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsValidYear(int year)
        {
            int currentYear = DateTime.Now.Year;
            return year >= currentYear - 5;
        }

        private AutoDto ToDto(Auto auto) => new AutoDto
        {
            Id = auto.Id,
            Marca = auto.Marca,
            Modelo = auto.Modelo,
            Precio = auto.Precio,
            Year = auto.Year
        };

        private Auto ToEntity(AutoDto dto) => new Auto
        {
            Id = dto.Id,
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Precio = dto.Precio,
            Year = dto.Year
        };

        // GET: api/autos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoDto>>> GetAutos()
        {
            var autos = await _context.Autos.ToListAsync();
            return autos.Select(ToDto).ToList();
        }

        // GET: api/autos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoDto>> GetAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
                return NotFound();

            return ToDto(auto);
        }

        // POST: api/autos
        [HttpPost]
        public async Task<ActionResult<AutoDto>> CreateAuto(AutoDto autoDto)
        {
            if (!IsValidYear(autoDto.Year))
                return BadRequest("El auto no puede tener más de 5 años de antigüedad.");

            var auto = ToEntity(autoDto);
            auto.Id = 0;

            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            autoDto.Id = auto.Id;

            return CreatedAtAction(
                nameof(GetAuto),
                new { id = auto.Id },
                autoDto
            );
        }

        // PUT: api/autos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuto(int id, AutoDto autoDto)
        {
            if (id != autoDto.Id)
                return BadRequest();

            if (!IsValidYear(autoDto.Year))
                return BadRequest("El auto no puede tener más de 5 años de antigüedad.");

            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
                return NotFound();

            auto.Marca = autoDto.Marca;
            auto.Modelo = autoDto.Modelo;
            auto.Precio = autoDto.Precio;
            auto.Year = autoDto.Year;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/autos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
                return NotFound();

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}