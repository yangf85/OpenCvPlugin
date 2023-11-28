using OpenCvSharp.XImgProc;
using OpenCvSharp;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using CV = OpenCvSharp;

using Point3d = Rhino.Geometry.Point3d;

namespace OpenCvPlugin
{
    public class SkeletonCurveCommand : Command
    {
        private List<Point3d> SamplePoints(Curve boundary)
        {
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var get = new GetObject();
            get.GeometryFilter = Rhino.DocObjects.ObjectType.Curve;
            get.GeometryAttributeFilter = GeometryAttributeFilter.ClosedCurve;

            if (get.CommandResult() != Result.Success)
            {
                return get.CommandResult();
            }

            var boundary = get.Object(0).Curve();

            var boundingBox = boundary.GetBoundingBox(true);

            return Result.Success;
        }

        ///<summary>The only instance of this command.</summary>
        public static SkeletonCurveCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "SkeletonCurveCommand";

        public SkeletonCurveCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }
    }
}