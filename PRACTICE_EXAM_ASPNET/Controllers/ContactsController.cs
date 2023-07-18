using Microsoft.AspNetCore.Mvc;
using PRACTICE_EXAM_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRACTICE_EXAM_ASPNET.Models;

namespace PRACTICE_EXAM_ASPNET.Controllers
{
    public class ContactsController : Controller
    {
        private List<Contact> contacts = new List<Contact>(); // Lưu trữ tạm thời các liên hệ trong bộ nhớ

        public ActionResult Index(string sortOrder, string searchString)
        {
            // Sắp xếp danh sách liên hệ
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var sortedContacts = contacts.OrderBy(c => c.ContactName);
            switch (sortOrder)
            {
                case "name_desc":
                    sortedContacts = contacts.OrderByDescending(c => c.ContactName);
                    break;
                default:
                    sortedContacts = contacts.OrderBy(c => c.ContactName);
                    break;
            }

            // Tìm kiếm thông tin liên hệ
            if (!String.IsNullOrEmpty(searchString))
            {
                sortedContacts = sortedContacts.Where(c => c.ContactName.Contains(searchString));
            }

            return View(sortedContacts.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            // Kiểm tra trùng tên liên hệ
            if (contacts.Any(c => c.ContactName == contact.ContactName))
            {
                ModelState.AddModelError("ContactName", "Tên liên hệ đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                // Tạo một ID duy nhất cho liên hệ mới
                contact.Id = contacts.Count + 1;
                contacts.Add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
    }
}
