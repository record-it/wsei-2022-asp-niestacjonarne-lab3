using crud_app_lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_app_lab3.Controllers
{
    public class BookController : Controller
    {
        public static Dictionary<int, Book> books = new Dictionary<int, Book>
        {
            { 1, new Book(){ Id = 1, Author = "AAAAA", Title ="BBBB", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 2, new Book(){ Id = 2, Author = "CCCCC", Title ="DDDD", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 3, new Book(){ Id = 3, Author = "NNNNN", Title ="BBBB", IsAvailable = true, CreatedDate = DateTime.Now} },
            { 4, new Book(){ Id = 4, Author = "YYYYY", Title ="GGGG", IsAvailable = false, CreatedDate = DateTime.Now} }
        };
        public static int counter = 4;
        public IActionResult Index()
        {
            return View(books);
        }
        //TODO zaprojektu formularz do edycji z polami Title i Author
        //TODO w formularz kieruj dane do akcji Edit (metoda post)
        //TODO w akcji Edit zamień tylko tytuł i autora ksiązki
        public IActionResult EditForm([FromRoute] int id)
        {
            return View();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            books.Remove(id);
            return View("Index", books);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Book bookFromForm)
        {
            if (ModelState.IsValid)
            {
                books[++counter] = bookFromForm;
                return View("Index", books);
            }
            return View("CreateForm");
            //TODO odebranie danych z formularza, zapianie obiektu do books
            
        }    
    }
}
