using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Graphics;
using Stride.Graphics.Data;
using Stride.Rendering;

namespace Doprez.Stride.ModelCategory;

[DataContract]
public class LODData
{
	public Model MeshLOD = new Model();
	public int DistanceToActivate { get; set; } = 0;
}
