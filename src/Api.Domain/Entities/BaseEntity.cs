using System;
using System.ComponentModel.DataAnnotations;


namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime? _creatAt;
        public DateTime? CreteAt
        {
            get { return _creatAt; }
            // se value vier null, pega a hora do momento, senão recebe o valor que foi enviado
            set { _creatAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime UpdateAt { get; set; }

    }
}
