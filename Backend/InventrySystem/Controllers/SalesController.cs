using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Shared.DTO.Brand;
using Shared.DTO.Sale;

namespace MagicPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SalesController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            
            try
            {
                var sales = await _repository.Sales.GetAllSalesAsync(trackChanges: false);
                _logger.LogInfo("Returned all sales from database.");

                var salesResult = _mapper.Map<IEnumerable<SaleResponseDto>>(sales);
                return Ok(salesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllsales action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(Guid id)
        {
            var sale = await _repository.Sales.GetSaleByIdAsync(id, trackChanges: false);
            if (sale == null)
                return NotFound();
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromForm] Sales sale)
        {
            try
            {
                if (sale == null)
                {
                    _logger.LogError("Brand object sent from client is null.");
                    return BadRequest("Brand object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid brand object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var saleEntity = _mapper.Map<Sales>(sale);
                var processedSale = await _repository.Sales.ProcessSaleAsync(saleEntity);
                _repository.SaveAsync();

                var createdSale = _mapper.Map<SaleResponseDto>(processedSale);

                return CreatedAtRoute("BrandById", new { id = createdSale.Id }, createdSale);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBrand action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalSales([FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            var totalSales = await _repository.Sales.GetTotalSalesAsync(startDate, endDate);
            return Ok(totalSales);
        }
    }

}
