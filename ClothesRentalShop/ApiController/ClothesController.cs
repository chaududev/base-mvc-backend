using Application.Service.ClothService;
using ClothesRentalShop.Mapper;
using ClothesRentalShop.ViewModel;
using Domain.Cloth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesRentalShop.ApiController
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class ClothesController : ControllerBase
    {
        readonly IClothesService clothesService;
        readonly MappingService<Clothes, ClothesViewModel> mapper;

        public ClothesController(IClothesService clothesService)
        {
            this.clothesService = clothesService;
            this.mapper = new MappingService<Clothes, ClothesViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = clothesService.GetList(key, pageSize, page);
                return Ok(mapper.Map(rs));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                var rs = clothesService.GetById(id);
                if (rs == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map(rs));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Insert(ClothesViewModel clothes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clothesService.Add(clothes.Name, clothes.Description, clothes.Size, clothes.Price, clothes.RentalPrice, clothes.TypeClothesId, clothes.OriginId, clothes.Status);
                    return Ok();
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ClothesViewModel clothes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clothesService.Update(id, clothes.Name, clothes.Description, clothes.Size, clothes.Price, clothes.RentalPrice, clothes.TypeClothesId, clothes.OriginId, clothes.Status);
                    return Ok();
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                clothesService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


