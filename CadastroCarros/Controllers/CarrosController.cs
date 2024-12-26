using CadastroCarros.Data;
using CadastroCarros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly AppDbContext _context;

        public CarrosController(AppDbContext context)
        {
            _context = context;
        }

        //Exibindo todos os resultados
        public async Task<IActionResult> Index()
        {
            var carros = await _context.Carro.ToListAsync();
            return View(carros);
        }

        // GET:Carros/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if ( _context.Carro == null )
            {
                return NotFound();
            }

            var carro = await _context.Carro.FirstOrDefaultAsync();

            if ( carro == null )
            {
                return NotFound();
            }

            return View(carro);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Cor,dataFabricacao,anoFabricacao,Vendido")]Carro carro)
        {
            if( ModelState.IsValid )
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        [Route("editar/{id:int}")]
        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if( _context.Carro == null )
            {
                return NotFound();
            }
            var carro = await _context.Carro.FindAsync(id);
            if( carro == null )
            {
                return NotFound();
            }
            return View(carro);
        }

        [HttpPost("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Cor,dataFabricacao,anoFabricacao,Vendido")]Carro carro) 
        { 
            if( id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid )
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
                    {
                        return NotFound();
                    }
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
                return View(carro);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FirstOrDefaultAsync(c => c.Id == id);
            if ( carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if ( carro != null )
            {
                _context.Carro.Remove(carro);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}
