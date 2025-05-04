using System.ComponentModel.DataAnnotations;

namespace AppTask.Data
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
