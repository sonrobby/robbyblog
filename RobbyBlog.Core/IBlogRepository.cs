using RobbyBlog.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobbyBlog.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        IList<Post> PostsInCategoy(int categoryId, int pageNo, int pageSize);
        IList<Post> PostsInTag(string tagName, int pageNo, int pageSize);
        int TotalPosts();
    }
}
