﻿using FluentValidation.Results;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;


        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDadosAsync(IUnitOfWork uow)
        {
            if (await uow.CommitAsync() == false)
            {
                AdicionarErro("Houve um erro ao persistir os dados");
            }

            return ValidationResult;
        }
    }
}
