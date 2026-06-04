using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Models;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    // Primary key auto-increment
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    // tên người dùng, bắt buộc
    [Required]
    [StringLength(255)]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; } = string.Empty;

    // email người dùng, bắt buộc, duy nhất
    [Required]
    [EmailAddress]
    [StringLength(255)]
    [Column(TypeName = "nvarchar(255)")]
    public string Email { get; set; } = string.Empty;

    // mô tả, cho phép null
    [Column(TypeName = "nvarchar(1000)")]
    public string? Description { get; set; }

    // trường tuổi có giá trị số phù hợp với tuổi người dùng
    [Range(0, 120)]
    public int Age { get; set; }

    // ngày tạo
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    // ngày cập nhật
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // xóa mềm
    public bool Deleted { get; set; } = false;
}