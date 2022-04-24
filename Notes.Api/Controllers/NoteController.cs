using Microsoft.AspNetCore.Mvc;

namespace Notes.Api.Controllers
{
    public class NoteController : ControllerBase
    {
        public string Index()
        {
            return "Hello";
        }
    }
}
