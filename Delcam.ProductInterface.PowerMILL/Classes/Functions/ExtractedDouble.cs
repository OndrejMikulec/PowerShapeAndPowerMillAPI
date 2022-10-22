namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Equality overrides!
	/// </summary>
	public class ExtractedDouble
	{
		private readonly string entityName;
		public string EntityName {
			get {
				return entityName;
			}
		}
		private readonly double extractedValue;
		public double ExtractedValue {
			get {
				return extractedValue;
			}
		}

		public ExtractedDouble(string entityName, double extractedValue)
		{
			this.entityName = entityName;
			this.extractedValue = extractedValue;
		}
		
		public override bool Equals(object obj)
		{
			ExtractedDouble other = obj as ExtractedDouble;
			if (other == null) {
				return false;
			}
			return this.entityName == other.entityName && object.Equals(this.extractedValue, other.extractedValue);
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

		public static bool operator ==(ExtractedDouble lhs, ExtractedDouble rhs) {
			if (ReferenceEquals(lhs, rhs)) {
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ExtractedDouble lhs, ExtractedDouble rhs) {
			return !(lhs == rhs);
		}
	}
}