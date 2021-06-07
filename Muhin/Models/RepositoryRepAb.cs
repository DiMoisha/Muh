using Muhin.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Muh.Models
{
    public class RepositoryRepAb
    {
        private AbzContext db = new AbzContext();
        public List<RepabView> GetListRepab()
        {
            List<RepabView> repab = new List<RepabView>();
            RepabView rab;
            DateTime BegDat;
            DateTime EndDat;
            int year = DateTime.Today.Year;
            int dm = DateTime.Today.Month;
            BegDat = new DateTime(year, dm, 01, 0, 0, 0);
            EndDat = BegDat.AddMonths(1).AddDays(-1);

            //var res = db.Repabs.Where(b => b.ddat >= BegDat && b.id_ab == 4455).GroupBy(b=>b.Gn,b=>b.model)
            //    //.Select(g => new Repab { gn= group.Key, sm = g.Sum(Repab => Repab.sm), Count = g.Count() })
            //    .ToList();

  
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@dbeg", BegDat);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@dend", EndDat);
            System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@ab", 4455);

            var car = db.Database.SqlQuery<RepabView>("aRepAb @dbeg,@dend,@ab", param, param2, param3);
            RepabView repCommon = new RepabView();
            repCommon.sm = 0;
            foreach (var bl in car)
            {
                rab = new RepabView();
                rab.Gn = bl.Gn;
                rab.model = bl.model;
                rab.sm = bl.sm;
                rab.cnt = bl.cnt;
                rab.WorkDay = bl.WorkDay;
                rab.avgAll = bl.avgAll;
                rab.avgDay = bl.avgDay;

                repCommon.sm = repCommon.sm + rab.sm;
                repCommon.cnt = repCommon.cnt + rab.cnt;
                repCommon.WorkDay = repCommon.WorkDay + rab.WorkDay;

                repab.Add(rab);
            }

            return repab;
        }

        public AbView GetComRepab(DateTime BegDat, DateTime EndDat)
        {
            AbView ab = new AbView();
            RepabView rab;
            //Total total = ne
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@dbeg", BegDat);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@dend", EndDat);
            System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@ab", 4455);

            var car = db.Database.SqlQuery<RepabView>("aRepAb @dbeg,@dend,@ab", param, param2, param3);
            //RepabView repCommon = new RepabView();
            Total repCommon = new Total();
            repCommon.sm = 0;
            foreach (var bl in car)
            {
                rab = new RepabView();
                rab.Gn = bl.Gn;
                rab.model = bl.model;
                rab.sm = bl.sm;
                rab.cnt = bl.cnt;
                rab.WorkDay = bl.WorkDay;
                rab.avgAll = bl.avgAll;
                rab.avgDay = bl.avgDay;

                repCommon.sm = repCommon.sm + rab.sm;
                repCommon.cnt = repCommon.cnt + rab.cnt;
                repCommon.WorkDay = repCommon.WorkDay + rab.WorkDay;
                ab.repab.Add(rab);
                //repab.Add(rab);
            }
            ab.total = repCommon;
            //ab.total.sm = repCommon.sm;
            //ab.total.cnt= repCommon.cnt;
            //ab.total.WorkDay= repCommon.WorkDay;

            return ab;
        }

    }
}