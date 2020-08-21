using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudSistema.Data;
using CrudSistema.Models;

namespace SistemaLocacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private readonly ClienteContext _context;

        public LocacaosController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/Locacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacoes()
        {
            return await _context.Locacoes.ToListAsync();
        }

        // GET: api/Locacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        // PUT: api/Locacaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(int id, Locacao locacao)
        {
            //var LocacoesAdd = await _context.Locacoes
            //    .FirstOrDefaultAsync(l => l.IdLocacao == locacao.IdLocacao);

            if (id != locacao.IdLocacao)
            {
                return BadRequest();
            }

            _context.Entry(locacao).State = EntityState.Modified;

            try
            {
                if (locacao.DataEntrega.Date <= locacao.DataDevolucao.Date)
                {
                    return Content("Entregou na data certa");
                }
                else
                {
                    return Content("Entregou atrazado");
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacaos
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {

            var LocacoesAdd = await _context.Locacoes
                .FirstOrDefaultAsync(l => l.IdLocacao == locacao.IdLocacao);

            if (LocacoesAdd == null)
            {
                locacao.DataLocacao = DateTime.Now;
                _context.Locacoes.Add(locacao);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocacao", new { id = locacao.IdLocacao }, locacao);
            }
            else
            {
                    return Content("Filme não disponível para a locação");
            }

           // _context.Locacoes.Add(locacao);
          //  await _context.SaveChangesAsync();

          //  return CreatedAtAction("GetLocacao", new { id = locacao.IdLocacao }, locacao);
        }


        private bool LocacaoExists(int id)
        {
            return _context.Locacoes.Any(e => e.IdLocacao == id);
        }
    }
}
