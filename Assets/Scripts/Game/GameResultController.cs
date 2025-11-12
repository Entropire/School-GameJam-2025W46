using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameResultController : MonoBehaviour
{

    public void HandleCollisionWithTarget()
    {
        EndGameResult.winner = PlayerSelectionData.selectedCharacters[0] == Character.Grandchild ? 0 : 1;
        SceneManager.LoadScene("End");
    }

    public void HandleTimerDone()
    {
        EndGameResult.winner = PlayerSelectionData.selectedCharacters[0] == Character.Grandpa ? 0 : 1;
        SceneManager.LoadScene("End");
    }
}
