using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers; 

public class AnnotationController : Controller {
    // GET
    public IActionResult Index() {
        return View();
    }
}