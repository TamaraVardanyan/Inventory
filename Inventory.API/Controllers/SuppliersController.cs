using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Infrastructure.DTOs;
using Inventory.Infrastructure.Models;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            var supplierDtos = _mapper.Map<List<SupplierDTO>>(suppliers);
            return Ok(supplierDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var supplierDto = _mapper.Map<SupplierDTO>(supplier);
            return Ok(supplierDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDTO supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var supplier = _mapper.Map<Supplier>(supplierDto);
            await _supplierService.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.ID }, supplierDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierDTO supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }
            var supplier = _mapper.Map<Supplier>(supplierDto);
            supplier.ID = id;

            await _supplierService.UpdateSupplierAsync(id,supplier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }
            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }

}
