using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class GameResultController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Players> onPlayerWin;

    public void HandleCollisionWithTarget() => onPlayerWin.Invoke(Players.Child);

    public void HandleTimerDone() => onPlayerWin.Invoke(Players.Grandpa);
}
