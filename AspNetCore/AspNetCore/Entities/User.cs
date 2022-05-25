using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<User>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.UserName).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.Email).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Gender).NotEmpty();
            RuleFor(createNoteCommand =>
              createNoteCommand.Age).NotEmpty();

        }
    }
}
