using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Brand;
using Shared.DTO.CartItem;

namespace MagicPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CartItemsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


       
        [HttpGet("{id}", Name = "CartItemById")]
        public async Task<IActionResult> GetCartItemByIdAsync(Guid carditemid)
        {
            try
            {
                var cartitem = await _repository.CartItem.GetCartItemByIdAsync(carditemid, trackChanges: false);
                if (cartitem == null)
                {
                    _logger.LogError($"Brand with id: {carditemid}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned brand with id: {carditemid}");

                var cartitemResult = _mapper.Map<BrandDto>(cartitem);
                return Ok(cartitem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBrandById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCartItem([FromBody] CartItemRequstDto cartitem)
        {
            try
            {
                if (cartitem == null)
                {
                    _logger.LogError("cartitem object sent from client is null.");
                    return BadRequest("cartitem object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid cart object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var cartitemEntity = _mapper.Map<Cartitem>(cartitem);

                _repository.CartItem.CreateCartItems(cartitemEntity);
                _repository.SaveAsync();

                var createdcartitem = _mapper.Map<CartItemDTO>(cartitemEntity);

                return CreatedAtRoute("cartitemById", new { id = createdcartitem.CartId }, createdcartitem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Createcartitem action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            try
            {
                var item = await _repository.CartItem.GetCartItemByIdAsync(id, trackChanges: false);
                if (item == null)
                {
                    _logger.LogError($"item with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.CartItem.DeleteCartItems(item);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Deleteitem action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
