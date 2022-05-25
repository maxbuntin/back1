using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class Cars
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }

        public int Price { get; set; }
        public DateTime Date { get; set; }

    }

    public class CreateTicketCommandValidator : AbstractValidator<Cars>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.BrandName).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.Model).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Price).NotEmpty();
        }
    }
}
