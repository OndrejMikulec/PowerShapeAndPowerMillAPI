﻿// **********************************************************************
// *         © COPYRIGHT 2018 Autodesk, Inc.All Rights Reserved         *
// *                                                                    *
// *  Use of this software is subject to the terms of the Autodesk      *
// *  license agreement provided at the time of installation            *
// *  or download, or which otherwise accompanies this software         *
// *  in either electronic or hard copy form.                           *
// **********************************************************************

using System;
using System.Linq;
using Autodesk.ProductInterface.PowerMILL;
using NUnit.Framework;

namespace Autodesk.ProductInterface.PowerMILLTest.PMEntityTests
{
    [TestFixture]
    public class PMFeatureGroupTests
    {
        private PMAutomation _powerMill;

        [SetUp]
        public void TestFixtureSetup()
        {
            _powerMill = new PMAutomation(InstanceReuse.UseExistingInstance);
            _powerMill.DialogsOff();
            _powerMill.CloseProject();
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
                _powerMill.CloseProject();
            }
            catch (Exception)
            {
            }
        }


        #region Test properties

        #endregion


        #region Test operations

        [Test]
        public void DrawAndUndrawAllFeatureGroupsTest()
        {      
            _powerMill.ActiveProject.FeatureGroups.CreateFeaturegroup("Test FeatureGroup 1");
            _powerMill.ActiveProject.FeatureGroups.CreateFeaturegroup("Test FeatureGroup 2");
            _powerMill.ActiveProject.FeatureGroups.DrawAll();
            _powerMill.ActiveProject.FeatureGroups.UndrawAll();
            Assert.IsTrue(true);
        }

        #endregion

    }
}
