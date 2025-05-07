using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AppTask.Data
{
    public class TaskS
    {
        [Key]
        public Guid Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; }

        public DateTime InitAt { get; set; }

        public DateTime FinishtAt { get; set; }

        [NotNull]
        public Guid CreatedBy { get; set; }

        public User UserCreated { get; set; }

        [NotNull]
        
        public Guid AssingTo { get; set; }
        public User UserAssingned { get; set; }
    
        public Status Status { get; set; }
        [NotNull]
        public Guid StatusId { get; set; }
    } 
}
