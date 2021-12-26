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
using Autodesk.Geometry;
using Autodesk.ProductInterface.PowerMILL;
using Autodesk.ProductInterface.PowerMILLTest.Files;
using NUnit.Framework;

namespace Autodesk.ProductInterface.PowerMILLTest
{
	[TestFixture]
	public class ExtractFunctionTests
	{
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
            }
            catch (Exception)
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
        
        #endregion
        
	}
}
