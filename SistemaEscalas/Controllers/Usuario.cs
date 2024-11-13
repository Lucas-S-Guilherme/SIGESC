using Microsoft.AspNetCore.Mvc;
using SistemaEscalas.Models;


namespace SistemaEscalas.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //List<Tarefa> listaTarefas = new TarefaDAO().List(); // cria uma lista do tipo Tarefa, de nome listaTarefas, atribuí um novo objeto com base na classe TarefaDAO, acessando seu método List()

                return Ok();
            }
            catch (Exception)
            {
                return Problem($"Ocorreram erros ao processar a solicitação");
            }
        }
    }
}