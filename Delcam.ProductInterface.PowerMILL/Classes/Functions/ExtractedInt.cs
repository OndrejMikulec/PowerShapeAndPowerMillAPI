namespace Autodesk.ProductInterface.PowerMILL
{
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
	}
}