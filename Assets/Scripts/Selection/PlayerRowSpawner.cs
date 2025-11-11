using Assets.Scripts.Selection;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRowSpawner : MonoBehaviour
{
    [SerializeField] Transform playerRowsParent;
    [SerializeField] PlayerSelectionController playerSelectionController;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.SetParent(playerRowsParent);

        playerInput.transform.localPosition = Vector3.zero;
        playerInput.transform.localRotation = Quaternion.identity;
        playerInput.transform.localScale = Vector3.one;

        PlayerSelection playerSelection = playerInput.GetComponent<PlayerSelection>();
        playerSelection.onSelectedCharacterChange.AddListener(playerSelectionController.HandleSelectedCharacterChange);
        playerSelection.onStartGame.AddListener(playerSelectionController.HandleGamestart);
    }
}
