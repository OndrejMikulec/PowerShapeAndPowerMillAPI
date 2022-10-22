namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Equality overrides!
	/// </summary>
	public class ExtractedString
	{
		private readonly string entityName;
		public string EntityName {
			get {
				return entityName;
			}
		}
		private readonly string extractedValue;
		public string ExtractedValue {
			get {
				return extractedValue;
			}
		}
		public ExtractedString(string entityName, string extractedValue)
		{
			this.entityName = entityName;
			this.extractedValue = extractedValue;
		}
		
		public override bool Equals(object obj)
		{
			ExtractedString other = obj as ExtractedString;
			if (other == null) {
				return false;
			}
			return this.entityName == other.entityName && this.extractedValue == other.extractedValue;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (entityName != null) {
					hashCode += 1000000007 * entityName.GetHashCode();
				}
				if (extractedValue != null) {
					hashCode += 1000000009 * extractedValue.GetHashCode();
				}
			}
			return hashCode;
		}

		public static bool operator ==(ExtractedString lhs, ExtractedString rhs) {
			if (ReferenceEquals(lhs, rhs)) {
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ExtractedString lhs, ExtractedString rhs) {
			return !(lhs == rhs);
		}
	}
}