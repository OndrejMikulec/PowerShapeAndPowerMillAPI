/*
 * Created by SharpDevelop.
 * User: omiku
 * Date: 25/12/2021
 * Time: 7:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Autodesk.ProductInterface;
using Autodesk.ProductInterface.PowerMILL;
using System.Linq;

namespace MyPowerMillTEST
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<object> pms = PMAutomation.GetListOfPmComObjects();
			
			PMAutomation app = new PMAutomation(pms.FirstOrDefault());
			
			if (app != null) {
				foreach (PMNCProgram element in app.ActiveProject.NCPrograms) {
					Console.WriteLine(element.Name);
				}
				foreach (PMBoundary element in app.ActiveProject.Boundaries) {
					Console.WriteLine(element.Name);
				}
				foreach (PMFeatureGroup element in app.ActiveProject.FeatureGroups) {
					Console.WriteLine(element.Name);
				}
				foreach (PMFeatureSet element in app.ActiveProject.FeatureSets) {
					Console.WriteLine(element.Name);
				}
				foreach (PMGroup element in app.ActiveProject.Groups) {
					Console.WriteLine(element.Name);
				}
				foreach (PMLevelOrSet element in app.ActiveProject.LevelsAndSets) {
					Console.WriteLine(element.Name);
				}
				foreach (PMMachineTool element in app.ActiveProject.MachineTools) {
					Console.WriteLine(element.Name);
				}
				foreach (PMModel element in app.ActiveProject.Models) {
					Console.WriteLine(element.Name);
				}
				foreach (PMPattern element in app.ActiveProject.Patterns) {
					Console.WriteLine(element.Name);
				}
				foreach (PMSetup element in app.ActiveProject.Setups) {
					Console.WriteLine(element.Name);
				}
				foreach (PMStockModel element in app.ActiveProject.StockModels) {
					Console.WriteLine(element.Name);
				}
				foreach (PMToolpath element in app.ActiveProject.Toolpaths) {
					Console.WriteLine(element.Name);
				}
				foreach (PMTool element in app.ActiveProject.Tools) {
					Console.WriteLine(element.Name);
				}
				foreach (PMWorkplane element in app.ActiveProject.Workplanes) {
					Console.WriteLine(element.Name);
				}
				
				
				
				foreach (Tuple<PMToolpath,bool> element in app.ActiveProject.Toolpaths.ExtractBool("Computed")) {
					Console.WriteLine(element.Item2);
				}
				
				
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}