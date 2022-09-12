using Bank.Exceptions;
using Bank.Models.Requests;
using Bank.Services.Interafaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            var withdrawResponse = _transactionService.Withdraw(transactionRequest.Number, transactionRequest.Amount);
            return Ok(withdrawResponse);
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (BalanceException balanceException)
        {
            return BadRequest(balanceException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            _transactionService.Deposit(transactionRequest.Number, transactionRequest.Amount);
            return Ok();
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }
    
    [HttpPost("use-credit")]
    public IActionResult UseCredit([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            var useCreditResponse = _transactionService.UseCredit(transactionRequest.Number, transactionRequest.Amount);
            return Ok(useCreditResponse);
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (CreditException creditException)
        {
            return BadRequest(creditException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }
    
    [HttpPost("pay-credit")]
    public IActionResult PayCredit([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            _transactionService.PayCredit(transactionRequest.Number, transactionRequest.Amount);
            return Ok();
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (CreditException creditException)
        {
            return BadRequest(creditException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }
    
    [HttpPost("pay-credit-with-balance")]
    public IActionResult PayCreditWithBalance([FromBody] TransactionRequest transactionRequest)
    {
        try
        {
            _transactionService.PayCreditWithBalance(transactionRequest.Number, transactionRequest.Amount);
            return Ok();
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (BalanceException balanceException)
        {
            return BadRequest(balanceException.Message);
        }
        catch (CreditException creditException)
        {
            return BadRequest(creditException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }
    
    [HttpPost("pay-all-credit-with-balance")]
    public IActionResult PayAllCreditWithBalance([FromBody] int number)
    {
        try
        {
            _transactionService.PayAllCreditWithBalance(number);
            return Ok();
        }
        catch (InvalidAccountNumberException invalidAccountNumberException)
        {
            return BadRequest(invalidAccountNumberException.Message);
        }
        catch (CreditException creditException)
        {
            return BadRequest(creditException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "It had a problem to process your transaction.");
        }
    }
}