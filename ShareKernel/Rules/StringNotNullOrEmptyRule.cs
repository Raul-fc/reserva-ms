using Sharedkernel.Core;
using System;

namespace Sharedkernel.Rules {
	public class StringNotNullOrEmptyRule : IBussinessRule {
		private string _value;

		public StringNotNullOrEmptyRule(string value) {
			_value = value;
		}
		public string Message => "String cannot be null";

		public bool IsValid() {
			return !string.IsNullOrEmpty(_value);
		}
	}
}
