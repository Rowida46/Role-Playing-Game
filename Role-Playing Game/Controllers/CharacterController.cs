using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rpg.data;
using System.Collections.Generic;
using System.Linq;

namespace Role_Playing_Game.Controllers
{
    /** [Route("[controller]")]
     * This means that this controller can be accessed by its name, in our case Character
    */
    [Route("api/[controller]/[action]")]

    /** [ApiController]
     * This attribute indicates that a type (and also all derived types) is used to serve HTTP API responses. 
     * Additionally, when we add this attribute to the controller, it enables several
     * API-specific features like attribute routing and automatic HTTP 400 responses
     *   if something is wrong with the model
     *.*/
    [ApiController]
    public class CharacterController : ControllerBase// This is a base class for an MVC controller without view support.
    {
        public static Character tmp = new Character();
        public static List<Character> chrs = new List<Character>
        {
            new Character(),
            new Character
            {
                id = 1,
                name = "Kafka",
                rgpclass = RpgClass.Mage

            }
        };
        [HttpGet]
        public IActionResult get()
        {
            /*We will return  ActionResult
            because this enables us 
            to send specific HTTP status codes back to the client 
            together with the actual data that was requested.
            */
            return Ok(tmp); 
        }
        public IActionResult getlst()
        {
            return Ok(chrs);
        }

        public IActionResult getsingel()
        {
            return Ok(chrs[-1]);
        }

        public IActionResult getsinglebyID(int id)
        {
            /*We add a new parameter to the GetSingle()
             * method and use LINQ to find the RPG character with the given Id
             * in the list of all characters.*/
            /*return Ok(chrs[id]);  WRONG
             
             WE DNT FOLOOW CACH NAIVE APPROACH INSTEAD , -> FirstOrDefault
            
             We do that with FirstOrDefault() followed by a lambda expression. */
            return Ok(chrs.Where(chr => chr.id == id).FirstOrDefault());
        }

        public IActionResult add(Character chr)
        {
            chrs.Add(chr);
            return Ok(chrs);
        }
    }
}
