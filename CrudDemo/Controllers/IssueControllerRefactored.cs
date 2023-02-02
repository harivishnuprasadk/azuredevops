using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudDemo.Data;
using CrudDemo.Models;
using Microsoft.EntityFrameworkCore;
using CrudDemo.Repository;

namespace CrudDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueControllerRefactored : ControllerBase
    {

        public readonly IRepository<Issue, int> issuesRepository; 

        public IssueControllerRefactored(IRepository<Issue, int> issuesRepository)
        {
            this.issuesRepository = issuesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {
            return await issuesRepository.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {

            var issue= await issuesRepository.GetById(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await issuesRepository.Insert(issue);
            await issuesRepository.Save();
            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id) return BadRequest();
            await issuesRepository.Update(id,issue);
            await issuesRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await issuesRepository.Delete(id);
            await issuesRepository.Save();
            return NoContent();
        }
    }
}