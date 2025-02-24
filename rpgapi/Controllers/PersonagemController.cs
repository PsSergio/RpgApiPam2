using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpgapi.Models;
using Microsoft.AspNetCore.Mvc;
using rpgapi.Models.Enums;

namespace rpgapi.Contorllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
         private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetFirst")]
        public IActionResult GetFirst(){
            return Ok(personagens[0]);
        }

        [HttpGet("Get")]
        public IActionResult Get(){
            return Ok(personagens);
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem newpersonagem){
            personagens.Add(newpersonagem);
            return Ok(personagens);
        }

        public IActionResult PutPersonagem(Personagem p){
            Personagem alterado = personagens.Find(pers => pers.Id == p.Id);
            alterado.Nome = p.Nome;
            alterado.PontosVida = p.PontosVida;
            alterado.Forca = p.Forca;
            alterado.Defesa = p.Defesa;
            alterado.Inteligencia = p.Inteligencia;
            alterado.Classe = p.Classe;

            return Ok(personagens);
        }

        public IActionResult DeleteById(int id){
            return Ok(personagens.RemoveAll(pers => pers.Id == id));
        }
    }
}