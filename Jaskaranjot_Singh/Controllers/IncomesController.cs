using Microsoft.AspNetCore.Mvc;
using Jaskaranjot_Singh.Models;

namespace Jaskaranjot_Singh.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class IncomesController : ControllerBase
{
    [HttpGet("{userId}")]
    public IActionResult GetTotalIncome(int userId)
    {
        var totalIncome = IncomeRepository.GetTotalIncome(userId);
        return Ok(totalIncome);
    }

    [HttpGet("{userId}/{isReceived}")]
    public IActionResult GetReceivedIncomes(int userId, bool isReceived)
    {
        var incomes = IncomeRepository.GetReceivedIncomes(userId, isReceived);
        return Ok(incomes);
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteIncomes(int userId)
    {
        IncomeRepository.DeleteIncomes(userId);
        return NoContent();
    }

    [HttpPost]
    public IActionResult AddIncome([FromBody] Income income)
    {
        if (string.IsNullOrEmpty(income.Description) || income.Amount <= 0)
        {
            return BadRequest("Invalid income data.");
        }

        var newIncome = IncomeRepository.AddIncome(income);
        return CreatedAtAction(nameof(GetTotalIncome), new { userId = newIncome.UserId }, newIncome);
    }
}
}
