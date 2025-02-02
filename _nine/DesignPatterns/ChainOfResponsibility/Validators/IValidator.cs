using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators;

public interface IValidator<T> where T : class
{
    IValidator<T> SetNext(IValidator<T> nextValidator);

    void Validate(T value);
}