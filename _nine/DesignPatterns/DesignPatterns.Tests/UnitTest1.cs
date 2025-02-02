using ChainOfResponsibility.Models;
using FluentValidation.Validators;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework.Utilities;

namespace DesignPatterns.Tests;

public class UnitTest1
{
    private readonly CustomerValidator _sut = new();

    [Fact]
    public void First_name_maximum_length_validator_is_set()
    {
        var validator = _sut.GetValidatorsForMember(t => t.Forename)
            .OfType<IMaximumLengthValidator>().FirstOrDefault();

        Assert.NotNull(validator);
    }

    [Fact]
    public void First_name_maximum_length_is_255()
    {
        var validator = _sut
            .GetValidatorsForMember(t => t.Forename).OfType<IMaximumLengthValidator>().FirstOrDefault();

        Assert.Equal(255, validator!.Max);
    }

    [Fact]
    public void First_name_not_empty_validator_is_set()
    {
        var validator = _sut.GetValidatorsForMember(t => t.Forename).OfType<INotEmptyValidator>().FirstOrDefault();

        Assert.NotNull(validator);
    }
}