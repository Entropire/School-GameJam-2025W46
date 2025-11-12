using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class GameResultController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Character> onPlayerWin;

    public void HandleCollisionWithTarget() => onPlayerWin.Invoke(Character.Grandchild);

    public void HandleTimerDone() => onPlayerWin.Invoke(Character.Grandpa);
}
