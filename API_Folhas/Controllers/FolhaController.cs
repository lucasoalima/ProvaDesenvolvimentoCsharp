using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public FolhaController(DataContext context) =>
            _context = context;

        //POST /api/folha/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {
            var SalarioBruto = folha.QtdHrs * folha.ValorHrs;
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault
            (
                f => f.FuncionarioId.Equals(folha.FuncionarioId)
            );
            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
              
            if(SalarioBruto < 1903.98)
            {
                folha.ImpostoRenda = 0;
            }
            else if(SalarioBruto < 2826.65)
            {
                folha.ImpostoRenda = (SalarioBruto * 0.075) - 142.80;
            }
            else if(SalarioBruto < 3751.05)
            {
                folha.ImpostoRenda = (SalarioBruto * 0.15) - 354.80;
            }
            else if(SalarioBruto < 4664.68)
            {
                folha.ImpostoRenda = (SalarioBruto * 0.225) - 636.13;
            }
            else
            {
                folha.ImpostoRenda = (SalarioBruto * 0.275) - 869.36;
            }

            // INSS
            if(SalarioBruto < 1693.72)
            {
                folha.ImpostoInss = SalarioBruto * 0.08;
            }
            else if(SalarioBruto < 2822.9)
            {
                folha.ImpostoInss = SalarioBruto * 0.09;
            }
            else if(SalarioBruto < 5645.80)
            {
                folha.ImpostoInss = SalarioBruto * 0.11;
            }
            else
            {
                folha.ImpostoInss = 621.03;
            }
            
            folha.ImpostoFgts = SalarioBruto * 0.08;

            //SALARIO LIQUIDO
            folha.SalarioLiquido = SalarioBruto - folha.ImpostoInss - folha.ImpostoRenda;

            _context.Folhas.Add(folha);
            _context.SaveChanges();
            return Created("", folha);

            }            
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var folhas = _context.Folhas.Include(p => p.Funcionario).ToList();

            if(folhas == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(folhas);

            }
        }

        [Route("buscar/{cpf}/{mes}/{ano}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf, int mes, int ano)
        {
            Funcionario funcionario =
                _context.Funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            
            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
                var folhas_funcionario = _context.Folhas.Where(f => f.FuncionarioId == funcionario.FuncionarioId).ToList();

                FolhaPagamento folha = folhas_funcionario.FirstOrDefault
                (
                    f => f.Mes.Equals(mes) && f.Ano.Equals(ano)
                );

                if(folha == null)
                {
                    return NotFound();
                }

                else
                {
                    return Ok(folha);
                }
            }
            
        }


        [Route("filtrar/{mes}/{ano}")]
        [HttpGet]
        public IActionResult Filtrar([FromRoute] int mes, int ano)
        {
            var folhas = _context.Folhas.Include(p => p.Funcionario).Where(f => f.Mes == mes && f.Ano == ano)
            .ToList();

            if(folhas == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(folhas);
            }   
        }
    }
}

