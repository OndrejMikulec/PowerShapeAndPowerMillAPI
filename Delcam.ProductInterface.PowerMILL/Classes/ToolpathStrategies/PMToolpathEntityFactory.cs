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

namespace Autodesk.ProductInterface.PowerMILL
{
    /// <summary>
    /// Represents the toolpath factory
    /// </summary>
    /// <remarks></remarks>
    internal class PMToolpathEntityFactory
    {
    	/// <summary>
        /// Creates a new toolpath based on its strategy.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="name">The new instance name.</param>
        /// <returns>The new tool instance</returns>
        internal static PMToolpath CreateEntity(PMAutomation powerMILL, string name)
        {
        	return CreateEntity(powerMILL, new List<string>{name}).First();
        }
    	
        /// <summary>
        /// Creates a new toolpath based on its strategy.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="names">The new instances names.</param>
        /// <returns>The new tool instance</returns>
        internal static List<PMToolpath> CreateEntity(PMAutomation powerMILL, List<string> names)
        {
        	List<PMToolpath> output = new List<PMToolpath>();
        	
        	List<Tuple<string,string>> extracted = ExtractFunction.ExtractStringValue("toolpath","strategy",powerMILL);
        	
            foreach (Tuple<string,string> element in extracted.Where(item => names.Contains(item.Item1))) {
        		
            	switch (element.Item2)
	            {
	                case "raster":
            			output.Add( new PMToolpathRasterFinishing(powerMILL, element.Item1));
            			break;
	                case "radial":
	                    output.Add( new PMToolpathRadialFinishing(powerMILL, element.Item1));
            			break;
	                case "spiral":
	                    output.Add( new PMToolpathSpiralFinishing(powerMILL, element.Item1));
            			break;
	                case "pattern":
	                    output.Add( new PMToolpathPatternFinishing(powerMILL, element.Item1));
            			break;
	                case "com_pattern":
	                    output.Add( new PMToolpathCommittedPattern(powerMILL, element.Item1));
            			break;
	                case "com_boundary":
	                    output.Add( new PMToolpathCommittedBoundary(powerMILL, element.Item1));
            			break;
	                case "constantz":
	                    output.Add( new PMToolpathConstantZFinishing(powerMILL, element.Item1));
            			break;
	                case "offset_3d":
	                    output.Add( new PMToolpath3DOffsetFinishing(powerMILL, element.Item1));
            			break;
	                case "pencil_corner":
	                    output.Add( new PMToolpathPencilCornerFinishing(powerMILL, element.Item1));
            			break;
	                case "stitch_corner":
	                    output.Add( new PMToolpathStitchCornerFinishing(powerMILL, element.Item1));
            			break;
	                case "automatic_corner":
	                    output.Add( new PMToolpathCornerFinishing(powerMILL, element.Item1));
            			break;
	                case "along_corner":
	                    output.Add( new PMToolpathAlongCornerFinishing(powerMILL, element.Item1));
            			break;
	                case "multi_pencil_corner":
	                    output.Add( new PMToolpathMultiPencilCornerFinishing(powerMILL, element.Item1));
            			break;
	                case "rotary":
	                    output.Add( new PMToolpathRotaryFinishing(powerMILL, element.Item1));
            			break;
	                case "point_projection":
	                    output.Add( new PMToolpathPointProjectionFinishing(powerMILL, element.Item1));
            			break;
	                case "line_projection":
	                    output.Add( new PMToolpathLineProjectionFinishing(powerMILL, element.Item1));
            			break;
	                case "plane_projection":
	                    output.Add( new PMToolpathPlaneProjectionFinishing(powerMILL, element.Item1));
            			break;
	                case "curve_projection":
	                    output.Add( new PMToolpathCurveProjectionFinishing(powerMILL, element.Item1));
            			break;
	                case "profile":
	                    output.Add( new PMToolpathProfileFinishing(powerMILL, element.Item1));
            			break;
	                case "opti_constz":
	                    output.Add( new PMToolpathOptimisedConstantZFinishing(powerMILL, element.Item1));
            			break;
	                case "inter_constz":
	                    output.Add( new PMToolpathSteepAndShallowFinishing(powerMILL, element.Item1));
            			break;
	                case "swarf":
	                    output.Add( new PMToolpathSwarfMachining(powerMILL, element.Item1));
            			break;
	                case "surface_proj":
	                    output.Add( new PMToolpathSurfaceProjectionFinishing(powerMILL, element.Item1));
            			break;
	                case "embedded":
	                    output.Add( new PMToolpathEmbeddedPatternFinishing(powerMILL, element.Item1));
            			break;
	                case "raster_area_clear":
	                    output.Add( new PMToolpathRasterAreaClearance(powerMILL, element.Item1));
            			break;
	                case "offset_area_clear":
	                    output.Add( new PMToolpathOffsetAreaClearance(powerMILL, element.Item1));
            			break;
	                case "profile_area_clear":
	                    output.Add( new PMToolpathProfileAreaClearance(powerMILL, element.Item1));
            			break;
	                case "drill":
	                    output.Add( new PMToolpathDrilling(powerMILL, element.Item1));
            			break;
	                case "wireframe_swarf":
	                    output.Add( new PMToolpathWireframeSwarfMachining(powerMILL, element.Item1));
            			break;
	                case "raster_flat":
	                    output.Add( new PMToolpathRasterFlatFinishing(powerMILL, element.Item1));
            			break;
	                case "offset_flat":
	                    output.Add( new PMToolpathOffsetFlatFinishing(powerMILL, element.Item1));
            			break;
	                case "plunge":
	                    output.Add( new PMToolpathPlungeMilling(powerMILL, element.Item1));
            			break;
	                case "parametric_offset":
	                    output.Add( new PMToolpathParametricOffsetFinishing(powerMILL, element.Item1));
            			break;
	                case "surface_machine":
	                    output.Add( new PMToolpathSurfaceFinishing(powerMILL, element.Item1));
            			break;
	                case "port_area_clear":
	                    output.Add( new PMToolpathPortAreaClearance(powerMILL, element.Item1));
            			break;
	                case "port_plunge":
	                    output.Add( new PMToolpathPortPlungeFinishing(powerMILL, element.Item1));
            			break;
	                case "port_spiral":
	                    output.Add( new PMToolpathPortSpiralFinishing(powerMILL, element.Item1));
            			break;
	                case "method":
	                    output.Add( new PMToolpathMethod(powerMILL, element.Item1));
            			break;
	                case "blisk":
	                    output.Add( new PMToolpathBliskAreaClearance(powerMILL, element.Item1));
            			break;
	                case "blisk_hub":
	                    output.Add( new PMToolpathHubFinishing(powerMILL, element.Item1));
            			break;
	                case "blisk_blade":
	                    output.Add( new PMToolpathBladeFinishing(powerMILL, element.Item1));
            			break;
	                case "disc_profile":
	                    output.Add( new PMToolpathDiscProfileFinishing(powerMILL, element.Item1));
            			break;
	                case "curve_profile":
	                    output.Add( new PMToolpathCurveProfile(powerMILL, element.Item1));
            			break;
	                case "curve_area_clear":
	                    output.Add( new PMToolpathCurveAreaClearance(powerMILL, element.Item1));
            			break;
	                case "face":
	                    output.Add( new PMToolpathFaceMilling(powerMILL, element.Item1));
            			break;
	                case "chamfer":
	                    output.Add( new PMToolpathChamferMilling(powerMILL, element.Item1));
            			break;
	                case "wireframe_profile":
	                    output.Add( new PMToolpathWireframeProfileMachining(powerMILL, element.Item1));
            			break;
	                case "corner_clear":
	                    output.Add( new PMToolpathCornerClearance(powerMILL, element.Item1));
            			break;
	                case "edge_break":
	                    output.Add( new PMToolpathEdgeBreak(powerMILL, element.Item1));
            			break;
	                case "flowline":
	                    output.Add( new PMToolpathFlowlineFinishing(powerMILL, element.Item1));
            			break;
	                case "parametric_spiral":
	                    output.Add( new PMToolpathParametricSpiralFinishing(powerMILL, element.Item1));
            			break;
	                case "adaptive_area_clear":
	                    output.Add( new PMToolpathAdaptiveAreaClearance(powerMILL, element.Item1));
            			break;
	                case "rib":
	                    output.Add( new PMToolpathRibMachining(powerMILL, element.Item1));
            			break;
	                case "blade":
	                    output.Add( new PMToolpathBladeMachining(powerMILL, element.Item1));
            			break;
	                case "feature_face":
	                    output.Add( new PMToolpathFeatureFaceMachining(powerMILL, element.Item1));
            			break;
	                case "feature_chamfer":
	                    output.Add( new PMToolpathFeatureChamferMachining(powerMILL, element.Item1));
            			break;
	                default:
	                    output.Add( new PMToolpath(powerMILL, element.Item1));
            			break;
	            }
            }
        	
        	return output;
        }
    }
}