using UnityEngine;
using UnityEngine.Events;

public class CarSpawningAbility : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> onNextCar;
    [SerializeField] private GameObject[] CarPrefabs;
    [SerializeField] private float AbilityCooldown;
    private float lastUse;
    private GameObject nextcar;

    private void Start()
    {
        nextcar = GetRandomCar();
        onNextCar.Invoke(nextcar);
    }

    public void OnAction()
    {
        if (Time.time - lastUse < AbilityCooldown) return;

        GameObject car = Instantiate(nextcar, transform.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            Random.Range(0f, 255f) / 255f, 
            Random.Range(0f, 255f) / 255f,
            Random.Range(0f, 255f) / 255f
            );
        AdjustCarPosition(car);

        nextcar = GetRandomCar();
        onNextCar.Invoke(nextcar);

        lastUse = Time.time;
    }

    private void AdjustCarPosition(GameObject car)
    {
        Collider2D carCollider = car.GetComponent<Collider2D>();
        if (carCollider == null) return;

        Collider2D[] hits = Physics2D.OverlapBoxAll(car.transform.position, carCollider.bounds.size, 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Boundary"))
            {
                Bounds carBounds = carCollider.bounds;
                Bounds wallBounds = hit.bounds;

                float overlap = 0f;

                if (carBounds.max.x > wallBounds.min.x && carBounds.center.x < wallBounds.center.x)
                {
                    overlap = carBounds.max.x - wallBounds.min.x;
                    car.transform.position -= new Vector3(overlap, 0f, 0f);
                }
                else if (carBounds.min.x < wallBounds.max.x && carBounds.center.x > wallBounds.center.x)
                {
                    overlap = wallBounds.max.x - carBounds.min.x;
                    car.transform.position += new Vector3(overlap, 0f, 0f);
                }
            }
        }
    }



    private GameObject GetRandomCar() => nextcar = CarPrefabs[Random.Range(0, CarPrefabs.Length - 1)];
}
