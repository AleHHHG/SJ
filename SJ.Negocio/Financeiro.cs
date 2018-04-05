using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
namespace SJ.Negocio
{
    public class Financeiro
    {
        public static FinanceiroCollection GetAll()
        {
            return new Select().From<SJ.DAL.Financeiro>().ExecuteAsCollection<FinanceiroCollection>();
        }

        public static SJ.DAL.Financeiro GetById(long Id)
        {
            return new SJ.DAL.Financeiro(Id);
        }
    }
}
