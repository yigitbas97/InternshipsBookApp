using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using InternshipsBookApp.Models;
using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace InternshipsBookApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private IBookDal _bookDal;
        private IUserDal _userDal;
        private IHostingEnvironment _env;

        public BookController(IBookDal bookDal, IUserDal userDal, IHostingEnvironment env)
        {
            _bookDal = bookDal;
            _userDal = userDal;
            _env = env;
        }

        public int ReturnCurrentUserId()
        {
            var username = User.Identity.Name;
            var userId = _userDal.GetUserByUsername(username).Id;

            return userId;
        }

        public IActionResult Index()
        {
            var userId = ReturnCurrentUserId();

            var books = _bookDal.GetAllBooksWithUserAndPages()
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.DeliveryDate).ToList();

            var model = new BookViewModel { Books = books };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new BookAddViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BookAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = ReturnCurrentUserId();

                var book = new Book();
                book.InternshipPlace = model.InternshipPlace;
                book.Department = model.Department;
                book.DeliveryDate = model.DeliveryDate;
                book.UserId = userId;

                _bookDal.Add(book);

                TempData["Message"] = "Yeni defter başarıyla eklendi.";
                TempData["MessageState"] = "info";

                return RedirectToAction("Index", "Book");

            }

            TempData["Message"] = "Kayıt işlemi gerçekleştirilemedi.";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Add", "Book");
        }

        [HttpGet]
        public IActionResult Update(int bookId)
        {
            var bookToUpdate = _bookDal.GetById(bookId);

            if (bookToUpdate != null)
            {
                var model = new BookUpdateViewModel();
                model.BookId = bookToUpdate.Id;
                model.InternshipPlace = bookToUpdate.InternshipPlace;
                model.Department = bookToUpdate.Department;
                model.DeliveryDate = bookToUpdate.DeliveryDate;

                return View(model);
            }

            TempData["Message"] = "Lütfen geçerli bir defter seçiniz";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public IActionResult Update(BookUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bookToUpdate = _bookDal.GetById(model.BookId);

                if (bookToUpdate != null)
                {
                    bookToUpdate.InternshipPlace = model.InternshipPlace;
                    bookToUpdate.Department = model.Department;
                    bookToUpdate.DeliveryDate = model.DeliveryDate;

                    _bookDal.Update(bookToUpdate);

                    TempData["Message"] = "Güncelleme işlemi başarıyla gerçekleştirildi.";
                    TempData["MessageState"] = "info";

                    return RedirectToAction("Index", "Book");
                }
            }

            TempData["Message"] = "Güncelleme işlemi gerçekleştirilemedi.";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        public IActionResult Delete(int bookId)
        {
            var bookToDelete = _bookDal.GetById(bookId);

            if (bookToDelete != null)
            {
                _bookDal.Delete(bookToDelete);

                TempData["Message"] = "Silme işlemi başarıyla gerçekleştirildi.";
                TempData["MessageState"] = "info";

                return RedirectToAction("Index", "Book");
            }

            TempData["Message"] = "Silme işlemi gerçekleştirilemedi";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        public IActionResult CreatePdf(int bookId)
        {
            var book = _bookDal.GetById(bookId);

            if (book != null)
            {
                // Create Folder to Save pdfs files
                var path = _env.WebRootPath + "\\" + book.Id + "-" + book.InternshipPlace;
                CreateFolder(path);

                // Pdfs list to merge saved pdf files.
                var Renderer = new IronPdf.HtmlToPdf();
                var PDFs = new List<PdfDocument>();

                // Save all pages as pdf to folder.
                foreach (var page in book.Pages)
                {
                    page.PageContent = page.PageContent.Replace("/upload-images/img", _env.WebRootPath + "/upload-images/img");
                    PdfDocument PDF = Renderer.RenderHtmlAsPdf(page.PageContent);
                    var OutputPath = path + "\\" + page.Id + ".pdf";
                    PDF.SaveAs(OutputPath);
                }

                // Read all pdf files.
                DirectoryInfo d = new DirectoryInfo(path);
                foreach (var file in d.GetFiles("*.pdf"))
                {
                    PDFs.Add(PdfDocument.FromFile(path + "\\" + file.Name));
                }

                // Merge all pdf files and save a file.
                PdfDocument mergedPdf = PdfDocument.Merge(PDFs);
                mergedPdf.SaveAs(_env.WebRootPath + "\\" + "StajDefteri.pdf");

                //Delete temp folder to create pdf
                DeleteFolder(path);

                TempData["Message"] = "PDF başarıyla oluşturuldu";
                TempData["MessageState"] = "info";
                return RedirectToAction("Index", "Book");
            }

            TempData["Message"] = "Lütfen geçerli bir defter seçiniz.";
            TempData["MessageState"] = "danger";
            return RedirectToAction("Index", "Book");
        }

        public void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}
