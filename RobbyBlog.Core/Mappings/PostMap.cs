using FluentNHibernate.Mapping;
using RobbyBlog.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobbyBlog.Core.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Table("Posts");
            Id(x => x.Id);

            Map(x => x.Title)
                .Length(255)
                .Not.Nullable();

            Map(x => x.ShortDescription)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.Detail)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Meta)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(255)
                .Not.Nullable();

            Map(x => x.Published)
                .Not.Nullable();

            Map(x => x.PostedOn)
                .Not.Nullable();

            Map(x => x.Modified);

            References(x => x.Category)
                .Column("Category")
                .Not.Nullable();

            HasManyToMany(x => x.Tags)
                .Table("PostTags");
        }
    }
}
