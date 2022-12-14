using System;
using System.Collections.Generic;

namespace Sharedkernel.Core {
	public abstract class Entity<TId> {
		public TId Id { get; protected set; }

		private readonly ICollection<DomainEvent> _domainEvents;

		public ICollection<DomainEvent> DomainEvents { get { return _domainEvents; } }

		protected Entity() {
			_domainEvents = new List<DomainEvent>();
		}

		public void AddDomainEvent(DomainEvent evento) {
			_domainEvents.Add(evento);
		}
		/*
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void CheckRule(IBussinessRule rule)
        {
            if (rule is null)
            {
                throw new ArgumentException("Rule cannot be null");
            }
            if (!rule.IsValid())
            {
                throw new BussinessRuleValidationException(rule);
            }
        }
        */
	}
}
