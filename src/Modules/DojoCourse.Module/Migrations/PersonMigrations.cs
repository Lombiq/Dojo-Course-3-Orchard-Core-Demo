using DojoCourse.Module.Indexes;
using DojoCourse.Module.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DojoCourse.Module.Migrations
{
    public class PersonMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;


        public PersonMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;


        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(PersonPart), part => part
                .Attachable()
                .WithField(nameof(PersonPart.Biography), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Biography")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "The person's biography."
                    })
                    .WithEditor("TextArea"))
            );

            _contentDefinitionManager.AlterTypeDefinition("PersonPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(PersonPart))
            );

            _contentDefinitionManager.AlterTypeDefinition("PersonWidget", type => type
                .WithPart(nameof(PersonPart))
                .Stereotype("Widget")
            );

            SchemaBuilder.CreateMapIndexTable(nameof(PersonPartIndex), table => table
                .Column<string>(nameof(PersonPartIndex.ContentItemId), column => column.WithLength(26))
                .Column<DateTime>(nameof(PersonPartIndex.BirthDateUtc))
            );

            SchemaBuilder.AlterTable(nameof(PersonPartIndex), table => table
                .CreateIndex(
                    $"IDX_{nameof(PersonPartIndex)}_{nameof(PersonPartIndex.BirthDateUtc)}",
                    nameof(PersonPartIndex.BirthDateUtc))
            );

            return 3;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition("PersonWidget", type => type
                .WithPart(nameof(PersonPart))
                .Stereotype("Widget")
            );

            return 2;
        }

        public int UpdateFrom2()
        {
            SchemaBuilder.CreateMapIndexTable(nameof(PersonPartIndex), table => table
                .Column<string>(nameof(PersonPartIndex.ContentItemId), column => column.WithLength(26))
                .Column<DateTime>(nameof(PersonPartIndex.BirthDateUtc))
            );

            SchemaBuilder.AlterTable(nameof(PersonPartIndex), table => table
                .CreateIndex(
                    $"IDX_{nameof(PersonPartIndex)}_{nameof(PersonPartIndex.BirthDateUtc)}",
                    nameof(PersonPartIndex.BirthDateUtc))
            );

            return 3;
        }
    }
}
