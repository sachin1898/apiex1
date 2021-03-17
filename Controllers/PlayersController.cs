using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        static List<Player> listplayers = new List<Player>()
        {
            new Player{PId=1,PName="jofra archer",PDOB=DateTime.Parse("12/12/1990"),PTeam="england"},
            new Player{PId=2,PName="virat kohli",PDOB=DateTime.Parse("10/05/1991"),PTeam="india"},
            new Player{PId=1,PName="rohit shrma",PDOB=DateTime.Parse("05/03/1989"),PTeam="india"},
            new Player{PId=1,PName="yuvraj singh",PDOB=DateTime.Parse("03/04/1985"),PTeam="india"}
        };
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return listplayers;
        }
        [HttpGet("{pid}")]
        public ActionResult Get(int pid)
        {

            var res= listplayers.Find(p => p.PId == pid);
            if (res != null)
            {
                return Ok(res);
            }
            else return NotFound();
            
        }


        [HttpPost]
        public IEnumerable<Player> Post([FromBody]Player p)
        {
            Player pobj = new Player()
            {
                PId = p.PId,
                PName=p.PName,
                PDOB =DateTime.Now,
                PTeam=p.PTeam
            };
            listplayers.Add(pobj);
            return listplayers;
        }
        [HttpPut("{pid}")]
        public ActionResult Put(int pid,[FromBody] Player p)
        {
            var res= listplayers.Find(p => p.PId == pid);
            if (res != null)
            {
                Player pobj = new Player()
                {
                    PId = p.PId,
                    PName = p.PName,
                    PDOB = DateTime.Now,
                    PTeam = p.PTeam
                };
                listplayers.Add(pobj);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
