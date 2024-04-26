using System.ComponentModel.DataAnnotations;

namespace CaseWork.Model.BodyRequest
{
    public class GlobalParameterUpdateRequest
    {
        [Required(ErrorMessage ="ID is required")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Value Parameter is required")]
        public string ValueParameter { get; set; }
    }
}
