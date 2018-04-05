using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
namespace SJ.Negocio
{
    public class FormasPagamento
    {
        public static FormasPagamentoCollection GetAll()
        {
            return new Select().From<SJ.DAL.FormasPagamento>().ExecuteAsCollection<FormasPagamentoCollection>();
        }
    }
}
