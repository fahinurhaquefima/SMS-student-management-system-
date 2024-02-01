using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.DatabaseContest;
using SMS.WebApp.Models;

namespace SMS.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContest _dbContest;

        public StudentController(ApplicationDbContest dbContest)
        {
            _dbContest = dbContest;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var data = await _dbContest.Set<Student>().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                var data = await _dbContest.Set<Student>().FindAsync(id);
                return View(data);
            }

        }
        [HttpPost]
        public async Task<IActionResult>CreateOrEdit(int id,Student student)
        {
            if (id == 0)
            {
                if(ModelState.IsValid)
                {
                    await _dbContest.Set<Student>().AddAsync(student);
                    await _dbContest.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                _dbContest.Set<Student>().Update(student);
                _dbContest.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(new Student());
        }

        public async Task<IActionResult>Delete(int id)
        {
            if (id != 0)
            {
                var data = await _dbContest.Set<Student>().FindAsync(id);
                if(data is not null)
                {
                    _dbContest.Set<Student>().Remove(data);
                    await _dbContest.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
                 
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deatils(int id)
        {
            var data = await _dbContest.Set<Student>().FindAsync(id);
            return View(data);
        }
           
    }
}
