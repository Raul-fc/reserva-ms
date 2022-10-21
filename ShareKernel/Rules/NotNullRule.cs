using Sharedkernel.Core;
using System;

namespace Sharedkernel.Rules {
	public class NotNullRule : IBussinessRule {
		private object _value;

		public NotNullRule(object value) {
			_value = value;
		}
		public string Message => throw new NotImplementedException();

		public bool IsValid() {
			return _value != null;
		}
	}
}
