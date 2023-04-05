using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Rendering.Compositing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.ModelCategory;

[DataContract("SimpleLODComponent", Inherited = true)]
[ComponentCategory("Model")]
public class SimpleLOD : AsyncScript
{
	[DataMember(0, "LOD's")]
	public List<LODData> LODs = new List<LODData>();

    private Entity _camera;
    private ModelComponent _modelComponent;

    public override async Task Execute()
    {
        _modelComponent = Entity.Get<ModelComponent>();
        _camera = Entity.GetComponentInScene<CameraComponent>().Entity;

		while (Game.IsRunning)
        {
            UpdateCurrentLOD();

			await Script.NextFrame();
		}
    }

    private void UpdateCurrentLOD()
	{
		var distance = Vector3.Distance(_camera.WorldPosition(), Entity.WorldPosition());
		for (int i = LODs.Count - 1; i >= 0; i--)
        {
            if (distance < LODs[i].DistanceToActivate && _modelComponent.Model != LODs[i].MeshLOD)
            {
                _modelComponent.Model = LODs[i].MeshLOD;
            }
		}
    }
}
