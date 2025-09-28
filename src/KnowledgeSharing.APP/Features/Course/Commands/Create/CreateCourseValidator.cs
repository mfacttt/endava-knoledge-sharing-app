using FluentValidation;

namespace KnowledgeSharing.APP.Features.Course.Commands.Create;

public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.CourseDiscipline)
            .NotEmpty().WithMessage("Discipline is required.")
            .IsInEnum().WithMessage("Invalid discipline.");

        RuleFor(x => x.CourseDifficulty)
            .NotEmpty().WithMessage("Difficulty is required.")
            .IsInEnum().WithMessage("Invalid difficulty.");
    }
}