using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sliders = _context.Sliders.ToList();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string sub)
        {
            Slider slider = new()
            {
                Description = sub,
                Title = title,
                PhotoUrl = "asd"
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if(slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpPost]
        public IActionResult Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(int id, Slider slider)
        {
            var slide = _context.Sliders.FirstOrDefault(x => x.Id == id);

            slide.Title = slider.Title;
            slide.Description = slider.Description;
            _context.Sliders.Update(slide);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
