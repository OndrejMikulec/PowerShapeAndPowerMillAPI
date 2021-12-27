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
    public class PMToolpathsCollectionTest
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
        public void ActiveItemTest()
        {
            _powerMILL.LoadProject(TestFiles.PMwithNcProgram);
            var toolpath = _powerMILL.ActiveProject.Toolpaths["Rough-U_1"];
            toolpath.IsActive = true;
            var activeToolpath = _powerMILL.ActiveProject.Toolpaths.ActiveItem;
            Assert.AreEqual(toolpath.Name, activeToolpath.Name);
        }

        [Test]
        public void NoActiveItemTest()
        {
            _powerMILL.LoadProject(TestFiles.PMwithNcProgram);
            var toolpath = _powerMILL.ActiveProject.Toolpaths["Rough-U_1"];
            toolpath.IsActive = false;
            var activeToolpath = _powerMILL.ActiveProject.Toolpaths.ActiveItem;

            Assert.AreEqual(toolpath.IsActive, false);
            Assert.AreEqual(activeToolpath, null);
        }

        [Test]
        public void Create3DOffsetFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.Create3DOffsetFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateAdaptiveAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateAdaptiveAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRibMachiningToolpathTest()
        {
            if (_powerMILL.Version.Major >= PMEntity.POWER_MILL_2016.Major)
            {
                var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRibMachiningToolpath();
                Assert.AreEqual("1", toolpath.Name);
            }
            else
            {
                try
                {
                    var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRibMachiningToolpath();
                    Assert.Fail("Exception wasn't thrown");
                }
                catch (Exception)
                {
                    Assert.Pass();
                }
            }
        }

        [Test]
        public void CreateBladeMachiningToolpathTest()
        {
            if (_powerMILL.Version.Major >= PMEntity.POWER_MILL_2016.Major)
            {
                var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateBladeMachiningToolpath();
                Assert.AreEqual("1", toolpath.Name);
            }
            else
            {
                try
                {
                    var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateBladeMachiningToolpath();
                    Assert.Fail("Exception wasn't thrown");
                }
                catch (Exception)
                {
                    Assert.Pass();
                }
            }
        }

        [Test]
        public void CreateAlongCornerFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateAlongCornerFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateBladeFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateBladeFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateBliskAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateBliskAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateChamferMillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateChamferMillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateConstantZFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateConstantZFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateCornerClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCornerClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateCornerFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCornerFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateCurveAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCurveAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateCurveProfileToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCurveProfileToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateCurveProjectionFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCurveProjectionFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateDiscProfileFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateDiscProfileFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateBreakChipDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateBreakChipDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.BreakChip, toolpath.CycleType);
        }

        [Test]
        public void CreateCounterBoreDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateCounterBoreDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.CounterBore, toolpath.CycleType);
        }

        [Test]
        public void CreateDeepDrillDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateDeepDrillDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.DeepDrill, toolpath.CycleType);
        }

        [Test]
        public void CreateDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateExternalThreadDrillingToolpathTest()
        {
            if (_powerMILL.Version.Major > PMEntity.POWER_MILL_2016.Major)
            {
                Console.WriteLine(@"External drill moved to Feature external drill");
                return;
            }
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateExternalThreadDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.ExternalThread, toolpath.CycleType);
        }

        [Test]
        public void CreateFineBoringDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateFineBoringDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.FineBoring, toolpath.CycleType);
        }

        [Test]
        public void CreateHelicalDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateHelicalDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.Helical, toolpath.CycleType);
        }

        [Test]
        public void CreateProfileDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateProfileDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.Profile, toolpath.CycleType);
        }

        [Test]
        public void CreateReamDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateReamDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.Ream, toolpath.CycleType);
        }

        [Test]
        public void CreateRigidTappingDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRigidTappingDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.RigidTapping, toolpath.CycleType);
        }

        [Test]
        public void CreateSinglePeckDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateSinglePeckDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.SinglePeck, toolpath.CycleType);
        }

        [Test]
        public void CreateTapDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateTapDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.Tap, toolpath.CycleType);
        }

        [Test]
        public void CreateThreadMillDrillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateThreadMillDrillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
            Assert.AreEqual(DrillCycleTypes.ThreadMill, toolpath.CycleType);
        }

        [Test]
        public void CreateEmbeddedPatternFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateEmbeddedPatternFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateFaceMillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateFaceMillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateFlowlineFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateFlowlineFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateHubFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateHubFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateLineProjectionFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateLineProjectionFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateMultiPencilCornerFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateMultiPencilCornerFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateOffsetAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateOffsetAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateOffsetFlatFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateOffsetFlatFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateOptimisedConstantZFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateOptimisedConstantZFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateParametricOffsetFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateParametricOffsetFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateParametricSpiralFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateParametricSpiralFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePatternFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePatternFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePencilCornerFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePencilCornerFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePlaneProjectionFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePlaneProjectionFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePlungeMillingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePlungeMillingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePointProjectionFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePointProjectionFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePortAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePortAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreatePortSpiralFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreatePortSpiralFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateProfileAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateProfileAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateProfileFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateProfileFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRadialFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRadialFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRasterAreaClearanceToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRasterAreaClearanceToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRasterFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRasterFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRasterFlatFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRasterFlatFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateRotaryFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateRotaryFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateSpiralFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateSpiralFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateSteepAndShallowFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateSteepAndShallowFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateStitchCornerFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateStitchCornerFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateSurfaceFinishingToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateSurfaceFinishingToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateSwarfMachiningToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateSwarfMachiningToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateWireframeProfileMachiningToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateWireframeProfileMachiningToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void CreateWireframeSwarfMachiningToolpathTest()
        {
            var toolpath = _powerMILL.ActiveProject.Toolpaths.CreateWireframeSwarfMachiningToolpath();
            Assert.AreEqual("1", toolpath.Name);
        }

        [Test]
        public void GetNewEntityNameTest()
        {
            //No entity exists, should return "1" and "NewName"
            Assert.That(_powerMILL.ActiveProject.Toolpaths.GetNewEntityName(), Is.EqualTo("1"));
            Assert.That(_powerMILL.ActiveProject.Toolpaths.GetNewEntityName("NewName"), Is.EqualTo("NewName"));

            //Create a new entity
            var toolpath = _powerMILL.ActiveProject.Toolpaths.Create3DOffsetFinishingToolpath();

            //1 entity exists, should return "2"
            Assert.That(_powerMILL.ActiveProject.Toolpaths.GetNewEntityName(), Is.EqualTo("2"));

            //Rename the entity
            toolpath.Name = "MyPrefix";

            //1 entity called "MyPrefix" exists, should return "NewName" and "MyPrefix_1"
            Assert.That(_powerMILL.ActiveProject.Toolpaths.GetNewEntityName("NewName"), Is.EqualTo("NewName"));
            Assert.That(_powerMILL.ActiveProject.Toolpaths.GetNewEntityName("MyPrefix"), Is.EqualTo("MyPrefix_1"));

            //Delete the entity
            _powerMILL.ActiveProject.Toolpaths.Remove(toolpath);
        }
        
        [Test]
        public void ExtractBool()
        {
//        	bool alpha = true;
//        	bool brava = true;
//        	bool delta = false;
//        	bool charlie = true;
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);
        	
        	List<Tuple<PMToolpath,bool>> isCalculated = _powerMILL.ActiveProject.Toolpaths.ExtractBool("Computed");
			
			Assert.IsNotNull( isCalculated.FirstOrDefault(item => item.Item1.Name == "alpha"));
			Assert.IsNotNull( isCalculated.FirstOrDefault(item => item.Item1.Name == "brava"));
			Assert.IsNotNull( isCalculated.FirstOrDefault(item => item.Item1.Name == "delta"));
			Assert.IsNotNull( isCalculated.FirstOrDefault(item => item.Item1.Name == "charlie"));
			
			foreach (Tuple<PMToolpath,bool> element in isCalculated) {
				if (element.Item1.Name == "delta") {
					Assert.AreEqual(element.Item2, false);
				} else {
					Assert.AreEqual(element.Item2, true);
				}
			}
			
			List<PMToolpath> expected = new List<PMToolpath> {
				_powerMILL.ActiveProject.Toolpaths.First(item => item.Name == "alpha"),
				_powerMILL.ActiveProject.Toolpaths.First(item => item.Name == "brava"),
				_powerMILL.ActiveProject.Toolpaths.First(item => item.Name == "charlie"),
			};
        	
            List<PMToolpath> isCalculated2 = _powerMILL.ActiveProject.Toolpaths.ExtractBool("Computed",true);
			
			CollectionAssert.AreEqual(expected, isCalculated2);
        }
        
        [Test]
        public void ExtractDouble()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);
        	
        	_powerMILL.Execute("$entity('Toolpath','delta').Stepover = 0.3");

        	
        	List<Tuple<PMToolpath,double>> extracted = _powerMILL.ActiveProject.Toolpaths.ExtractDouble("Stepover");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "alpha"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "brava"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "delta"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "charlie"));
			
			CollectionAssert.AreEqual(new List<double>{1.0,1.0,0.3,1.0},extracted.Select(item => item.Item2));

        }
        
        [Test]
        public void ExtractInt()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);

        	List<Tuple<PMToolpath,int>> extracted = _powerMILL.ActiveProject.Toolpaths.ExtractInt("Tool.number.Value");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "alpha"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "brava"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "delta"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "charlie"));
			
			CollectionAssert.AreEqual(new List<int>{2,2,2,0},extracted.Select(item => item.Item2));

        }
        
        [Test]
        public void ExtractString()
        {
        	
        	_powerMILL.LoadProject(TestFiles.SimplePmProject1);

        	List<Tuple<PMToolpath,string>> extracted = _powerMILL.ActiveProject.Toolpaths.ExtractString("Tool.Name");
			
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "alpha"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "brava"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "delta"));
			Assert.IsNotNull( extracted.FirstOrDefault(item => item.Item1.Name == "charlie"));
			
			CollectionAssert.AreEqual(new List<string>{"12 ball","12 ball","12 ball","10+1.6 tiprad"},extracted.Select(item => item.Item2));

        }
    }
}