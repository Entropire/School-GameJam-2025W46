using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject GrandpaPrefab;
    [SerializeField] private GameObject GrandchildPrefab;
    [SerializeField] private Transform SpawnPointGrandpa;
    [SerializeField] private Transform SpawnPointGrandchild;

    void Start()
    {
        for (int i = 0; i < PlayerSelectionData.selectedCharacters.Length; i++)
        {

            var newCharacter = Instantiate(
                PlayerSelectionData.selectedCharacters[i] == Character.Grandpa ? GrandpaPrefab : GrandchildPrefab, 
                (PlayerSelectionData.selectedCharacters[i] == Character.Grandpa ? SpawnPointGrandpa : SpawnPointGrandchild).position, 
                Quaternion.identity);

            PlayerInput playerInput = newCharacter.GetComponent<PlayerInput>();
            playerInput.SwitchCurrentControlScheme(PlayerSelectionData.devices[i]);
            playerInput.SwitchCurrentActionMap("Player");
        }
    }
}
