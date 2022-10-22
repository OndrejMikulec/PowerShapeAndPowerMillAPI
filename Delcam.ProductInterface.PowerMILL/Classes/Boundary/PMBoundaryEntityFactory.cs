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
    /// Represents the factory for boundaries.
    /// </summary>
    internal class PMBoundaryEntityFactory
    {
    	/// <summary>
        /// Creates a new boundary based on its type.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="name">The name for the boundary entity.</param>
        /// <returns>The created boundary.</returns>
        /// <remarks></remarks>
        internal static PMBoundary CreateEntity(PMAutomation powerMILL, string name)
        {
        	return CreateEntity(powerMILL, new List<string>{name}).First();
        }
    	
        /// <summary>
        /// Creates a new boundary based on its type.
        /// </summary>
        /// <param name="powerMILL">The base instance to interact with PowerMILL.</param>
        /// <param name="names">The names for the boundary entity.</param>
        /// <returns>The created boundary.</returns>
        /// <remarks></remarks>
        internal static List<PMBoundary> CreateEntity(PMAutomation powerMILL, List<string> names)
        {
        	List<PMBoundary> output = new List<PMBoundary>();
        	
        	List<ExtractedString> extracted = ExtractFunction.ExtractStringValue("boundary","type",powerMILL);
        	
        	foreach (ExtractedString element in extracted.Where(item => names.Contains(item.EntityName))) {
        		
            	switch (element.ExtractedValue)
	            {
	                case "block":
            			output.Add( new PMBoundaryBlock(powerMILL, element.EntityName));
            			break;
	                case "rest":
	                    output.Add( new PMBoundaryRest(powerMILL, element.EntityName));
            			break;
	                case "selected":
	                    output.Add( new PMBoundarySelectedSurface(powerMILL, element.EntityName));
            			break;
	                case "shallow":
	                    output.Add( new PMBoundaryShallow(powerMILL, element.EntityName));
            			break;
	                case "silhouette":
	                    output.Add( new PMBoundarySilhouette(powerMILL, element.EntityName));
            			break;
	                case "collision":
	                    output.Add( new PMBoundaryCollisionSafe(powerMILL, element.EntityName));
            			break;
	                case "stockmodel_rest":
	                    output.Add( new PMBoundaryStockModelRest(powerMILL, element.EntityName));
            			break;
	                case "contact_point":
	                    output.Add( new PMBoundaryContactPoint(powerMILL, element.EntityName));
            			break;
	                case "contact_conv":
	                    output.Add( new PMBoundaryContactConversion(powerMILL, element.EntityName));
            			break;
	                case "boolean_operation":
	                    output.Add( new PMBoundaryBooleanOperation(powerMILL, element.EntityName));
            			break;
	                case "user":
	                    output.Add( new PMBoundaryUserDefined(powerMILL, element.EntityName));
            			break;
	                default:
	                    throw new Exception("Failed to determine boundary type");
	            }
            }
        	
        	return output;
        }
    }
}