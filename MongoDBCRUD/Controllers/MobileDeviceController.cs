using Microsoft.AspNetCore.Mvc;
using MongoDBCRUD.Interface;
using MongoDBCRUD.Models;

namespace MongoDBCRUD.Controllers
{
    public class MobileDeviceController : Controller
    {
        private readonly IMobileStore _context;
        public MobileDeviceController(IMobileStore context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.GetAllMobileDevices());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(MobileDeviceEntity mobiledata)
        {
            _context.Create(mobiledata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _context.GetMobileDeviceDetails(Name);
            return View(md);
        }
        [HttpPost]
        public IActionResult EditPost(string _id, MobileDeviceEntity mobiledata)
        {
            _context.Update(_id,mobiledata);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(string Name)
        {
            var md = _context.GetMobileDeviceDetails(Name);
            return View(md);
        }
        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _context.GetMobileDeviceDetails(Name);
            return View(md);
        }
        [HttpPost]
        public IActionResult DeletePost(string Name)
        {
            _context.Delete(Name);
            return RedirectToAction("Index");
        }
    }
}
