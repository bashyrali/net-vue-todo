using FluentValidation;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator:AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.UserId).NotEmpty();

        }
    }
}