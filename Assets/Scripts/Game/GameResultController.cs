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
        EndGameResult.winner = Character.Grandchild;
        SceneManager.LoadScene("End");
    }

    public void HandleTimerDone()
    {
        EndGameResult.winner = Character.Grandpa;
        SceneManager.LoadScene("End");
    }
}
