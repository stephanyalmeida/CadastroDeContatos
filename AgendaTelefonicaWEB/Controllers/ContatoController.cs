using AgendaTelefonicaWEB.Models;
using AgendaTelefonicaWEB.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonicaWEB.Controllers
{

    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                   TempData["MensagemSucesso"] = "Contato Apagado com Sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, erro ao Apagar contato, tente novamente";
                }
                
                return RedirectToAction("Index");
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao Apagar contato, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
                

         }
            

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception erro){

                TempData["MensagemErro"] = $"Ops, erro ao cadastrar, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
  

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com Sucesso!";
                    return RedirectToAction("Index");

                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao Editar, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
           
        }
    }
}

