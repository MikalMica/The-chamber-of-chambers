using System.Collections;
using UnityEngine;

public class ResourcesSpawner : MonoBehaviour
{
    [SerializeField] Vector3 _size;
    [SerializeField] GameObject[] _resources;

    [SerializeField] int _amount = 2;
    [SerializeField] float _spawnRate = 3;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size);
    }

    private void Start() => StartCoroutine(SpawnResourcesRoutine());

    IEnumerator SpawnResourcesRoutine() {
        while(true) {
            for(int i = 0; i < _amount; i++) {
                SpawnResources();
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    void SpawnResources() {
        Vector3 position = new Vector3(
            Random.Range(transform.position.x - _size.x / 2, transform.position.x + _size.x / 2),
            Random.Range(transform.position.y - _size.y / 2, transform.position.y + _size.y / 2),
            Random.Range(transform.position.z - _size.z / 2, transform.position.z + _size.z / 2)
        );
        Instantiate(_resources[Random.Range(0, _resources.Length)], position, Quaternion.identity);
    }
}
