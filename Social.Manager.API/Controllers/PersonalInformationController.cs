using Microsoft.AspNetCore.Mvc;
using Social.Manager.BLL.PersonalInformations.Contract;
using Social.Manager.BLL.PersonalInformations.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social.Manager.API.Controllers
{
    public class PersonalInformationController : Controller
    {
        private readonly IPersonalInformationService _personalInformationService;
        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpGet("api/personalinformations")]
        public async Task<IActionResult> Paginate([FromQuery] int skip = 0, [FromQuery] int take = 20) =>
            Ok(await _personalInformationService.GetByPagesAsync(skip, take));

        [HttpGet("api/personalinformations/search")]
        public async Task<IActionResult> Search([FromQuery] SearchPersonalInformationDto search) =>
            Ok(await _personalInformationService.SearchAsync(search));
    }
}
