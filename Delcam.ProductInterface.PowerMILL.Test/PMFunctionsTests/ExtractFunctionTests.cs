/*
 * Created by SharpDevelop.
 * User: omiku
 * Date: 26/12/2021
 * Time: 11:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.FileSystem;
using Autodesk.Geometry;
using Autodesk.ProductInterface.PowerMILL;
using Autodesk.ProductInterface.PowerMILLTest.Files;
using NUnit.Framework;

namespace Autodesk.ProductInterface.PowerMILLTest
{
	[TestFixture]
	public class ExtractFunctionTests
	{
		private Directory temp;

        private PMAutomation _powerMill;
        private double TOLERANCE = 0.00001;

        [SetUp]
        public void TestFixtureSetup()
        {
            _powerMill = new PMAutomation(InstanceReuse.UseExistingInstance);
            _powerMill.DialogsOff();
            _powerMill.CloseProject();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                _powerMill.CloseProject();
                
                if (temp != null && temp.Exists) {
                	try {
            			temp.Delete();
                	} catch  {
                	}
                }
            }
            catch 
            {
            }
        }

        #region Test properties
        
        [Test]
        public void ReadNCPrograms()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE NCPROGRAM "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadNCPrograms(_powerMill));
        }
        
        [Test]
        public void ReadBoundaries()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE BOUNDARY "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadBoundaries(_powerMill));
        }
        
        [Test]
        public void ReadFeatureGroups()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE FEATUREGROUP "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadFeatureGroups(_powerMill));
        }
        
        [Test]
        public void ReadFeatureSets()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE FEATURESET "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadFeatureSets(_powerMill));
        }
        
        [Test]
        public void ReadGroups()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE GROUP "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadGroups(_powerMill));
        }
        
        [Test]
        public void ReadLevelOrSets()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE LEVEL "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadLevelOrSets(_powerMill));
        }
        
        [Test]
        public void ReadMachineTools()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Machinetool "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadMachineTools(_powerMill));
        }
        
        [Test]
        public void ReadModels()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Model "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadModels(_powerMill));
        }
        
        [Test]
        public void ReadPatterns()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Pattern "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadPatterns(_powerMill));
        }
        
        [Test]
        public void ReadSetups()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Setup "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadSetups(_powerMill));
        }
        
        [Test]
        public void ReadStockModels()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE StockModel "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadStockModels(_powerMill));
        }
        
        [Test]
        public void ReadToolpaths()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("IMPORT TEMPLATE ENTITY TOOLPATH FILEOPEN \"Finishing/Raster-Finishing.002.ptf\"");
        		_powerMill.Execute("RENAME TOOLPATH # \""+element+"\"");
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadToolpaths(_powerMill));
        }
        
        [Test]
        public void ReadTools()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Tool "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadTools(_powerMill));
        }
        
        [Test]
        public void ReadWorkplanes()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Workplane "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadWorkplanes(_powerMill));
        }
        
        [Test]
        public void ExtractIntValue()
        {
        	List<int> expected = new List<int>{1,2,3,4,5};
        	
        	foreach (int element in expected) {
        		_powerMill.Execute("CREATE Tool "+element);
        		_powerMill.Execute("$entity('Tool','').Number.Value = "+element);
        	}
             
        	CollectionAssert.AreEqual(expected.Select(item => item.ToString()), ExtractFunction.ReadTools(_powerMill));
			CollectionAssert.AreEqual(expected, ExtractFunction.ExtractIntValue("Tool","Number.Value",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractIntNotImplemetedValue()
        {
        	_powerMill.Execute("IMPORT TEMPLATE ENTITY TOOLPATH FILEOPEN \"Finishing/Raster-Finishing.002.ptf\"");

			CollectionAssert.IsEmpty(ExtractFunction.ExtractBoolValue("Toolpath","Tool.Number.Value",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractBoolValue()
        {
        	List<string> expectedNames = new List<string>{"1","2","3","4","5"};
        	List<bool> expected = new List<bool>{false,true,false,true,false};
        	
        	foreach (bool element in expected) {
        		_powerMill.Execute("CREATE Tool ;");
        		_powerMill.Execute("$entity('Tool','').IDTracksName = "+element);
        	}
             
        	CollectionAssert.AreEqual(expectedNames, ExtractFunction.ReadTools(_powerMill));
			CollectionAssert.AreEqual(expected, ExtractFunction.ExtractBoolValue("Tool","IDTracksName",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractBoolNotImplemetedValue()
        {
        	_powerMill.Execute("IMPORT TEMPLATE ENTITY TOOLPATH FILEOPEN \"Finishing/Raster-Finishing.002.ptf\"");

			CollectionAssert.IsEmpty(ExtractFunction.ExtractBoolValue("Toolpath","Tool.IDTracksName",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractStringValue()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Tool "+element);
        		_powerMill.Execute("$entity('Tool','').Description = "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadTools(_powerMill));
			CollectionAssert.AreEqual(expected, ExtractFunction.ExtractStringValue("Tool","Description",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractStringNotImplemetedValue()
        {
        	_powerMill.Execute("IMPORT TEMPLATE ENTITY TOOLPATH FILEOPEN \"Finishing/Raster-Finishing.002.ptf\"");

			CollectionAssert.IsEmpty(ExtractFunction.ExtractStringValue("Toolpath","Tool.Name",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractDoubleValue()
        {
        	List<string> expectedNames = new List<string>{"1","2","3","4","5"};
        	List<double> expected = new List<double>{1.1,1.2,1.3,1.4,1.5};
        	
        	foreach (double element in expected) {
        		_powerMill.Execute("CREATE Tool ;");
        		_powerMill.Execute("$entity('Tool','').Length = "+element);
        	}
             
        	CollectionAssert.AreEqual(expectedNames, ExtractFunction.ReadTools(_powerMill));
			CollectionAssert.AreEqual(expected, ExtractFunction.ExtractDoubleValue("Tool","Length",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractDoubleValueAngle()
        {
        	List<string> expected = new List<string>{"1","2","3","4","5"};
        	
        	foreach (string element in expected) {
        		_powerMill.Execute("CREATE Workplane "+element);
        	}
             
        	CollectionAssert.AreEqual(expected, ExtractFunction.ReadWorkplanes(_powerMill));
        	CollectionAssert.AreEqual(Enumerable.Repeat(90.0,5), ExtractFunction.ExtractDoubleValue("Workplane","Elevation",_powerMill).Select(item => item.Item2));
        }
        
        [Test]
        public void ExtractDoubleNotImplemetedValue()
        {
        	_powerMill.Execute("IMPORT TEMPLATE ENTITY TOOLPATH FILEOPEN \"Finishing/Raster-Finishing.002.ptf\"");

			CollectionAssert.IsEmpty(ExtractFunction.ExtractDoubleValue("Toolpath","Tool.Diameter",_powerMill).Select(item => item.Item2));
        }
        
        [Test,Explicit]
        public void ExtractFromAnMegaHugeProject()
        {
        	//PowerMill console output is cutting the results after [437] line. This test is asserting whether the API is returning full list.

			temp = Directory.CreateTemporaryDirectory(false);
    		System.IO.Compression.ZipFile.ExtractToDirectory(TestFiles.MegaPmProjectZip.Path,temp.Path);
    		_powerMill.LoadProject(temp.Directories.First());
        		
        	CollectionAssert.AreEqual(Enumerable.Range(0,500).Select(item => item.ToString()), ExtractFunction.ReadToolpaths(_powerMill));
			CollectionAssert.AreEqual(Enumerable.Range(0,500).Select(item => item.ToString()), ExtractFunction.ExtractStringValue("Toolpath","Tool.Name",_powerMill).Select(item => item.Item2));
        }
        
        void CreateHoles()
		{
			_powerMill.Execute("EDIT PATTERN ; CURVEEDITOR START");
			_powerMill.Execute("CURVEEDITOR MODE CIRCLE");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"1.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 0 0 0");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"2.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 10 0 0");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"3.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 20 0 0");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"4.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 30 0 0");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"5.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 40 0 0");
			_powerMill.Execute("CURVEEDITOR CIRCLE RADIUS \"6.1\"");
			_powerMill.Execute("MODE COORDINPUT COORDINATES 50 0 0");
			_powerMill.Execute("CURVEEDITOR MODE DEFAULT");
			_powerMill.Execute("CURVEEDITOR FINISH ACCEPT");
			_powerMill.Execute("EDIT FEATURECREATE TYPE HOLE EDIT FEATURECREATE CIRCULAR ON EDIT FEATURECREATE FILTER HOLES EDIT FEATURECREATE TOPDEFINE ABSOLUTE EDIT FEATURECREATE BOTTOMDEFINE ABSOLUTE FORM CANCEL FEATURE FORM CREATEHOLE");
			_powerMill.Execute("EDIT FEATURECREATE FILTER CURVES EDIT FEATURECREATE TOPDEFINE ABSOLUTE EDIT FEATURECREATE BOTTOMDEFINE ABSOLUTE");
			_powerMill.Execute("EDIT FEATURECREATE TOPDEFINE ABSOLUTE");
			_powerMill.Execute("EDIT FEATURECREATE BOTTOMDEFINE ABSOLUTE");
			_powerMill.Execute("EDIT FEATURECREATE TOP \"0\"");
			_powerMill.Execute("EDIT FEATURECREATE BOTTOM \"-10\"");
			_powerMill.Execute("EDIT FEATURECREATE HOLES EDITONAPPLY YES");
			_powerMill.Execute("EDIT FEATURECREATE HOLES EDITONAPPLY NO");
			_powerMill.Execute("EDIT FEATURECREATE CREATEHOLES");
			_powerMill.Execute("EDIT OPTIONS CLOSETOL \"0.001\"");
			_powerMill.Execute("EDIT PATTERN \"1\" SELECT ALL");
			_powerMill.Execute("EDIT FEATURECREATE CREATEHOLES");
			_powerMill.Execute("FORM CANCEL CREATEHOLE");
		}
        
        [Test]
        public void ExtractDoubleValueFromComponents()
        {
			 CreateHoles();

			_powerMill.ActiveProject.Refresh();
             
			CollectionAssert.AreEqual(new List<double>{2.2,4.2,6.2,8.2,10.2,12.2}, ExtractFunction.ExtractDoubleValueFromComponets(_powerMill.ActiveProject.FeatureSets.First(),"Diameter",_powerMill).Select(item => Math.Round( item.Item2,2)));
        }
        
        //[Test]
        public void ExtractIntValueFromComponents()
        {
			 CreateHoles();

			_powerMill.ActiveProject.Refresh();
             
			//TODO:
        }
        
        //[Test]
        public void ExtractBoolValueFromComponents()
        {
			 CreateHoles();

			_powerMill.ActiveProject.Refresh();
             
			//TODO:
        }
        
        [Test]
        public void ExtractStringValueFromComponents()
        {
			 CreateHoles();

			_powerMill.ActiveProject.Refresh();
             
			CollectionAssert.AreEqual(new List<string>{"hole","hole","hole","hole","hole","hole"}, ExtractFunction.ExtractStringValueFromComponets(_powerMill.ActiveProject.FeatureSets.First(),"Type",_powerMill).Select(item => item.Item2));
        }
        
        #endregion
        
	}
}
