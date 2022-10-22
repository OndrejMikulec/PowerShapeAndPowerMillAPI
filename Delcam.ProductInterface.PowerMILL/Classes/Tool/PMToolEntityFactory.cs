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
    /// Represents the factory for tools.
    /// </summary>
    internal class PMToolEntityFactory
    {
    	/// <summary>
        /// Creates a new tool based on its type.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="name">The new instance name.</param>
        /// <returns>The new tool instance</returns>
        internal static PMTool CreateEntity(PMAutomation powerMILL, string name)
        {
        	return CreateEntity(powerMILL, new List<string>{name}).First();
        }
    	
        /// <summary>
        /// Creates a new tool based on its type.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="names">The new instances names.</param>
        /// <returns>The new tool instance</returns>
        internal static List<PMTool> CreateEntity(PMAutomation powerMILL, List<string> names)
        {
        	List<PMTool> output = new List<PMTool>();
        	
            List<ExtractedString> extracted = ExtractFunction.ExtractStringValue("tool","type",powerMILL);
            
            foreach (ExtractedString element in extracted.Where(item => names.Contains(item.EntityName))) {
                     	
            	switch (element.ExtractedValue)
	            {
	                case "end_mill":
            			output.Add( new PMToolEndMill(powerMILL, element.EntityName));
            			break;
	                case "ball_nosed":
            			output.Add( new PMToolBallNosed(powerMILL, element.EntityName));
            			break;
	                case "tip_radiused":
            			output.Add( new PMToolTipRadiused(powerMILL, element.EntityName));
            			break;
	                case "taper_spherical":
            			output.Add( new PMToolTaperedSpherical(powerMILL, element.EntityName));
            			break;
	                case "taper_tipped":
            			output.Add( new PMToolTaperedTipped(powerMILL, element.EntityName));
            			break;
	                case "drill":
            			output.Add( new PMToolDrill(powerMILL, element.EntityName));
            			break;
	                case "tipped_disc":
            			output.Add( new PMToolTippedDisc(powerMILL, element.EntityName));
            			break;
	                case "off_centre_tip_rad":
            			output.Add( new PMToolOffCentreTipRadiused(powerMILL, element.EntityName));
            			break;
	                case "tap":
	                      output.Add( new PMToolTap(powerMILL, element.EntityName));
	                      break;
	                case "thread_mill":
	                      output.Add( new PMToolThreadMill(powerMILL, element.EntityName));
	                      break;
	                case "form":
	                    output.Add( new PMToolForm(powerMILL, element.EntityName));
	                    break;
	                case "routing":
	                    output.Add( new PMToolRouting(powerMILL, element.EntityName));
	                    break;
	                case "barrel":
	                    output.Add( new PMToolBarrel(powerMILL, element.EntityName));
	                    break;
	                case "dovetail":
	                    output.Add( new PMToolDovetail(powerMILL, element.EntityName));
	                    break;
	                case "turn_profiling":
	                    output.Add( new PMToolProfilingTurning(powerMILL, element.EntityName));
	                    break;
	                case "turn_grooving":
	                    output.Add( new PMToolGroovingTurning(powerMILL, element.EntityName));
	                    break;
	                default:
	                    output.Add( new PMTool(powerMILL, element.EntityName));
	                    break;
	            }
            }
            
            return output;
        }
    }
}