namespace Autodesk.ProductInterface.PowerMILL
{
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
	}
}