using System.ComponentModel.DataAnnotations;

namespace P01_MvcConcept.Models
{
    public class Product
    {
        //Validation
        [Display(Name="รหัส")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int Id { get; set; }
        [Display(Name = "ชื่อสินค้า")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [StringLength(100,MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "ราคา")]
        [Range(5,double.MaxValue, ErrorMessage = "กรุณากรอกขั้นต่ำ {1}")]
        public double Price { get; set; }
        [Display(Name = "จำนวน")]
        [Range(1,100)]
        public int Amount { get; set; }
    }
}
