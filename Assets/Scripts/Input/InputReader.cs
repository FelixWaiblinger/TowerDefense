using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameControlsActions
{
	public static UnityAction<Vector2> moveEvent;
	public static UnityAction buildMenuEvent;
	public static UnityAction endDayEvent;

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

	public void OnMove(InputAction.CallbackContext context)
	{
		moveEvent?.Invoke(context.ReadValue<Vector2>());
	}

	public void OnBuildMenu(InputAction.CallbackContext context)
	{
		buildMenuEvent?.Invoke();
	}

	public void OnEndDay(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			endDayEvent?.Invoke();
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