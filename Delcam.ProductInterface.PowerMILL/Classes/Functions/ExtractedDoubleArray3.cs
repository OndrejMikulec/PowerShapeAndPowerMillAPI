using System.Linq;
namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Equality overrides!
	/// </summary>
	public class ExtractedDoubleArray3
	{
		private readonly string entityName;
		public string EntityName {
			get {
				return entityName;
			}
		}
		private readonly double[] extractedValue;
		public double[] ExtractedValue {
			get {
				return extractedValue;
			}
		}

		public ExtractedDoubleArray3(string entityName, double[] extractedValue)
		{
			this.entityName = entityName;
			this.extractedValue = extractedValue;
		}

		public override bool Equals(object obj)
		{
			ExtractedDoubleArray3 other = obj as ExtractedDoubleArray3;
			if (other == null) {
				return false;
			}
			return this.entityName == other.entityName && this.extractedValue.ToList().SequenceEqual(other.extractedValue);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (entityName != null) {
					hashCode += 1000000007 * entityName.GetHashCode();
				}
				if (extractedValue != null) {
					hashCode += 1000000009 * extractedValue.Sum(item => item.GetHashCode());
				}
			}
			return hashCode;
		}

		public static bool operator ==(ExtractedDoubleArray3 lhs, ExtractedDoubleArray3 rhs) {
			if (ReferenceEquals(lhs, rhs)) {
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ExtractedDoubleArray3 lhs, ExtractedDoubleArray3 rhs) {
			return !(lhs == rhs);
		}
	}
}