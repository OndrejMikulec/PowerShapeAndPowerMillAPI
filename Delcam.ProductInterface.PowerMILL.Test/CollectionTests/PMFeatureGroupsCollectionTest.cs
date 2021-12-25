﻿// **********************************************************************
// *         © COPYRIGHT 2018 Autodesk, Inc.All Rights Reserved         *
// *                                                                    *
// *  Use of this software is subject to the terms of the Autodesk      *
// *  license agreement provided at the time of installation            *
// *  or download, or which otherwise accompanies this software         *
// *  in either electronic or hard copy form.                           *
// **********************************************************************

using Autodesk.ProductInterface.PowerMILL;
using Autodesk.ProductInterface.PowerMILLTest.Files;
using NUnit.Framework;

namespace Autodesk.ProductInterface.PowerMILLTest.CollectionTests
{
    [TestFixture]
    public class PMFeatureGroupsCollectionTest
    {
        private PMAutomation _powerMill;

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
            _powerMill.Reset();
        }

        [Test]
        public void CollectionInitialisationTest()
        {
            if (_powerMill.Version.Major >= 2018)
            {
                var activeProject = _powerMill.LoadProject(TestFiles.FeatureGroupsProject);
                Assert.That(activeProject.FeatureGroups.Count, Is.EqualTo(2));
            }
            else
            {
                var activeProject = _powerMill.LoadProject(TestFiles.SimplePmProject1);
                Assert.That(activeProject.FeatureGroups.Count, Is.EqualTo(0));
            }
        }
    }
}