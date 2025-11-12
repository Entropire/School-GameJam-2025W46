using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultController : MonoBehaviour
{
    private void Start()
    {
        CarCollisionTrigger.onCollisionWithTarget += HandleCollisionWithTarget;
    }

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
