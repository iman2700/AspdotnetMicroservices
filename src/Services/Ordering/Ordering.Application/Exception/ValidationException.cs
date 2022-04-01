using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exception
{
    public class ValidationException : ApplicationException
    {
        public ValidationException():base("one more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures):this()
        {
            Errors = failures.GroupBy(e => e.PropertyName,e=>e.ErrorMessage).ToDictionary(failuresGroup=>failuresGroup.Key
            ,failureGroup=>failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
