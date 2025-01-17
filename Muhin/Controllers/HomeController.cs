﻿using Muh.Models;
using Muhin.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muh.Controllers
{
    //i_M2f7LW
    public class HomeController : Controller
    {
        AbzContext db = new AbzContext();
        DateTime date1;
        DateTime date2;
        public int year = DateTime.Today.Year;
        public int dm = DateTime.Today.Month;
        public void GetDat(string cbDat, string ceDat)
        {
            if (cbDat == null)
            {
                MyDatView datView = new MyDatView();
                MyDatView SesdatView = (MyDatView)Session["MyDatView"];
                date1 = StringToDate.Date(SesdatView.CBDat);
                date2 = StringToDate.Date(SesdatView.CEDat);
            }
            else
            {
                date1 = StringToDate.Date(cbDat);
                date2 = StringToDate.Date(ceDat);
            }
        }

        public List<SalesByCategView> GetList(List<SalesByCateg> query, int flag = 0)
        {
            List<SalesByCategView> sales = new List<SalesByCategView>();
            var blTotal = from b in query
                          group b by b.txt
                     into q
                          select new { kol = q.Sum(b => b.kol), txt = q.Key };

            if (flag == 1)
            {
                blTotal = from b in query
                              group b by b.categ
                        into q
                              select new { kol = q.Sum(b => b.kol), txt = q.Key };
            }

            foreach (var bl in blTotal)
            {
                SalesByCategView salesView = new SalesByCategView();
                salesView.kol = bl.kol;
                salesView.txt = bl.txt;
                sales.Add(salesView);
            }
            
            return sales;
        }

        public void SetDat(int? selectedId, int? Id)
        {
            if (Id != null)
                year = (int)Id;
            else
            {
                if (Session["Year"] != null)
                    year = (int)Session["Year"];
                else
                    year = DateTime.Today.Year;
            }
            if (selectedId != null)
                dm = (int)selectedId;
            else
            {
                if (Session["Month"] != null)
                    dm = (int)Session["Month"];
                else
                    dm = DateTime.Today.Month;
            }
            Session["Month"] = dm;
            Session["Year"] = year;
        }

        public ActionResult IndexAB(int? selectedId, int? Id)
        {
            ViewBag.MenuItem = "rst";
            SetDat(selectedId, Id);
            DateOf datof = new DateOf(dm, year);
            ViewData["Month"] = new SelectList(datof.getMonth, "ID", "Mnth", dm);
            ViewData["Year"] = new SelectList(datof.getYear, "ID", "Mnth", year);
            return View();
        }
        public ActionResult SelectRepAb(int? selectedId, int? Id)
        {
            RepositoryRepAb rep = new RepositoryRepAb();
            AbView ab = new AbView();

            SetDat(selectedId, Id);
            DateOf datof = new DateOf(dm, year);
            if (Id == null)
            {
                year = DateTime.Today.Year;
            }
            else
            {
                year = (int)Id;
            }

            if (selectedId != null)
                dm = (int)selectedId;
            else
            {
                dm = DateTime.Today.Month;
            }

            DateTime BegDat = new DateTime(year, dm, 1);
            DateTime EndDat = BegDat.AddMonths(1);
            ab = rep.GetComRepab(BegDat, EndDat);
            return View(ab);
        }
        public ActionResult RepAb()
        {
            List<RepabView> repab;
            //= new List<Repab>();
            RepositoryRepAb rep = new RepositoryRepAb();
            repab = rep.GetListRepab();
            return View(repab);
        }

        public ActionResult Itog()
        {
            DateTime bDatPer = new DateTime(2021,4,1);
            DateTime eDatPer = DateTime.Now;

            //List<MuhinView> muhinsAll = new List<MuhinView>();
            //List<Muhin> query = db.Muhins.Where(d => (d.Dat >= bDatPer && d.Dat < eDatPer)).ToList();
            //List<Muhin> query = db.Muhins.Where(d => d.ID == 2962).Distinct<Muhin>().ToList();

            List<SalesByCategView> salesAll = new List<SalesByCategView>();
            List<SalesByCateg> query = db.Sales.Where(d => (d.Dat >= bDatPer && d.Dat < eDatPer)).ToList();

            salesAll = GetList(query, 1);

            DateTime startDate = new DateTime(eDatPer.Year, eDatPer.Month, 1);
            List<SalesByCategView> salesMonth = new List<SalesByCategView>();
            //List<Muhin>                 
            query = db.Sales.Where(d => (d.Dat >= startDate && d.Dat < eDatPer)).ToList();
            salesMonth = GetList(query, 1);

            GetDat(null, null);
            query = db.Sales.Where(d => (d.Dat >= date1 && d.Dat < date2)).ToList();
            //.OrderBy(CategId);
            List<SalesByCategView> sales = new List<SalesByCategView>();
            sales = GetList(query, 1);

            List<Itog> itogs = new List<Itog>();

            foreach (var mh in salesAll)
            {
                Itog itog       = new Itog();
                itog.categ      = mh.txt;
                itog.CategID    = mh.CategID;
                itog.qty = mh.kol;
                var qqq  = from b in salesMonth
                                where b.txt == itog.categ
                                select b;
                foreach (var www in qqq)
                {
                    itog.qtyMonth = www.kol;
                }
                var rrr = from b in sales
                          where b.txt == itog.categ
                          select b;
                foreach (var www in rrr)
                {
                    itog.qtyDay = www.kol;
                }
                itogs.Add(itog);
            }

            return View(itogs);
        }

        public ActionResult Production(string cbDat, string ceDat, int cat = 2)
        {
            List<SalesByCategView> sales = new List<SalesByCategView>();
            GetDat(cbDat, ceDat);
            List<SalesByCateg> query = db.Sales.Where(d => (d.Dat >= date1 && d.Dat<date2 && d.CategID==cat)).ToList();
            sales = GetList(query,0);
 
            ViewData["categ"] = new SelectList(db.Categs.ToList(), "CategId", "txt", 2);
            ViewBag.Beg = DateToString.CDat(date1);
            ViewBag.end = DateToString.CDat(date2);

            return View(sales);
        }
        public ActionResult Categ(string cbDat, string ceDat)
        {
            List<SalesByCategView> sales = new List<SalesByCategView>();
            GetDat(cbDat, ceDat);
            List<SalesByCateg> query = db.Sales.Where(d => (d.Dat >= date1 && d.Dat < date2)).ToList();
            sales = GetList(query,1);

            ViewBag.Beg = DateToString.CDat(date1);
            ViewBag.end = DateToString.CDat(date2);

            return View(sales);

        }
        public ActionResult Hr(string cbDat, string ceDat, int cat = 2)
        {
            List<HourView> muhins = new List<HourView>();
            GetDat(cbDat, ceDat);
            var query = db.HourViews.Where(d => (d.Dat > date1 && d.Dat < date2 && d.CategID==cat));

            var blTotal = from b in query
                          group b by b.txt                          
                   into q
                          select new { kol = q.Sum(b => b.kol), txt = q.Key };
                   

            foreach (var bl in blTotal)
            {
                HourView muhinView = new HourView();
                muhinView.kol = bl.kol;
                muhinView.txt = bl.txt;
                muhins.Add(muhinView);
            }

            List<HourView> muhins1 = muhins.OrderBy(a => a.txt).ToList();

            ViewData["categ"] = new SelectList(db.Categs.ToList(), "CategId", "txt", 2);
            ViewBag.Beg = DateToString.CDat(date1);
            ViewBag.end  = DateToString.CDat(date2);
            return View(muhins1);

        }        
        public ActionResult Index()
        {
            MyDatView datView = new MyDatView();
            if (Session["MyDatView"] == null)
            {
                datView.CBDat = DateToString.CDat(DateTime.Today);
                datView.CEDat = DateToString.CDat(DateTime.Today.AddDays(1));
                //Session["MyDatView"] = datView;
            }
            else
            {
                MyDatView SesdatView = (MyDatView)Session["MyDatView"];
                datView.CBDat = SesdatView.CBDat;
                datView.CEDat = SesdatView.CEDat;
            }

            //datView.CBDat = DateToString.CDat(datView.BDat);
            //datView.CEDat = DateToString.CDat(datView.EDat);

            //datView.BDat = StringToDate.Date(datView.CBDat).Date;
            //datView.EDat = StringToDate.Date(datView.CEDat).Date;


            Session["MyDatView"] = datView;
            return View(datView);
        }

        public ActionResult Graph()
        {
            List<GraphSale> graph = db.GraphSales.OrderByDescending(p => p.Centr).ToList();
 
            return View(graph);
        }

        [HttpPost]
        //public ActionResult Index(MyDatView datView, string Prod, string Categ, string Hr)
       public ActionResult Index(MyDatView datView)
        {
            //datView.CBDat = DateToString.CDat(datView.BDat.Date);
            //datView.CBDat = StringToDate.Date(datView.CBDat).Date;
            //datView.CEDat = DateToString.CDat(datView.EDat.Date);
            Session["MyDatView"] = datView;
            return View(datView);
         }
    }
}