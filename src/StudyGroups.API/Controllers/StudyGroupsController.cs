using Microsoft.AspNetCore.Mvc;
using StudyGroups.Core.Entities;
using StudyGroups.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyGroups.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyGroupsController : ControllerBase
    {
        private readonly IStudyGroupService _studyGroupService;

        public StudyGroupsController(IStudyGroupService studyGroupService)
        {
            _studyGroupService = studyGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(List<Card> cards)
        {
            await _studyGroupService.AddAsync(cards);

            return NoContent();
        }

        [HttpGet("{groupName}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetGroup(string groupName)
        {
            return Ok(await _studyGroupService.GetGroupAsync(groupName));
        }

        [HttpGet("group-names")]
        public async Task<ActionResult<string>> GetGroupNames()
        {
            return Ok(await _studyGroupService.GetGroupNames());
        }

        [HttpDelete("{groupName}")]
        public async Task<IActionResult> DeleteGroup(string groupName)
        {
            await _studyGroupService.DeleteGroupAsync(groupName);
            
            return Ok(groupName);
        }
    }
}
