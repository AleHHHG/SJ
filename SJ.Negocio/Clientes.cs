using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
namespace SJ.Negocio
{
    public class Clientes
    {
        public static ClienteCollection GetAll()
        {
            return new Select().From<Cliente>().ExecuteAsCollection<ClienteCollection>();
        }


        public static Cliente GetById(long Id)
        {
            return new Cliente(Id);
        }

        public static bool Delete(long Id)
        {
            try
            {
                new Delete().From<Cliente>().Where(Cliente.IdColumn).IsEqualTo(Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
