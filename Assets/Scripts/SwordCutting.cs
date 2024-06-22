using UnityEngine;

public class SwordCutting : MonoBehaviour
{
    [SerializeField] private GameObject replacementPrefab;
    [SerializeField] private GameObject replacementPrefab2;
    [SerializeField] private float forceMagnitude = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Destroy(gameObject);

            GameObject prefab1 = Instantiate(replacementPrefab, transform.position, transform.rotation);
            GameObject prefab2 = Instantiate(replacementPrefab2, transform.position, transform.rotation);

            AddForceToPrefab(prefab1);
            AddForceToPrefab(prefab2);
        }
    }

    private void AddForceToPrefab(GameObject prefab)
    {
        Rigidbody rb = prefab.AddComponent<Rigidbody>();

        // Apply force to the Rigidbody
        rb.AddForce(Vector3.down * forceMagnitude, ForceMode.Impulse);
    }
}
