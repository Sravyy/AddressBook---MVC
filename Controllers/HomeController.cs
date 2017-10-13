using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Contact> allContacts = Contact.GetAll();
      return View(allContacts);
    }

    [HttpGet("/addContact")]
    public ActionResult AddContactForm()
    {
      return View();
    }

    [HttpPost("/contact/new")]
    public ActionResult ContactConfirmation()
    {
      Contact newContact = new Contact(Request.Form["full-name"],int.Parse(Request.Form["contanct-no"]),Request.Form["address"]);
      List<Contact> allContacts = Contact.GetAll();
      return View();
    }


    [HttpGet("/contacts/{id}")]
    public ActionResult ContactDetails(int id)
    {
      Contact contact = Contact.Find(id);
      return View(contact);
    }

    [HttpGet("/contacts")]
    public ActionResult AllContacts()
    {
      List<Contact> allContacts = Contact.GetAll();
      return View("Index", allContacts);
    }

    [HttpPost("/contact/clearAll")]
    public ActionResult ContactListClear()
    {
      Contact.ClearAll();
      return View();
    }





























  }
}
