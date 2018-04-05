using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJ.Controllers
{
    public class BaseController : Controller
    {
        public Int64 usuario_logado;

        public BaseController()
        {
            usuario_logado = 1;
        }
    }
}