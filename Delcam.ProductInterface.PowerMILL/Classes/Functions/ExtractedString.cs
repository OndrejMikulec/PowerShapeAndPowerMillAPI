namespace Autodesk.ProductInterface.PowerMILL
{
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
	}
}