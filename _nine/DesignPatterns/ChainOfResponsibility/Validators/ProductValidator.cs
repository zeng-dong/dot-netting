using ChainOfResponsibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators;

internal class ProductValidator : IValidator<Quote>
{
    private IValidator<Quote>? _next;

    public IValidator<Quote> SetNext(IValidator<Quote> nextValidator)
    {
        _next = nextValidator;
        return _next;
    }

    public void Validate(Quote value)
    {
        throw new NotImplementedException();
    }
}