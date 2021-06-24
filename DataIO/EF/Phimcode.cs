using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIO.EF
{
    
    public class Phimcode
    {
        private WebPhim db = null;
        public Phimcode()
        {
            db = new WebPhim();
        }

        public List<Phim> ListPhim()
        {
            return db.Phims.ToList();
        }

        public Phim VideoPhim(int id)
        {
            return db.Phims.SingleOrDefault(x=>x.idPhim == id);
        }
    }
}
