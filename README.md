# Doprez.Stride
A bundle of Stride related libraries

# Build Status
[![CircleCI](https://dl.circleci.com/status-badge/img/gh/Doprez/Doprez.Stride/tree/master.svg?style=svg)](https://dl.circleci.com/status-badge/redirect/gh/Doprez/Doprez.Stride/tree/master)

# Examples

## Player Controller Example

```
public class PlayerController : SyncScript
{
	[DataMember(0)]
	public Keys ForwardKey { get; set; }
	[DataMember(1)]
	public Keys BackwardKey { get; set; }
	[DataMember(2)]
	public Keys RightKey { get; set; }
	[DataMember(3)]
	public Keys LeftKey { get; set; }
	[DataMember(100)]
	public Keys Interact { get; set; }
	[DataMember(200)]
	public Keys JumpKey { get; set; }

	private PlayerMover _playerMover;
	private Raycast _raycast;

	public override void Start()
	{
		_playerMover = Entity.GetComponent<PlayerMover>();
		_raycast = Entity.GetComponent<Raycast>();
		Input.Mouse.LockPosition(true);
	}

	public override void Update()
	{
		MovePlayer();
		RotateCamera();
		Jump();
		PlayerRaycast();
	}

	private void MovePlayer()
	{
		Vector2 movement = Vector2.Zero;

		if (Input.IsKeyDown(ForwardKey))
		{
			movement.Y += 1;
		}
		if (Input.IsKeyDown(BackwardKey))
		{
			movement.Y -= 1;
		}
		if (Input.IsKeyDown(RightKey))
		{
			movement.X += 1;
		}
		if (Input.IsKeyDown(LeftKey))
		{
			movement.X -= 1;
		}
		_playerMover.MovePlayer(movement);
	}

	private void RotateCamera()
	{
		_playerMover.UpdateCameraRotation(Input.Mouse.Delta * 100);
	}

	private void Jump()
	{
		if (Input.IsKeyPressed(JumpKey))
		{
			_playerMover.Jump();
		}
	}

	//Example of the Raycast Component usage to store a HitResult in the result variable
	private void PlayerRaycast()
	{
		if (Input.IsKeyPressed(Interact))
		{
			var result = _raycast.RayCast(_playerMover.CameraPivot);
		}
	}
}
```