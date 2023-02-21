﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public TemasController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/Temas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetTemas()
        {
            return await _context.Temas.ToListAsync();
        }

        // GET: api/Temas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetTema(int id)
        {
            var tema = await _context.Temas.FindAsync(id);

            if (tema == null)
            {
                return NotFound();
            }

            return tema;
        }

        // PUT: api/Temas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTema(int id, Tema tema)
        {
            if (id != tema.Id)
            {
                return BadRequest();
            }

            _context.Entry(tema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Temas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tema>> PostTema(Tema tema)
        {
            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTema", new { id = tema.Id }, tema);
        }

        // DELETE: api/Temas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTema(int id)
        {
            var tema = await _context.Temas.FindAsync(id);
            if (tema == null)
            {
                return NotFound();
            }

            _context.Temas.Remove(tema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemaExists(int id)
        {
            return _context.Temas.Any(e => e.Id == id);
        }
    }
}
