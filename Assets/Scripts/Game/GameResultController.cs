using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class GameResultController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Character> onPlayerWin;

    public void HandleCollisionWithTarget()
    {
        EndGameResult.winner = PlayerSelectionData.selectedCharacters[0] == Character.Grandchild ? 0 : 1;
    }

    public void HandleTimerDone()
    {
        EndGameResult.winner = PlayerSelectionData.selectedCharacters[0] == Character.Grandpa ? 0 : 1;
    }
}
