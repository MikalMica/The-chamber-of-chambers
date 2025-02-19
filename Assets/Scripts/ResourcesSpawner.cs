using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawner : MonoBehaviour
{
    [SerializeField] Vector3 _size;
    [SerializeField] GameObject[] _resources;

    [SerializeField] int _amount = 2;
    [SerializeField] float _spawnRate = 3;
    [SerializeField] int _maxResources = 10;

    List<GameObject> _spawnedResources = new List<GameObject>();

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size);
    }

    private void Start() => StartCoroutine(SpawnResourcesRoutine());

    IEnumerator SpawnResourcesRoutine() {
        while(true) {

            for(int i = 0; i < _amount; i++) {
                if(_spawnedResources.Count < _maxResources) SpawnResources();
                else break;
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
        InstanceHandler obj = Instantiate(_resources[Random.Range(0, _resources.Length)], position, Quaternion.identity).GetComponent<InstanceHandler>();
        obj.AddDestroyListener(() => _spawnedResources.Remove(obj.gameObject));
        _spawnedResources.Add(obj.gameObject);
    }
}
