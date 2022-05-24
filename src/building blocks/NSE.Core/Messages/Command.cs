using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages
{
    public class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timespan { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timespan = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
