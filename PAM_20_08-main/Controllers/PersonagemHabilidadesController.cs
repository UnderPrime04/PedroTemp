using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

    [HttpPost]
    public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
    {
        try
        {
            Personagem personagem = await _context.Personagens
            .Include(p => p.Arma)
            .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
            .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

            if(personagem == null)
                throw new System.Exception("Personagem Não encotrado para o Id informado.");

            Habilidade habilidade = await _context.Habilidades
                                .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);
            if (habilidade == null)
                throw new System.Exception("Habilidade não encontrada.");

            PersonagemHabilidade ph = new PersonagemHabilidade();
            ph.Personagem = personagem;
            ph.Habilidade = habilidade;
            await _context.PersonagemHabilidades.AddAsync(ph);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);
        }   
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 

    [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades()
        {
            try
            {
                List<Habilidade> habilidades = await _context.Habilidades.ToListAsync();
                return Ok(habilidades);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePersonagemHabilidade")]
public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade personagemHabilidade)
{
    try
    {
        PersonagemHabilidade phToRemove = await _context.PersonagemHabilidades
            .FirstOrDefaultAsync(ph => ph.PersonagemId == personagemHabilidade.PersonagemId &&
                                       ph.HabilidadeId == personagemHabilidade.HabilidadeId);

        if (phToRemove == null)
            throw new System.Exception("Relação PersonagemHabilidade não encontrada.");

        _context.PersonagemHabilidades.Remove(phToRemove);
        int linhasAfetadas = await _context.SaveChangesAsync();

        return Ok(linhasAfetadas);
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message);
    }
}


    }
}