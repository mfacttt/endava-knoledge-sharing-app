using FluentValidation;

namespace KnowledgeSharing.APP.Features.Module.Commands.Create;

public sealed class CreateModuleValidator : AbstractValidator<CreateModuleCommand>
{
    public CreateModuleValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("Invalid course ID.");
    }
}