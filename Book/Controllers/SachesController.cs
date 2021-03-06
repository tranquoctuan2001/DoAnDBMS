using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Models;
using PagedList;
using PagedList.Mvc;
namespace Book.Controllers
{
    public class SachesController : Controller
    {
        private DoAnEntities1 db = new DoAnEntities1();

        // GET: Saches
        public ActionResult Index(int? page)
        {
            ViewBag.title = "List Books";
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var saches = db.Saches.ToList();

            return View(saches.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Home(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var saches = db.Database.SqlQuery<BookNotOrder_Result>("BookNotOrder");
           
            return View(saches.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Catetogy(string li)
        {

            ViewBag.header = li;
            var saches = db.Database.SqlQuery<recommend_Result>("recommend N'%"+li+"%'");

            return View(saches.ToList());
        }

        // view Search
        public ActionResult Search(String sa)
        {
            var saches = db.Database.SqlQuery<searchBook_Result>("searchBook N'%" + sa + "%'");
            return View(saches.ToList());
        }
        // post search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(Sach sa)
        {
           
            return Search(sa.TenSach);
        }
        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,TenTacGia,MaNXB,TheLoai,SoLuong,GiaBan,HinhAnh")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,TenTacGia,MaNXB,TheLoai,SoLuong,GiaBan,HinhAnh")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sach.MaNXB);
            return View();
        }

        // POST: Saches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "MaSach")] ChiTietHoaDon dt)
        {
            if (Session["UserID"] == null)
            {
                // Trả về trang login để đăng nhập
                return RedirectToAction("Login", "KhachHangs");
            }
            int SoLuong = Convert.ToInt32(Request.Params.Get("SoLuong"));
            DateTime date = DateTime.Now;

            db.Don(Convert.ToInt32(Session["ID"].ToString()), date, dt.MaSach, SoLuong);
            return RedirectToAction("ViewCart", "Gios");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
