using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidation:AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidation()
        {
            RuleFor(command => command.Title).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Details).NotEmpty().MaximumLength(250);
        }
    }
}