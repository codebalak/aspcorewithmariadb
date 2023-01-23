using aspcoremariadb.Models;
using Microsoft.AspNetCore.Mvc;
using aspcoremariadb.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace aspcoremariadb.Controllers
{
    public class DemoController : Controller
    {
        string connStr;
        //string connStr = "server=127.0.0.1;user=root;database=studentdb;port=3306;password=12345;";

            /*public IActionResult IsAuthenticated()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))

            {
               return  RedirectToAction("SignIn", "Authentication");
            }

        }*/


        
        public IActionResult AddBook()
        {
              if(string.IsNullOrEmpty(HttpContext.Session.GetString("username")))

            {
                return RedirectToAction("SignIn","Authentication");
            }

            DemoCrudRepo d = new DemoCrudRepo();

            /* DBConfig d = new DBConfig();
            connStr  = d.GetConnecttionString();
             List<Book> list = new List<Book>();
             using (MySqlConnection conn = new MySqlConnection(connStr))
             {
                 conn.Open();
                 // Perform database operations

                 MySqlCommand cmd = new MySqlCommand("select * from book ", conn);

                 using (var reader = cmd.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         list.Add(new Book()
                         {
                             Id = Convert.ToInt32(reader["Id"]),
                             Title = reader["title"].ToString(),
                             Author = reader["author"].ToString()

                         });
                     }

                     conn.Close();
                 }

 */

            List<Book> list = new List<Book>();
            ViewBag.list = d.GetAllDetails();
                return View();
            }


        public IActionResult NewBook() 

        {
            return View();           
        }

        [HttpPost]
        public IActionResult  NewBook(Book book)
        {   
            if(!ModelState.IsValid)
            {
                return View();
            }
            DemoCrudRepo d = new DemoCrudRepo();
            d.AddBooks(book);
            return RedirectToAction("AddBook");
        }

        public IActionResult EditBook(int id)
        {
            //Book booklist = new Book();
            DemoCrudRepo d = new DemoCrudRepo();
            List<Book> list = new List<Book>();
            list = d.GetSingleBook(id);
            
               Book booklist = new Book()
                {
                    Id = Convert.ToInt32(list[0].Id),
                    Title = list[0].Title.ToString(),
                    Author = list[0].Author.ToString(),
                    Description = list[0].Description.ToString()

                };
           
           /* if (list == null)
            {
                TempData["msg"] = "Book not found";
                return RedirectToAction("AddBook");
            }*/


            return View(booklist);
        }


        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            DemoCrudRepo d = new DemoCrudRepo();
            d.UpdateBook(book);
            return RedirectToAction("AddBook");
        }


        //delete book

                    public IActionResult DeleteBook(int id)
        {
            DemoCrudRepo d = new DemoCrudRepo();
                    if(d.Destroy(id))
            {
                TempData["msg"] = "Book Removed Successfully";
            }
                
            return RedirectToAction("AddBook");
;
        }


    }

                

    }
