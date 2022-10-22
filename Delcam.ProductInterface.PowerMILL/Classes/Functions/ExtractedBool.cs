namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Equality overrides!
	/// </summary>
	public class ExtractedBool
	{
		private readonly string entityName;
		public string EntityName {
			get {
				return entityName;
			}
		}
		private readonly bool extractedValue;
		public bool ExtractedValue {
			get {
				return extractedValue;
			}
		}

		public ExtractedBool(string entityName, bool extractedValue)
		{
			this.entityName = entityName;
			this.extractedValue = extractedValue;
		}
		
		public override bool Equals(object obj)
		{
			ExtractedBool other = obj as ExtractedBool;
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
				hashCode += 1000000009 * extractedValue.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(ExtractedBool lhs, ExtractedBool rhs) {
			if (ReferenceEquals(lhs, rhs)) {
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ExtractedBool lhs, ExtractedBool rhs) {
			return !(lhs == rhs);
		}
	}
}