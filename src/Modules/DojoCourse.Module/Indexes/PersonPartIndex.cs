using DojoCourse.Module.Models;
using OrchardCore.ContentManagement;
using System;
using YesSql.Indexes;

namespace DojoCourse.Module.Indexes
{
    public class PersonPartIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public DateTime? BirthDateUtc { get; set; }
    }


    public class PersonPartIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context) =>
            context.For<PersonPartIndex>().Map(contentItem =>
            {
                var personPart = contentItem.As<PersonPart>();

                return personPart == null
                    ? null
                    : new PersonPartIndex
                    {
                        ContentItemId = contentItem.ContentItemId,
                        BirthDateUtc = personPart.BirthDateUtc
                    };
            });
    }
}
