namespace Autodesk.ProductInterface.PowerMILL
{
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
	}
}