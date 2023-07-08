using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Domain.Core.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
