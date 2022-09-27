using Microsoft.AspNetCore.Mvc;
using Infrastructure.data;
using API.Errors;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _Context;
        public BuggyController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("notfound")]

        public ActionResult GetNotFoundRequest()
        {
            var thing = _Context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }
        [HttpGet("servererror")]

        public ActionResult GetServerError()
        {
            var thing = _Context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }
        [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {

            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]

        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

    }

}