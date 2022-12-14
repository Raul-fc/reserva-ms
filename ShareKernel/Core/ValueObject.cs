using System;

namespace Sharedkernel.Core {
	public abstract record ValueObject {
		public void CheckRule(IBussinessRule rule) {
			if (rule is null)
			{
				throw new ArgumentException("Rule cannot be null");
			}
			if (!rule.IsValid())
			{
				throw new BussinessRuleValidationException(rule);
			}
		}
	}
}
