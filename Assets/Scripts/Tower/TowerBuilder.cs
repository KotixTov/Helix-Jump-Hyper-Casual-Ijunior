using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private Platform _finishPlatform;

    
    private float _startAndFinishAdditionalScale = 0.5f;

    private float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;
    
    // Start is called before the first frame update
    void Awake()
    {
        Build();
    }

    private void Build()
    {
        var Beam = Instantiate(_beam, transform.position, Quaternion.identity, transform);
        Beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = Beam.transform.position;
        spawnPosition.y += Beam.transform.localScale.y - _additionalScale;
        
        SpawnPlatform(_startPlatform, ref spawnPosition, transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0,_platforms.Length)], ref spawnPosition, transform);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
