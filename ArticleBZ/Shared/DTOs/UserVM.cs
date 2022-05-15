using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBZ.Shared.DTOs
{
    public class UserVM
    {

        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "وارد کردن آدرس ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "کلمه عبور را بدرستی وارد کنید")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="تکرار کلمه عبور مغایرت دارد")]
        public string RePassword { get; set; }
        public string Job { get; set; } = null;
        public string Bio { get; set; } = null;
    }
}
