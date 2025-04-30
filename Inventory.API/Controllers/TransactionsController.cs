using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Infrastructure.DTOs;
using Inventory.Infrastructure.Models;
namespace Inventory.API.Controllers
{
    namespace Inventory.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TransactionsController : ControllerBase
        {
            private readonly ITransactionService _transactionService;
            private readonly IMapper _mapper;

            public TransactionsController(ITransactionService transactionService, IMapper mapper)
            {
                _transactionService = transactionService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransactions()
            {
                var transactions = await _transactionService.GetAllTransactionsAsync();

                var transactionDtos = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);

                return Ok(transactionDtos);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<TransactionDTO>> GetTransactionById(int id)
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(id);

                if (transaction == null)
                {
                    return NotFound();
                }
                var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
                return Ok(transactionDTO);
            }

            [HttpPost]
            public async Task<ActionResult<TransactionDTO>> AddTransaction([FromBody] TransactionDTO transactionDTO)
            {
                if (transactionDTO == null)
                {
                    return BadRequest();
                }
                var transaction = _mapper.Map<Transaction>(transactionDTO);
                var addedTransaction = await _transactionService.AddTransactionAsync(transaction);

                var addedTransactionDto = _mapper.Map<TransactionDTO>(addedTransaction);

                return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.ID }, addedTransactionDto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<TransactionDTO>> UpdateTransaction(int id, [FromBody] TransactionDTO transactionDto)
            {
                if (transactionDto == null)
                {
                    return BadRequest();
                }

                var existingTransaction = await _transactionService.GetTransactionByIdAsync(id);
                if (existingTransaction == null)
                {
                    return NotFound();
                }

                var transactionToUpdate = _mapper.Map<Transaction>(transactionDto);
                var updatedTransaction = await _transactionService.UpdateTransactionAsync(id, transactionToUpdate);

                var updatedTransactionDto = _mapper.Map<TransactionDTO>(updatedTransaction);

                return Ok(updatedTransactionDto);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteTransaction(int id)
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                var isDeleted = await _transactionService.DeleteTransactionAsync(id);
                if (!isDeleted)
                {
                    return BadRequest();
                }
                return NoContent();  
            }
        }
    }


}
