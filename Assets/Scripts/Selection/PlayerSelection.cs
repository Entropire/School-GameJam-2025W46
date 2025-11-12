using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    public UnityEvent<int, Character> onSelectedCharacterChange;
    public UnityEvent onStartGame;

    [SerializeField] TMP_Text playerLabel;
    [SerializeField] GameObject Selector;
    [SerializeField] GameObject[] SelectionCells;
    [SerializeField] private float moveCooldown = 0.1f;

    private int posistion = 1;
    private float lastMoveTime;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerLabel.text = "P" + (playerInput.playerIndex + 1);

        Selector.transform.SetParent(SelectionCells[posistion].transform);
        Selector.transform.localPosition = Vector3.zero;
    }

    public void OnDisconnect()
    {
        playerInput.user.UnpairDevicesAndRemoveUser();
        Destroy(gameObject);
    }

    public void OnMove(InputValue value)
    {
        float move = value.Get<float>();

        if (Time.time - lastMoveTime > moveCooldown) return;

        posistion += move > 0 ? 1 : -1;
        posistion = Mathf.Clamp(posistion, 0, SelectionCells.Length - 1);

        Selector.transform.SetParent(SelectionCells[posistion].transform);
        Selector.transform.localPosition = Vector3.zero;

        Character selectedCharacter = Character.None;
        if (posistion == 0) selectedCharacter = Character.Grandpa;
        else if (posistion == 2) selectedCharacter = Character.Grandchild;

        onSelectedCharacterChange.Invoke(playerInput.playerIndex, selectedCharacter);

        lastMoveTime = Time.time;
    }

    public void OnStartGame()
    {
        if (playerInput.playerIndex == 0)
        {
            onStartGame.Invoke();
        }
    }
}
