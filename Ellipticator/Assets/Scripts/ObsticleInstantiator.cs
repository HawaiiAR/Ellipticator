using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tracks {
    public class ObsticleInstantiator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnPoints;
        [SerializeField] private GameObject _minePrefab;

        private List<GameObject> _availableSpawnPoint;
        public List<GameObject> _armedMines;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnEnable()
        {
            int randSpawn = Random.Range(1, _spawnPoints.Count);
            _availableSpawnPoint = GetRandomSpawnPoint(_spawnPoints, randSpawn);

            Invoke(nameof(SpawnObjects), 1);
        }

   

        List<T> GetRandomSpawnPoint<T>(List<T> points, int randomSpawnPointCount)
        {
            List<T> _objectsToSpawn = new List<T>();
            for (int i = 0; i < randomSpawnPointCount; i++)
            {
                int index = UnityEngine.Random.Range(0, _spawnPoints.Count);
                _objectsToSpawn.Add(points[index]);
            }
         
            return _objectsToSpawn;
        }

        private void SpawnObjects()
        {
            for (int i = 0; i < _availableSpawnPoint.Count; i++)
            {
                GameObject _mine = Instantiate(_minePrefab, _availableSpawnPoint[i].transform.position, Quaternion.identity);
                _armedMines.Add(_mine);
                _mine.transform.parent = _availableSpawnPoint[i].transform;
              
            }
        }

        private void OnDisable()
        {
            foreach(GameObject m in _armedMines)
            {
                if (m != null)
                {
                    Destroy(m.gameObject);
                    
                }
            }
            _availableSpawnPoint.Clear();
            
        }

    }
}
