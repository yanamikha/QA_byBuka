using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QA_byBuka.Models;
namespace QA_byBuka.Controllers
{
    public class HomeController : Controller
    {
        IProblemRepository repo;
        public HomeController(IProblemRepository r)
        {
            repo = r;             
        }

        public IActionResult Index()
        {
            return View(repo.GetAllProblems());
        }
        public ActionResult Details(int id)
        {
            AnswerRepository answer = new AnswerRepository(Startup.connectionString);
            IEnumerable<Answer> answers;
            answers = answer.GetAllAnswers(id);
            if (answer != null)
                return View(answers);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Problem problem)
        {
            repo.Create(problem);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Problem problem = repo.Get(id);
            if (problem != null)
                return View(problem);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Problem problem)
        {
            repo.Update(problem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Problem problem = repo.Get(id);
            if (problem != null)
                return View(problem);
            return NotFound();
        }
        [HttpGet]
        [ActionName("AllMyProblems")]
        public ActionResult AllMyProblems(int id)
        {
            return View(repo.GetAllMyProblems(id));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}