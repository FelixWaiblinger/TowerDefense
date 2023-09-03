using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEditor;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameControlsActions
{
	#region VARIABLE

	public static UnityAction<Vector2> moveEvent;
	public static UnityAction<Vector2> movePosEvent;
	public static UnityAction<Vector2> zoomEvent;
	public static UnityAction selectEvent;
	public static UnityAction cancelEvent;
	public static UnityAction buildEvent;
	public static UnityAction transitionEvent;
	public static UnityAction pauseEvent;

	private GameInput gameInput;

	#endregion

	#region SETUP

	void OnEnable()
	{
		EditorApplication.playModeStateChanged += InitGameInput;
	}
	
	void OnDisable()
	{
		EditorApplication.playModeStateChanged -= InitGameInput;
		if (gameInput != null) DisableInput();
	}

	// strange workaround to fix manually refreshing input scriptable object instance
	void InitGameInput(PlayModeStateChange stateChange)
	{
		if (stateChange == PlayModeStateChange.EnteredPlayMode)
		{
			if (gameInput == null)
			{
				gameInput = new GameInput();
				gameInput.GameControls.SetCallbacks(this);
			}

	    	EnableInput();
		}
	}

	#endregion

	#region CALLBACKS

	// move camera in xz plane (wasd)
	public void OnMove(InputAction.CallbackContext context)
	{
		moveEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// move camera in xz plane (screen edge, delta during drag)
	public void OnMovePos(InputAction.CallbackContext context)
	{
		movePosEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// change camera distance and angle (scroll wheel)
	public void OnZoom(InputAction.CallbackContext context)
	{
		zoomEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// select object under mouse (left mouse click)
	public void OnSelect(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			selectEvent?.Invoke();
	}

	// deselect current selection (right mouse click)
	public void OnCancel(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			cancelEvent?.Invoke();
	}

	// open build menu (b)
	public void OnBuild(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			buildEvent?.Invoke();
	}

	// end planning phase (enter)
	public void OnTransition(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			transitionEvent?.Invoke();
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