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

	private GameInput gameInput;

	#region SETUP

	private void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.GameControls.SetCallbacks(this);
		}

        gameInput.GameControls.Enable();
		//EnableGameplayInput();
	}

	private void OnDisable()
	{
		//DisableAllInput();
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

	// select object under mouse (left click)
	public void OnSelect(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	// alternative camera movement (right click)
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

	// deselect current selection (escape)
	public void OnCancel(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			defendEvent?.Invoke();
	}

	#endregion

	#region SWITCH INPUT

	//public void EnableDialogueInput()
	//{
	//	gameInput.Dialogues.Enable();
	//	gameInput.Gameplay.Disable();
	//}
    //
	//public void EnableGameplayInput()
	//{
	//	gameInput.Gameplay.Enable();
	//	gameInput.Dialogues.Disable();
	//}
    //
	//public void DisableAllInput()
	//{
	//	gameInput.Gameplay.Disable();
	//	gameInput.Dialogues.Disable();
	//}

	#endregion
}