using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;

namespace DojoCourse.Module.Models
{
    public class PersonPart : ContentPart
    {
        public string Name { get; set; }
        public Handedness Handedness { get; set; }
        public DateTime? BirthDateUtc { get; set; }
        public TextField Biography { get; set; }
    }

    public enum Handedness
    {
        Left,
        Right,
    }
}
