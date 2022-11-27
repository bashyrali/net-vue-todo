using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator:AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.UserId).NotEmpty();
            RuleFor(command => command.Title).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Details).NotEmpty().MaximumLength(250);
        }
    }
}