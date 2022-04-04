using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Packt.Shared; // Customer

namespace Northwind.Web.Pages;

public class CustomersModel : PageModel{

    public ILookup<string?, Customer>? CustomersByCountry;

    private NorthwindContext db;

    public CustomersModel(NorthwindContext db){
        this.db =  db;
    }

    public void OnGet(){
        //ViewData["Title"] = "Northwind B2B - customers";
        CustomersByCountry = db.Customers.ToLookup(c => c.Country);
    }
}