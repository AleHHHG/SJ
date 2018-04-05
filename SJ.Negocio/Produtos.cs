using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
namespace SJ.Negocio
{
    public partial class Produtos : SJ.DAL.Produto
    {
        public static ProdutoCollection GetAll()
        {
            return new Select().From<Produto>().ExecuteAsCollection<ProdutoCollection>();
        }

        public static ProdutoCollection GetAllAtivos()
        {
            return new Select().From<Produto>()
                .Where(AtivoColumn).IsEqualTo(true)
                .ExecuteAsCollection<ProdutoCollection>();
        }

        public static Produto GetById(long Id)
        {
            return new Produto(Id);
        }

        public static bool Delete(long Id)
        {
            try
            {
                new Delete().From<Produto>().Where(Produto.IdColumn).IsEqualTo(Id).Execute();
                return true;
            }catch
            {
                return false;
            }
            
        }
    }
}
