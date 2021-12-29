/*
 * Created by SharpDevelop.
 * User: omiku
 * Date: 25/12/2021
 * Time: 7:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.ProductInterface.PowerMILL;

namespace Autodesk.ProductInterface.PowerMILL
{
	/// <summary>
	/// Description of ExtractFunction.
	/// </summary>
	public static class ExtractFunction
	{
		private enum eExtractionType {FROM_FOLDER,FROM_ENTITY_COMPONENTS}
		
		public static List<string> ReadNCPrograms(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("NCProgram",powerMILL);
		}
		public static List<string> ReadBoundaries(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Boundary",powerMILL);
		}
		public static List<string> ReadFeatureGroups(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("FeatureGroup",powerMILL);
		}
		public static List<string> ReadFeatureSets(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Featureset",powerMILL);
		}
		public static List<string> ReadGroups(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Group",powerMILL);
		}
		public static List<string> ReadLevelOrSets(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Level",powerMILL);
		}
		public static List<string> ReadMachineTools(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Machinetool",powerMILL);
		}
		public static List<string> ReadModels(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Model",powerMILL);
		}
		public static List<string> ReadPatterns(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Pattern",powerMILL);
		}
		public static List<string> ReadSetups(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Setup",powerMILL);
		}
		public static List<string> ReadStockModels(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("StockModel",powerMILL);
		}
		public static List<string> ReadToolpaths(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Toolpath",powerMILL);
		}
		public static List<string> ReadTools(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Tool",powerMILL);
		}
		public static List<string> ReadWorkplanes(PMAutomation powerMILL)
		{
			return GetEntityListCorrectSort("Workplane",powerMILL);
		}

		
		static List<Tuple<int,string>> extracted(string[] pmOutput, string typeTag)
		{
			List<Tuple<int,string>> output = new List<Tuple<int, string>>();
			
			foreach (string element in pmOutput) {
				if (!string.IsNullOrWhiteSpace(element) && element.Contains(" ("+typeTag+") ")) {
					string[] splitted = element.Split(new string[]{" ("+typeTag+") "},StringSplitOptions.None);
					output.Add(new Tuple<int, string>(int.Parse( splitted[0].Replace("[",string.Empty).Replace("]",string.Empty).Trim()),splitted[1]));
				}
			}
			
			return output;
		}
		
		static List<string> GetEntityListCorrectSort(string entityTypeOrFolder, PMAutomation powerMILL )
		{
			string result = powerMILL.DoCommandEx("print par \"extract( folder('"+entityTypeOrFolder+"'), 'name')\"").ToString();
 			
 			string[] resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	

 			if (resultArray == null || resultArray.Length < 1) {
 				return new List<string>();
 			}

 			List<string> output = extracted(resultArray,"STRING").Select(item => item.Item2).ToList();

 			return output;

		}
		/// <summary>
		/// Extracts a double values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		public static List<Tuple<string,double>> ExtractDoubleValue(string entityTypeOrFolder, string valueName, PMAutomation powerMILL)
		{
			return ExtractDoubleValue(eExtractionType.FROM_FOLDER,valueName,entityTypeOrFolder,null,powerMILL);
		}
		
		public static List<Tuple<string,double>> ExtractDoubleValueFromComponets(PMEntity entityWithComponents, string valueName, PMAutomation powerMILL)
		{
			return ExtractDoubleValue(eExtractionType.FROM_ENTITY_COMPONENTS,valueName,null,entityWithComponents,powerMILL);
		}
		
		/// <summary>
		/// Extracts a double values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="extractionType">From a entities folder OR from an entity components</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder - only for extraction from a folder</param>
		/// <param name="entityWithComponents">Entity with components - only for extraction from a entity with components</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		private static List<Tuple<string,double>> ExtractDoubleValue(eExtractionType extractionType, string valueName, string entityTypeOrFolder, PMEntity entityWithComponents, PMAutomation powerMILL)
		{
			
			List<Tuple<string,double>> output = new List<Tuple<string,double>>();
			

			string result = null;
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  folder('"+entityTypeOrFolder+"'), 'name')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), 'name')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			string[] resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	

 			if (resultArray == null || resultArray.Length < 1) {
 				return new List<Tuple<string,double>>();
 			} 			
			
 			List<Tuple<int,string>> outputNames = extracted(resultArray,"STRING");
 			
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(folder('"+entityTypeOrFolder+"'), '"+valueName+"')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), '"+valueName+"')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	
			
 			List<Tuple<int,string>> outputDoubleValue = extracted(resultArray,"REAL");
			outputDoubleValue.AddRange(extracted(resultArray,"ANGLE"));
 			
 			foreach (Tuple<int,string> element in outputNames) {
 				string outputValueName = element.Item2;
 				
 				if (outputDoubleValue.Count(item => item.Item1 == element.Item1) > 0) {
 					double parsed = double.MaxValue;
					string doubleStr = outputDoubleValue.First(item => item.Item1 == element.Item1).Item2;
					if (doubleStr.Length > 4 && doubleStr.Substring(doubleStr.Length-4) == " [L]") {
						doubleStr = doubleStr.Substring(0,doubleStr.Length-4);
					}
 					if (double.TryParse(doubleStr, out parsed)) {
 						output.Add(new Tuple<string, double>(outputValueName,parsed));
 					}
 				}
 			}
	
			return output;
		
		}		
		/// <summary>
		/// Extracts a int values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		public static List<Tuple<string,int>> ExtractIntValue(string entityTypeOrFolder, string valueName, PMAutomation powerMILL)
		{
			return ExtractIntValue(eExtractionType.FROM_FOLDER,valueName,entityTypeOrFolder,null,powerMILL);
		}
		
		public static List<Tuple<string,int>> ExtractIntValueFromComponets(PMEntity entityWithComponents, string valueName, PMAutomation powerMILL)
		{
			return ExtractIntValue(eExtractionType.FROM_ENTITY_COMPONENTS,valueName,null,entityWithComponents,powerMILL);
		}
		
		/// <summary>
		/// Extracts a int values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="extractionType">From a entities folder OR from an entity components</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder - only for extraction from a folder</param>
		/// <param name="entityWithComponents">Entity with components - only for extraction from a entity with components</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		private static List<Tuple<string,int>> ExtractIntValue(eExtractionType extractionType, string valueName, string entityTypeOrFolder, PMEntity entityWithComponents, PMAutomation powerMILL)
		{
			
			List<Tuple<string,int>> output = new List<Tuple<string,int>>();
			

			string result = null;
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  folder('"+entityTypeOrFolder+"'), 'name')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), 'name')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			string[] resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	

 			if (resultArray == null || resultArray.Length < 1) {
 				return new List<Tuple<string,int>>();
 			} 			
			
 			List<Tuple<int,string>> outputNames = extracted(resultArray,"STRING");
 			
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(folder('"+entityTypeOrFolder+"'), '"+valueName+"')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), '"+valueName+"')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	
			
 			List<Tuple<int,string>> outputIntValue = extracted(resultArray,"INT");

 			
 			foreach (Tuple<int,string> element in outputNames) {
 				string outputValueName = element.Item2;
 				
 				if (outputIntValue.Count(item => item.Item1 == element.Item1) > 0) {
 					int parsed = -1;
 					if (int.TryParse(outputIntValue.First(item => item.Item1 == element.Item1).Item2,out parsed)) {
 						output.Add(new Tuple<string, int>(outputValueName,parsed));
 					}
 				}
 			}
	
			return output;
		
		}
		/// <summary>
		/// Extracts a bool values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		public static List<Tuple<string,bool>> ExtractBoolValue(string entityTypeOrFolder, string valueName, PMAutomation powerMILL)
		{
			return ExtractBoolValue(eExtractionType.FROM_FOLDER,valueName,entityTypeOrFolder,null,powerMILL);
		}
		
		public static List<Tuple<string,bool>> ExtractBoolValueFromComponets(PMEntity entityWithComponents, string valueName, PMAutomation powerMILL)
		{
			return ExtractBoolValue(eExtractionType.FROM_ENTITY_COMPONENTS,valueName,null,entityWithComponents,powerMILL);
		}
		/// <summary>
		/// Extracts a bool values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="extractionType">From a entities folder OR from an entity components</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder - only for extraction from a folder</param>
		/// <param name="entityWithComponents">Entity with components - only for extraction from a entity with components</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		private static List<Tuple<string,bool>> ExtractBoolValue(eExtractionType extractionType, string valueName, string entityTypeOrFolder, PMEntity entityWithComponents, PMAutomation powerMILL)
		{
			
			List<Tuple<string,bool>> output = new List<Tuple<string,bool>>();
			

			string result = null;
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  folder('"+entityTypeOrFolder+"'), 'name')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), 'name')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			string[] resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	

 			if (resultArray == null || resultArray.Length < 1) {
 				return new List<Tuple<string,bool>>();
 			} 			
			
 			List<Tuple<int,string>> outputNames = extracted(resultArray,"STRING");
 			
 			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(folder('"+entityTypeOrFolder+"'), '"+valueName+"')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), '"+valueName+"')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	
			
 			List<Tuple<int,string>> outputBoolValue = extracted(resultArray,"BOOL");

 			
 			foreach (Tuple<int,string> element in outputNames) {
 				string outputValueName = element.Item2;
 				
 				if (outputBoolValue.Count(item => item.Item1 == element.Item1) > 0) {
 					int parsed = -1;
 					if (int.TryParse(outputBoolValue.First(item => item.Item1 == element.Item1).Item2,out parsed)) {
 						output.Add(new Tuple<string, bool>(outputValueName,parsed == 1));
 					}
 				}
 			}
	
			return output;
		
		}
		
		/// <summary>
		/// Extracts a string values from a collection. Fast method
		/// A tuple with not implemented variable will be ommited from the list completely!
		/// </summary>
		/// <param name="entityTypeOrFolder">Entity type or PowerMill explorer folder</param>
		/// <param name="valueName">Desired value name</param>
		/// <param name="powerMILL">The base instance to interact with PowerMILL</param>
		/// <returns>Item1: entity name, Item2: desired value</returns>
		public static List<Tuple<string,string>> ExtractStringValue(string entityTypeOrFolder, string valueName, PMAutomation powerMILL)
		{
			return ExtractStringValue(eExtractionType.FROM_FOLDER,valueName,entityTypeOrFolder,null,powerMILL);
		}
		
		public static List<Tuple<string,string>> ExtractStringValueFromComponets(PMEntity entityWithComponents, string valueName, PMAutomation powerMILL)
		{
			return ExtractStringValue(eExtractionType.FROM_ENTITY_COMPONENTS,valueName,null,entityWithComponents,powerMILL);
		}
		
		private static List<Tuple<string,string>> ExtractStringValue(eExtractionType extractionType, string valueName, string entityTypeOrFolder, PMEntity entityWithComponents, PMAutomation powerMILL)
		{
			
			List<Tuple<string,string>> output = new List<Tuple<string,string>>();
			

			string result = null;
			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  folder('"+entityTypeOrFolder+"'), 'name')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), 'name')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			string[] resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	

 			if (resultArray == null || resultArray.Length < 1) {
 				return new List<Tuple<string,string>>();
 			} 			
			
 			List<Tuple<int,string>> outputNames = extracted(resultArray,"STRING");
 			
 			if (extractionType == eExtractionType.FROM_FOLDER ) {
				
				result = powerMILL.DoCommandEx("print par \"extract(folder('"+entityTypeOrFolder+"'), '"+valueName+"')\"").ToString();
				
			} else if (extractionType == eExtractionType.FROM_ENTITY_COMPONENTS) {
				
				result = powerMILL.DoCommandEx("print par \"extract(  components(entity('"+entityWithComponents.Identifier+"','"+entityWithComponents.Name+"')), '"+valueName+"')\"").ToString();
				
			} else {
				throw new Exception();
			}
 			
 			resultArray = result.Split( new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);	
			
 			List<Tuple<int,string>> outputStringValue = extracted(resultArray,"STRING");
 			outputStringValue.AddRange(extracted(resultArray,"ENUM"));
 			
 			foreach (Tuple<int,string> element in outputNames) {
 				string outputValueName = element.Item2;
 				
 				if (outputStringValue.Count(item => item.Item1 == element.Item1) > 0) {

					output.Add(new Tuple<string, string>(outputValueName,outputStringValue.First(item => item.Item1 == element.Item1).Item2));
 					
 				}
 			}
	
			return output;
		
		}
	}
}
