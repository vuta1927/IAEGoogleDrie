using IAEGoogleDrie.Dependency;
using Microsoft.AspNetCore.Mvc;

namespace IAEGoogleDrie.AspNetCore.Mvc.Controllers
{
    public class AppController : Controller, ITransientDependency
    {
    }
}