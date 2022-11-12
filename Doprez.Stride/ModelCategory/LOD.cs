using Doprez.Stride.Extensions;
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

[ComponentCategory("Model")]
public class LOD : AsyncScript
{
	[DataMember(0, "LOD's")]
	public List<LODData> LODs = new List<LODData>();

    private Entity _player;
    private ModelComponent _modelComponent;

    public override async Task Execute()
    {
        _modelComponent = Entity.Get<ModelComponent>();
        _player = Entity.GetComponentInScene<CameraComponent>().Entity;

		while (Game.IsRunning)
        {
            UpdateCurrentLOD();

			await Script.NextFrame();
		}
    }

    private void UpdateCurrentLOD()
	{
		var distance = GetDistanceBetweenVectors(_player.Transform.WorldMatrix.TranslationVector, Entity.Transform.WorldMatrix.TranslationVector);
		for (int i = LODs.Count - 1; i >= 0; i--)
        {
            if (distance < LODs[i].DistanceToActivate && _modelComponent.Model != LODs[i].MeshLOD)
            {
                _modelComponent.Model = LODs[i].MeshLOD;
            }
		}
    }

    private float GetDistanceBetweenVectors(Vector3 pointA, Vector3 pointB)
    {
        var result = MathF.Sqrt
            (
                (pointB.X - pointA.X) * (pointB.X - pointA.X)
				+ (pointB.Y - pointA.Y) * (pointB.Y - pointA.Y)
				+ (pointB.Z - pointA.Z) * (pointB.Z - pointA.Z)
            );

        return result;
    }

}
