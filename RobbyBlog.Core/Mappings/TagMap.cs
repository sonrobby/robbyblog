﻿using FluentNHibernate.Mapping;
using RobbyBlog.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobbyBlog.Core.Mappings
{
    public class TagMap:ClassMap<Tag>
    {
        public TagMap()
        {
            Table("Tags");
            Id(x => x.Id);

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(200);

            HasManyToMany(x => x.Posts)
                .Cascade.All().Inverse()
                .Table("PostTags");
        }
    }
}
