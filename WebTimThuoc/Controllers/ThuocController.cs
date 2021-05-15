using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimThuoc.Models;

namespace WebTimThuoc.Controllers
{
    public class ThuocController : Controller
    {
        //
        // GET: /Thuoc/
        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult Index()
        {
      
            List<THUOC> dsT = data.THUOCs.ToList();

            return View(dsT);
        }

        public ActionResult Search(string keyword)
        {
            //string keyword = col["txtKeyword"];
            List<THUOC> dsSearch = data.THUOCs.Where(s => s.TENTHUOC.Contains(keyword)).ToList();
            ViewBag.tb = "Tìm kiếm: " + keyword.ToString();
            //return View( dsSearch);

            return View("Index", dsSearch);

        }

  

        public ActionResult DSLoaiThuoc2()
        {
            List<LOAITHUOC> dsCD = data.LOAITHUOCs.ToList();
            return PartialView(dsCD);
        }


        public ActionResult HTSanPhamLoaiSP2(string malt, string tenlt)
        {
            List<THUOC> dsSP = data.THUOCs.Where(sp => sp.MALOAITHUOC == malt).ToList();
            ViewBag.tb = "Đây là tất cả thuốc thuộc loại: " + tenlt;
            return View("Index", dsSP);
        }

        public ActionResult ChiTiet(string maSP)
        {
            THUOC sp = data.THUOCs.SingleOrDefault(item => item.TENTHUOC == maSP);
            ////tạo biến kiểu dữ liệu sách cùng chủ đề
            //List<sanpham> dsSach_DM = data.sanphams.Where(s => s.loaisp == sp.loaisp).Take(5).ToList();
            //ViewBag.dm = dsSach_DM;
            return View(sp);
        }

   
    }
}
