using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly DataContext _context;   
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            // var Ogrenciler = await _context.Ogrenciler.ToListAsync(); //**
            return View(await _context.Ogrenciler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model) //async= asekron her müşteriyi karşılar işlemin hazırlanmasını bekler müşteri sekron ise bir müşteriyi karşılar o müşterinin işi hallolana kadar devam etmez
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync(); //bu kısımları detaylıca araştır**
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            // var ogr = await _context.Ogrenciler.FindAsync(id);
            var ogr = await _context.Ogrenciler.Include(o => o.KursKayitlari).ThenInclude(o=>o.Kurs).FirstOrDefaultAsync(o=>o.OgrenciId == id);

            if (ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //güvenlik anahtar açığını kapatıyor
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if (id != model.OgrenciId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (Ogrenci == null)
            {
                return NotFound();
            }
            return View(Ogrenci);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var Ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (Ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(Ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}