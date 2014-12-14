﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;
using RobbyBlog.Core.Objects;

namespace RobbyBlog.Core
{
    public class BlogRepository:IBlogRepository
    {
        // NHibernate object
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }
        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _session.Query<Post>()
                            .Where(p => p.Published)
                            .OrderByDescending(p => p.PostedOn)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .Fetch(p => p.Category)
                            .ToList();
            var postIds = posts.Select(p => p.Id).ToList();

            return _session.Query<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .FetchMany(p => p.Tags)
                  .ToList();
        }

        public IList<Post> PostsInCategoy(int categoryId, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList<Post> PostsInTag(string tagName, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int TotalPosts()
        {
            return _session.Query<Post>().Where(p => p.Published).Count();
        }
    }
}
