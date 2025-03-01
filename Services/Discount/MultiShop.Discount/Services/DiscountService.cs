using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public async Task CreateCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupon (Code, Rate, IsActive,ValidDate) VALUES (@code, @rate, @isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponAsync(int couponId)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdCouponAsync(int couponId)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using(var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query);
            }
        }

        public async Task UpdateCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}