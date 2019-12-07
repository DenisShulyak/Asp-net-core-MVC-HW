using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHomeWork.DataAccess;
using MVCHomeWork.Models;

namespace MVCHomeWork.Areas.Portfolios
{
    [Area("Portfolios")]
    public class PortfoliosController : Controller
    {
        private readonly PortfolioContext _context;

        private IHostingEnvironment _appEnvironment;
        public PortfoliosController(PortfolioContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Portfolios/Portfolios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Portfolios.ToListAsync());
        }

        // GET: Portfolios/Portfolios/Details/5

        // GET: Portfolios/Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioViewModel pvm)
        {
            Portfolio portfolio = new Portfolio { AboutWork = pvm.AboutWork, InfoAboutMe = pvm.InfoAboutMe, InfoAboutStudy = pvm.InfoAboutStudy, Achievement = pvm.Achievement };
            if (pvm.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Image.Length);
                }
                // установка массива байтов
                portfolio.Image = imageData;
            }



            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();



            if (pvm.Image != null)
            {
                // путь к папке Files
                string path = "/img/" + portfolio.Id + ".png";
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    pvm.Image.CopyTo(fileStream);
                }
                FileModel file = new FileModel { Name = pvm.Image.FileName, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }


            return RedirectToAction("Create");
        }

        

        private bool PortfolioExists(Guid id)
        {
            return _context.Portfolios.Any(e => e.Id == id);
        }
    }
}
