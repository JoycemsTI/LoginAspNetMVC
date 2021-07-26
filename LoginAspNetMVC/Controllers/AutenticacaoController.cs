using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginAspNetMVC.Utils;


namespace LoginAspNetMVC.Controllers
{
    public class AutenticacaoController: Controller
    {
        private UsuariosContext db = new UsuariosContext();

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = viewmodel.Nome,
                Login = viewmodel.Login,
                Senha = Hash.GerarHash(viewmodel.Senha)
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}