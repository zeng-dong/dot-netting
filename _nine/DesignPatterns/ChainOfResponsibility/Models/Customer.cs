using FluentValidation;

namespace ChainOfResponsibility.Models;

public class Customer
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Forename { get; set; }
    public decimal Discount { get; set; }
    public string Address { get; set; }
}

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Please specify a last name");

        RuleFor(x => x.Forename)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Please specify a first name");

        RuleFor(x => x.Address).Length(20, 250);
    }
}