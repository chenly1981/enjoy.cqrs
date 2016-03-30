﻿using MyCQRS.Commands;
using MyCQRS.EventStore;
using MyCQRS.Restaurant.Domain;

namespace MyCQRS.Restaurant.Commands.Handlers
{
    public class CloseTabCommandHandler : ICommandHandler<CloseTabCommand>
    {
        private readonly IDomainRepository _domainRepository;

        public CloseTabCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }
        public void Execute(CloseTabCommand command)
        {
            var tab = _domainRepository.GetById<TabAggregate>(command.AggregateId);
            tab.CloseTab(command.AmountPaid);
        }
    }
}