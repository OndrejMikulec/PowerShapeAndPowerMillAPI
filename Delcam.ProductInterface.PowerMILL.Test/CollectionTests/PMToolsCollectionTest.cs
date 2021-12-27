// **********************************************************************
// *         © COPYRIGHT 2018 Autodesk, Inc.All Rights Reserved         *
// *                                                                    *
// *  Use of this software is subject to the terms of the Autodesk      *
// *  license agreement provided at the time of installation            *
// *  or download, or which otherwise accompanies this software         *
// *  in either electronic or hard copy form.                           *
// **********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.ProductInterface.PowerMILL;
using Autodesk.ProductInterface.PowerMILLTest.Files;
using NUnit.Framework;

namespace Autodesk.ProductInterface.PowerMILLTest.CollectionTests
{
    [TestFixture]
    public class PMToolsCollectionTest
    {
        private PMAutomation _powerMILL;

        [SetUp]
        public void TestFixtureSetup()
        {
            _powerMILL = new PMAutomation(InstanceReuse.UseExistingInstance);
            _powerMILL.DialogsOff();
            _powerMILL.CloseProject();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                _powerMILL.CloseProject();
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void CreateBallNoseToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateBallNosedTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateBarrelToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateBarrelTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateDovetailToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateDovetailTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateDrillToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateDrillTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateEndMillToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateEndMillTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateFormToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateFormTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateOffCentreTipRadiusedToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateOffCentreTipRadiusedTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRoutingToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateRoutingTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateTapToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateTapTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateTaperedSphericalToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateTaperedSphericalTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateTaperedTippedToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateTaperedTippedTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateThreadMillToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateThreadMillTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateTippedDiscToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateTippedDiscTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateTipRadiusedToolTest()
        {
            var toolpath = _powerMILL.ActiveProject.Tools.CreateTipRadiusedTool();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void GetNewEntityNameTest()
        {
            //No entity exists, should return "1" and "NewName"
            Assert.That(_powerMILL.ActiveProject.Tools.GetNewEntityName(), Is.EqualTo("1"));
            Assert.That(_powerMILL.ActiveProject.Tools.GetNewEntityName("NewName"), Is.EqualTo("NewName"));

            //Create a new entity
            var tool = _powerMILL.ActiveProject.Tools.CreateBallNosedTool();

            //1 entity exists, should return "2"
            Assert.That(_powerMILL.ActiveProject.Tools.GetNewEntityName(), Is.EqualTo("2"));

            //Rename the entity
            tool.Name = "MyPrefix";

            //1 entity called "MyPrefix" exists, should return "NewName" and "MyPrefix_1"
            Assert.That(_powerMILL.ActiveProject.Tools.GetNewEntityName("NewName"), Is.EqualTo("NewName"));
            Assert.That(_powerMILL.ActiveProject.Tools.GetNewEntityName("MyPrefix"), Is.EqualTo("MyPrefix_1"));

            //Delete the entity
            _powerMILL.ActiveProject.Tools.Remove(tool);
        }
        
                [Test]
        public void ExtractBool()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);
        	
        	List<Tuple<PMTool,bool>> extracted = _powerMILL.ActiveProject.Tools.ExtractBool("Number.UserDefined");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "12 ball"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "10+1.6 tiprad"));
			
			foreach (Tuple<PMTool,bool> element in extracted) {
				if (element.Item1.Name == "12 ball") {
					Assert.AreEqual(element.Item2, true);
				} else {
					Assert.AreEqual(element.Item2, false);
				}
			}
			
			List<PMTool> expected = new List<PMTool> {
				_powerMILL.ActiveProject.Tools.First(item => item.Name == "12 ball")
			};
        	
            List<PMTool> isCalculated2 = _powerMILL.ActiveProject.Tools.ExtractBool("Number.UserDefined",true);
			
			CollectionAssert.AreEqual(expected, isCalculated2);
        }
        
        [Test]
        public void ExtractDouble()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);
        	
        	List<Tuple<PMTool,double>> extracted = _powerMILL.ActiveProject.Tools.ExtractDouble("Diameter");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "12 ball"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "10+1.6 tiprad"));
			
			CollectionAssert.AreEqual(new List<double>{12.0,10.0},extracted.Select(item => item.Item2));

        }
        
        [Test]
        public void ExtractInt()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);

        	List<Tuple<PMTool,int>> extracted = _powerMILL.ActiveProject.Tools.ExtractInt("Number.Value");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "12 ball"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "10+1.6 tiprad"));
			
			CollectionAssert.AreEqual(new List<int>{2,0},extracted.Select(item => item.Item2));

        }
        
        [Test]
        public void ExtractString()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);

        	List<Tuple<PMTool,string>> extracted = _powerMILL.ActiveProject.Tools.ExtractString("Tool.Type");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "12 ball"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "10+1.6 tiprad"));
			
			CollectionAssert.AreEqual(new List<string>{"ball_nosed","tip_radiused"},extracted.Select(item => item.Item2));

        }
    }
}