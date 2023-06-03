using Stride.Core;

namespace Doprez.Stride.Animations.Data;

[DataContract(nameof(AnimationEventData))]
[Display("EventData")]
public struct AnimationEventData
{
	/// <summary>
	/// Set the Name of the Animation in the AnimationComponent
	/// </summary>
	[DataMember(0)]
	public string AnimationName { get; set; }

	/// <summary>
	/// Set the Start Time of the Animation Event in Milliseconds
	/// </summary>
	[DataMember(10)]
	[Display("Start Time")]
	public double EventStartTime { get; set; }
}
