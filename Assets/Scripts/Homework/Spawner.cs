using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    /**
     * TODO:
     * 1. Найти примеры полиморфизма в уже написанном коде и в том, что будет написан вами.
     * 2. Реализовать удаление объектов из коллекции _spawnedObjects.
     * 3. Заменить тип коллекции на более подходящий к данному случаю. Объяснить, если замена не требуется.
     */
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private int _totalAmount;

        [SerializeField]
        private float _spawnDelay;

        [SerializeField]
        private float _dequeueDelay;

        [SerializeField]
        private GameObject[] _objectsToSpawn;

        public Queue<GameObject> _spawnedObjects = new Queue<GameObject>();


        void Start()
        {
            StartCoroutine(SpawnNext());
        }

        private IEnumerator SpawnNext()
        {
            var random = new System.Random();
            int i;
            int dogCounter = 0;
            
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);

                if (_spawnedObjects.Count < _totalAmount)
                {
                    i = random.Next(_objectsToSpawn.Length);
                    
                    var spawnedObject = Instantiate(_objectsToSpawn[i], transform);
                    dogCounter++;
                    spawnedObject.name += $" {dogCounter}";
                    
                    _spawnedObjects.Enqueue(spawnedObject);
                    Debug.Log($"{spawnedObject.name}: родилась и попала в Queue");

                }

                yield return new WaitForSeconds(_dequeueDelay);
                
                if (_spawnedObjects.Count >= _totalAmount)
                {
                    _spawnedObjects.TryDequeue(out var firstAtQueue);
                    Destroy(firstAtQueue);
                    Debug.Log($"{firstAtQueue.name}: стала старой и покинула Queue");
                }
            }
        }
    }
}