using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.DTOs;
using UserApi.Models;
//using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        // GET: api/User
        //lấy danh sách trong bảng User: Có lọc Deleted, paging, sorting và searching hoạt động đúng.
        [HttpGet("get-all")]
        public async Task<ActionResult<ApiResponse<PageResult<User>>>> GetAll([FromQuery] UserQueryParameters queryParameters)
        {

            // kiểm tra nếu pageNumber nhỏ hơn 1 thì trả về lỗi
            if (queryParameters.PageNumber < 1)
            {
                return BadRequest(new ApiResponse<string>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Page number must be greater than 0",
                    Content = null
                });
            }

            // Giới hạn pageSize để tránh lấy quá nhiều dữ liệu.
            if (queryParameters.PageSize < 1 || queryParameters.PageSize > 100)
            {
                return BadRequest(new ApiResponse<string>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Page size must be between 1 and 100",
                    Content = null
                });
            }

            // b1: lấy dữ liệu từ database
            var query = _context.Users
                .AsNoTracking()
                .Where(u => u.Deleted == false);

            // b2: áp dụng tìm kiếm theo tên nếu có, ngược lại trống hoặc khoảng trắng thì lấy tất cả
            if (string.IsNullOrWhiteSpace(queryParameters.SearchTerm) == false)
            {
                query = query.Where(u => u.Name.Contains(queryParameters.SearchTerm));
            }

            // b3: áp dụng sắp xếp tăng hoặc giảm nếu có.Nếu nhập sai sortBy thì dùng Id làm mặc định, ngược lại mặc định sắp xếp theo Id,Name hoặc CreatedAt.
            bool isDescending = queryParameters.SortDirection == "desc";

            switch (queryParameters.SortBy?.ToLower())
            {
                case "name":
                    {
                        query = isDescending
                            ? query.OrderByDescending(u => u.Name)
                            : query.OrderBy(u => u.Name);
                    }
                    break;

                case "createdad":
                    {
                        query = isDescending
                            ? query.OrderByDescending(u => u.CreatedAt)
                            : query.OrderBy(u => u.CreatedAt);
                    }
                    break;

                default:
                    {
                        query = isDescending
                            ? query.OrderByDescending(u => u.Id)
                            : query.OrderBy(u => u.Id);
                    }
                    break;
            }

            // tính tổng số bản ghi
            var totalItem = await query.CountAsync();

            // b4: áp dụng phân trang
            var lstUser = await query
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize) // bỏ qua các bản ghi của trang trước
                .Take(queryParameters.PageSize) // lấy số bản ghi của trang hiện tại
                .ToListAsync();

            var pageResult = new PageResult<User>
            {
                TotalItems = totalItem,
                TotalPages = (int)Math.Ceiling((double)totalItem / queryParameters.PageSize),
                PageNumber = queryParameters.PageNumber,
                PageSize = queryParameters.PageSize,
                Items = lstUser
            };

            var response = new ApiResponse<PageResult<User>>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Lấy danh sách người dùng thành công",
                Content = pageResult
            };
            return Ok(response);
        }

    }
}