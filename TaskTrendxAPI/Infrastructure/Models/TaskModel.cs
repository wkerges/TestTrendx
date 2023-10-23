using System.ComponentModel.DataAnnotations;

namespace TaskTrendxAPI.Infrastructure.Models
{
    public class TaskModel
    {
        [Required(ErrorMessage = "O campo Title é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 350, ErrorMessage = "O campo Title deve ter entre 1 e 350 caracteres.", MinimumLength = 1)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo Completed é obrigatório.")]
        public bool Completed { get; set; }
    }
}
