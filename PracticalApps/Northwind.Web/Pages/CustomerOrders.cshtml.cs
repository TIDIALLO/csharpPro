using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared; // Customer

namespace Northwind.Web.Pages;

public class CustomersOrdersModel : PageModel
{
    private NorthwindContext db;
    public Customer? Customer;

    public CustomersOrdersModel(NorthwindContext db)
    {
        this.db = db;
    }

    public void OnGet(){
        string id = HttpContext.Request.Query["id"];
        Customer = db.Customers.Include(c => c.Orders).SingleOrDefault(c => c.CustomerId == id);

    }

}