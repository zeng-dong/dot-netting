using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Validators;
using System.Linq.Expressions;

namespace DesignPatterns.Tests;

public static class ValidatorExtensions
{
    public static IPropertyValidator[] GetValidatorsForMember<T, TProperty>(
            this IValidator<T> validator, Expression<Func<T, TProperty>> expression)
    {
        var descriptor = validator.CreateDescriptor();
        var expressionMemberName = expression.GetMember()?.Name;

        return descriptor.GetValidatorsForMember(expressionMemberName).Select(x => x.Validator).ToArray();
    }
}