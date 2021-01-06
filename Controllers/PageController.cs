using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using InternshipsBookApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipsBookApp.Controllers
{
    public class PageController : Controller
    {
        private IBookDal _bookDal;
        private IPageDal _pageDal;
        private IHostingEnvironment _env;

        public PageController(IBookDal bookDal, IHostingEnvironment env, IPageDal pageDal)
        {
            _bookDal = bookDal;
            _env = env;
            _pageDal = pageDal;
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0)
            {
                return null;
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var path = Path.Combine(_env.WebRootPath, editor-images/img", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"{"/editor-images/img/"}{fileName}";

            return Json(new { uploaded = true, url });
        }

        public IActionResult Index(int bookId)
        {
            var bookToDetail = _bookDal.GetById(bookId);

            if (bookToDetail != null)
            {
                var model = new PageViewModel();
                model.BookId = bookToDetail.Id;
                model.Pages = bookToDetail.Pages.ToList();

                return View(model);
            }

            TempData["Message"] = "Lütfen geçerli bir defter seçiniz.";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public IActionResult Add(int bookId)
        {
            var bookToAdd = _bookDal.GetById(bookId);

            if (bookToAdd != null)
            {
                var model = new PageAddViewModel();
                model.BookId = bookToAdd.Id;

                return View(model);
            }

            TempData["Message"] = "Lütfen geçerli bir defter seçiniz";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public IActionResult Add(PageAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_pageDal.PageExist(model.Number, model.BookId))
                {
                    TempData["Message"] = "Sectiğiniz defterde bu sayfa numarası zaten kayıtlı.";
                    TempData["MessageState"] = "danger";

                    return RedirectToAction("Index", "Page", new {bookId = model.BookId });
                }

                else if (model.Number <= 0)
                {
                    TempData["Message"] = "Lütfen geçerli bir sayfa numarası giriniz.";
                    TempData["MessageState"] = "danger";

                    return RedirectToAction("Index", "Page", new { bookId = model.BookId });
                }

                var pageToAdd = new Page();
                pageToAdd.BookId = model.BookId;
                pageToAdd.Number = model.Number;
                pageToAdd.Subject = model.Subject;
                pageToAdd.PageContent = model.PageContent;

                _pageDal.Add(pageToAdd);
                TempData["Message"] = "Yeni sayfa başarıyla eklendi.";
                TempData["MessageState"] = "info";

                return RedirectToAction("Index", "Page", new { bookId = model.BookId });
            }

            TempData["Message"] = "Sayfa ekleme işlemi başarısız oldu";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index","Book");
        }

        [HttpGet]
        public IActionResult Update(int pageId)
        {
            var pageToUpdate = _pageDal.GetById(pageId);

            if (pageToUpdate != null)
            {
                var model = new PageUpdateViewModel();
                model.PageId = pageToUpdate.Id;
                model.BookId = pageToUpdate.BookId;
                model.Number = pageToUpdate.Number;
                model.Subject = pageToUpdate.Subject;
                model.PageContent = pageToUpdate.PageContent;
                
                return View(model);
            }

            TempData["Message"] = "Lütfen geçerli bir sayfa seçiniz.";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public IActionResult Update(PageUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pageToUpdate = _pageDal.GetById(model.PageId);

                if (pageToUpdate != null)
                {
                    // the number of the model to be updated == a page number already registered but their id's are different
                    var pageByNumber = _pageDal.GetPageByNumberAndBookId(model.Number, model.BookId);
                    if (pageByNumber != null && pageByNumber.Id != model.PageId)
                    {
                        TempData["Message"] = "Seçtiğiniz sayfa numarası zaten kayıtlı.";
                        TempData["MessageState"] = "danger";

                        return RedirectToAction("Index", "Page", new { bookId = model.BookId });
                    }

                    pageToUpdate.Number = model.Number;
                    pageToUpdate.Subject = model.Subject;
                    pageToUpdate.PageContent = model.PageContent;

                    _pageDal.Update(pageToUpdate);
                    TempData["Message"] = "Güncelleme işlemi başarıyla gerçekleşti";
                    TempData["MessageState"] = "info";

                    return RedirectToAction("Index", "Page", new { bookId = model.BookId });
                }
            }

            TempData["Message"] = "Güncelleme işlemi gerçekleştirilemedi";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }

        public IActionResult Delete(int pageId)
        {
            var pageToDelete = _pageDal.GetById(pageId);

            if (pageToDelete != null)
            {
                var bookId = pageToDelete.BookId;
                _pageDal.Delete(pageToDelete);

                TempData["Message"] = "Silme işlemi başarıyla gerçekleştirildi.";
                TempData["MessageState"] = "info";

                return RedirectToAction("Index", "Page", new { bookId = bookId });
            }

            TempData["Message"] = "Lütfen geçerli bir sayfa seçiniz.";
            TempData["MessageState"] = "danger";
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Examine(int pageId)
        {
            var pageToExamine = _pageDal.GetById(pageId);

            if (pageToExamine != null)
            {
                var model = new PageExamineViewModel();
                model.BookId = pageToExamine.BookId;
                model.Book = pageToExamine.Book;
                model.Number = pageToExamine.Number;
                model.Subject = pageToExamine.Subject;
                model.PageContent = pageToExamine.PageContent;
              
                return View(model);
            }

            TempData["Message"] = "Lütfen geçerli bir sayfa seçiniz.";
            TempData["MessageState"] = "danger";

            return RedirectToAction("Index", "Book");
        }
    }
}
