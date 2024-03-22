using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class OgretmenController : Controller
    {
            private readonly DataContext _context;
            public OgretmenController(DataContext context) 
            {
                _context = context;
            }
            public async Task<ActionResult> Index()
        {
            // var Ogrenciler = await _context.Ogrenciler.ToListAsync(); //**
            return View(await _context.Ogretmenler.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model) //async= asekron her müşteriyi karşılar işlemin hazırlanmasını bekler müşteri sekron ise bir müşteriyi karşılar o müşterinin işi hallolana kadar devam etmez
        {
            _context.Ogretmenler.Add(model);
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
            var entity = await _context.Ogretmenler.FirstOrDefaultAsync(o => o.OgretmenId == id);
            

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //güvenlik anahtar açığını kapatıyor
        public async Task<IActionResult> Edit(int id, Ogretmen model)
        {
            if (id != model.OgretmenId)
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
                    if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
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
    }
}