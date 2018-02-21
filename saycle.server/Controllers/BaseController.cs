using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using saycle.server.Data;
//test comment
namespace saycle.server.Controllers
{
    /// <summary>
    /// Abstract representation of all Controllers.
    /// </summary>
    public abstract class BaseController : Controller
    {
        protected SaycleContext Context { get; }

        protected IMapper Mapper { get; }

        public BaseController(SaycleContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
