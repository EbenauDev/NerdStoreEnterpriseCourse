﻿using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Models;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (message.EhValido() == false)
                return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            var clienteExistente = await _clienteRepository.ObterPorCpfAsync(cliente.Cpf.Numero);
            if (clienteExistente != null)
            {
                AdicionarErro("O CPF já está em uso.");
                return ValidationResult;
            }
            _clienteRepository.Adicionar(cliente);


            return await PersistirDadosAsync(_clienteRepository.UnitOfWork);
        }
    }
}
