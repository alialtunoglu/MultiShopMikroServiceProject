using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var result = await _discountService.GetAllCouponAsync();
            return Ok(result);
        }
        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountCouponBy(int couponId)
        {
            var result = await _discountService.GetByIdCouponAsync(couponId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon Başarıyla Oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int couponId)
        {
            await _discountService.DeleteCouponAsync(couponId);
            return Ok("Kupon Başarıyla Silindi");
        }
    }
}