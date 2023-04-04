using System.Diagnostics;
using Fiap.Web.AspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet.Controllers;
public class RepresentanteController : Controller {
	private readonly ILogger<HomeController> _logger;
	private IList<RepresentanteModel> representantes;
	public RepresentanteController(ILogger<HomeController> logger) {
		_logger = logger;
		representantes = new List<RepresentanteModel>();
		representantes.Add(new RepresentanteModel(1, "444.143.658-05", "José Carlos Silva"));
		representantes.Add(new RepresentanteModel(2, "062.572.723-19", "Maria José Fernandes"));
		representantes.Add(new RepresentanteModel(2, "920.680.661-06", "Carlos Silva"));
	}
	public IActionResult Index() {
		return View(representantes); // <-- Atenção
	}

	public IActionResult Welcome() {
		ViewData["Message"] = "Your welcome message";

		return View();
	}

	[HttpGet]
	public IActionResult Cadastrar() {
		// Imprime a mensagem de execução
		Console.WriteLine("Executou a Action Cadastrar()");

		// Retorna para a View Cadastrar um 
		// objeto modelo com as propriedades em branco 
		return View(new RepresentanteModel());
	}

	// Anotação de uso do Verb HTTP Post
	[HttpPost]
	public IActionResult Cadastrar(RepresentanteModel representante) {
		// Imprime os valores do modelo
		Console.WriteLine("Descrição: " + representante.Cpf);
		Console.WriteLine("Comercializado: " + representante.NomeRepresentante);

		// Simila que os dados foram gravados.
		Console.WriteLine("Gravando o Representante");

		// Substituímos o return View()
		// pelo método de redirecionamento
		return RedirectToAction("Index", "Representante");
	}

	[HttpPost("{representante}")]
	public IActionResult Editar([FromBody] RepresentanteModel representante) {
		// Imprime os valores do modelo
		Console.WriteLine("Descrição: " + representante.Cpf);
		Console.WriteLine("Comercializado: " + representante.NomeRepresentante);

		// Simila que os dados foram gravados.
		Console.WriteLine("Gravando o Representante");

		// Substituímos o return View()
		// pelo método de redirecionamento
		return RedirectToAction("Index", "Representante");
	}

	[HttpGet]
	public IActionResult Editar(int id) {
		Console.WriteLine("Consultando pelo Id: " + id);

		Models.RepresentanteModel Representante = new Models.RepresentanteModel(id, "444.143.658-05", "José Carlos Silva");

		return View(Representante);
	}

}