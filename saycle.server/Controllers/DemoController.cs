using Microsoft.AspNetCore.Mvc;
using saycle.server.Models;

namespace saycle.server.Controllers
{
    /// <summary>
    /// Demo controller to check demonstrate the Web-API.
    /// </summary>
    [Route("api/[controller]")]
    public class DemoController : Controller
    {
        /// <summary>
        /// Returns the answer to life the universe and everything. 
        /// </summary>
        /// <returns>42</returns>
        [HttpGet]
        public int Get()
        {
            return 42;
        }

        /// <summary>
        /// Returns the difference to the life the universe and everything.
        /// </summary>
        /// <param name="id">Value to calculate the difference to 42</param>
        /// <returns>42 - <paramref name="id"/></returns>
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return 42 - id;
        }

        /// <summary>
        /// Does absolutly nothing.
        /// </summary>
        /// <param name="value"><see cref="DemoObject"/></param>
        [HttpPost]
        public JsonResult Post([FromBody]DemoObject value)
        {
            return Json(value);
        }

        /// <summary>
        /// Does absolutly nothing.
        /// </summary>
        /// <param name="id">Index of the thing to do nothing with</param>
        /// <param name="value">Value to do nothing with</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        /// <summary>
        /// Deletes nothing.
        /// </summary>
        /// <param name="id">Index of the thing to do nothing with</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
