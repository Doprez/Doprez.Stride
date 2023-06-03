using Stride.Core;
using Stride.Rendering;

namespace Doprez.Stride.ModelCategory;

[DataContract]
public class LODData
{
	public Model MeshLOD = new Model();
	public int DistanceToActivate { get; set; } = 0;
}
