namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Equality overrides!
	/// </summary>
	public class ExtractedInt
	{
		private readonly string entityName;
		public string EntityName {
			get {
				return entityName;
			}
		}
		private readonly int extractedValue;
		public int ExtractedValue {
			get {
				return extractedValue;
			}
		}

		public ExtractedInt(string entityName, int extractedValue)
		{
			this.entityName = entityName;
			this.extractedValue = extractedValue;
		}
		
		public override bool Equals(object obj)
		{
			ExtractedInt other = obj as ExtractedInt;
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

		public static bool operator ==(ExtractedInt lhs, ExtractedInt rhs) {
			if (ReferenceEquals(lhs, rhs)) {
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ExtractedInt lhs, ExtractedInt rhs) {
			return !(lhs == rhs);
		}
	}
}