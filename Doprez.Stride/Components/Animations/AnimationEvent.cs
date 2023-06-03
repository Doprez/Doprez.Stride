using Doprez.Stride.Animations.Data;
using Stride.Core;
using Stride.Engine;

namespace Doprez.Stride.Animations;
[DataContract("DoprezAnimationEvent")]
[ComponentCategory("Animation")]
[AllowMultipleComponents]
public class AnimationEvent : SyncScript
{
	[DataMember(0)]
	public string EventName { get; set; }

	[DataMember(10)]
	public AnimationEventData EventData { get; set; }
	[DataMember(11)]
	public AnimationTriggerAction TriggerAction { get; set; } = AnimationTriggerAction.Once;

	public delegate void NotifyAnimationEvent();

	/// <summary>
	/// Triggered at the beginning of the Animation Event only once by default
	/// <para>Will be continuous or single based on <see cref="TriggerAction"/></para>
	/// </summary>
	public event NotifyAnimationEvent AnimationEventTriggered;
	/// <summary>
	/// Triggered once the Animation is no longer running
	/// </summary>
	public event NotifyAnimationEvent AnimationEventEnded;

	private AnimationComponent _animations;
	private bool _animationWasPlaying = false;
	private bool _triggerHasRun = false;

	public override void Start()
	{
		base.Start();
		_animations = Entity.Get<AnimationComponent>();
	}

	private void CheckAnimationEventTriggered()
	{
		if (_animations.PlayingAnimations.Count == 0)
			return;
		if (!_animations.IsPlaying(EventData.AnimationName))
			return;
		if (_triggerHasRun)
			return;

		_animationWasPlaying = true;
		var playing = _animations.PlayingAnimations;

		for (int i = 0; i < playing.Count; i++)
		{
			if (playing[i].CurrentTime.TotalMilliseconds >= EventData.EventStartTime
				&& playing[i].Name.Equals(EventData.AnimationName))
			{
				AnimationEventTriggered?.Invoke();
				switch (TriggerAction)
				{
					case AnimationTriggerAction.Once:
						_triggerHasRun = true;
						break;
					case AnimationTriggerAction.Continuous:
						break;
				}
			}
		}
	}

	private void CheckAnimationEventEnded()
	{
		if (_animationWasPlaying && !_animations.IsPlaying(EventData.AnimationName))
		{
			AnimationEventEnded?.Invoke();
			_animationWasPlaying = false;
			_triggerHasRun = false;
		}
	}

	public override void Update()
	{
		CheckAnimationEventTriggered();
		CheckAnimationEventEnded();
	}
}

public enum AnimationTriggerAction
{
	/// <summary>
	/// Only runs once on the trigger start
	/// </summary>
	Once,
	/// <summary>
	/// Runs every time the animation is played
	/// </summary>
	Continuous,
}