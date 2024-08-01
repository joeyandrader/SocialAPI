using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? PersonId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        #region Relations
        public Post? Posts { get; set; }
        public Person? Person { get; set; }
        #endregion
    }
}
