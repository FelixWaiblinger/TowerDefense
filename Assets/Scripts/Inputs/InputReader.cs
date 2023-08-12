using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameControlsActions
{
	public static UnityAction<Vector2> moveEvent;
	public static UnityAction<Vector2> zoomEvent;
	public static UnityAction selectEvent;
	public static UnityAction dragEvent;
	public static UnityAction defendEvent;
	public static UnityAction cancelEvent;
	public static UnityAction buildEvent;
	public static UnityAction pauseEvent;

	private GameInput gameInput;

	#region SETUP

	void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.GameControls.SetCallbacks(this);
		}

        EnableInput();
	}

	void OnDisable()
	{
		DisableInput();
	}

	#endregion

	#region CALLBACKS

	// move camera in xz plane (screen edge, delta during drag)
	public void OnMove(InputAction.CallbackContext context)
	{
		moveEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// move camera in y direction ?? (scroll wheel)
	public void OnZoom(InputAction.CallbackContext context)
	{
		moveEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// select object under mouse (left mouse click)
	public void OnSelect(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	// alternative camera movement (left mouse hold)
	public void OnDrag(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	// end planning phase (enter)
	public void OnDefend(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	// deselect current selection (right mouse click)
	public void OnCancel(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	// open build menu (b)
	public void OnBuild(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			buildEvent?.Invoke();
	}

	// pause the game (escape)
	public void OnPause(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			pauseEvent?.Invoke();
	}

	#endregion

	#region SWITCH INPUT

	public void EnableInput()
	{
		gameInput.GameControls.Enable();
	}
    
	public void DisableInput()
	{
		gameInput.GameControls.Disable();
	}

	#endregion
}