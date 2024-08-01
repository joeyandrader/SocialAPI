using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Followers
    {
        public int FollowerId { get; set; }
        public int FollowedId { get; set; }

        #region Relations
        public Person? Follower { get; set; }
        public Person? Followed { get; set; }
        #endregion
    }
}
