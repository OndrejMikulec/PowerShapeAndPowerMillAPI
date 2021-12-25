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
        	
            List<Tuple<string,string>> extracted = ExtractFunction.ExtractStringValue("tool","type",powerMILL);
            
            foreach (Tuple<string,string> element in extracted.Where(item => names.Contains(item.Item1))) {
                     	
            	switch (element.Item2)
	            {
	                case "end_mill":
            			output.Add( new PMToolEndMill(powerMILL, element.Item1));
            			break;
	                case "ball_nosed":
            			output.Add( new PMToolBallNosed(powerMILL, element.Item1));
            			break;
	                case "tip_radiused":
            			output.Add( new PMToolTipRadiused(powerMILL, element.Item1));
            			break;
	                case "taper_spherical":
            			output.Add( new PMToolTaperedSpherical(powerMILL, element.Item1));
            			break;
	                case "taper_tipped":
            			output.Add( new PMToolTaperedTipped(powerMILL, element.Item1));
            			break;
	                case "drill":
            			output.Add( new PMToolDrill(powerMILL, element.Item1));
            			break;
	                case "tipped_disc":
            			output.Add( new PMToolTippedDisc(powerMILL, element.Item1));
            			break;
	                case "off_centre_tip_rad":
            			output.Add( new PMToolOffCentreTipRadiused(powerMILL, element.Item1));
            			break;
	                case "tap":
	                      output.Add( new PMToolTap(powerMILL, element.Item1));
	                      break;
	                case "thread_mill":
	                      output.Add( new PMToolThreadMill(powerMILL, element.Item1));
	                      break;
	                case "form":
	                    output.Add( new PMToolForm(powerMILL, element.Item1));
	                    break;
	                case "routing":
	                    output.Add( new PMToolRouting(powerMILL, element.Item1));
	                    break;
	                case "barrel":
	                    output.Add( new PMToolBarrel(powerMILL, element.Item1));
	                    break;
	                case "dovetail":
	                    output.Add( new PMToolDovetail(powerMILL, element.Item1));
	                    break;
	                case "turn_profiling":
	                    output.Add( new PMToolProfilingTurning(powerMILL, element.Item1));
	                    break;
	                case "turn_grooving":
	                    output.Add( new PMToolGroovingTurning(powerMILL, element.Item1));
	                    break;
	                default:
	                    output.Add( new PMTool(powerMILL, element.Item1));
	                    break;
	            }
            }
            
            return output;
        }
    }
}