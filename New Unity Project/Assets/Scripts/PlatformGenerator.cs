using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;

    private float platformWidth;
    private float distanceMin = 0;
    private float distanceMax = 3;
    private float distanceBetween;

    private int platformSelector;

    //public GameObject[] thePlatforms;
    private float[] platformWidths;

    public ObjectPooling[] theObjectPools;

    public Transform maxHeightPoint;
    private float minHeight;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public CoinGenerator theCoin;
    private float randomCoinThreshold = 70;

    private float randomEnemyThreshold = 90;
    public ObjectPooling enemyPool;

    private ScoreManager theScore;

    // Use this for initialization
    void Start () {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        
        for (int i = 0; i < theObjectPools.Length; i++){
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoin = FindObjectOfType<CoinGenerator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x){
            distanceBetween = Random.Range(distanceMin, distanceMax);
            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            if(heightChange > maxHeight){
                heightChange = maxHeight;
            }

            else if (heightChange < minHeight){
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween,
                heightChange, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoin.spawn(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(randomCoinThreshold, 100f) < randomEnemyThreshold)
            {
                GameObject newEnemy = enemyPool.GetPooledObject();
                newEnemy.transform.position = new Vector3(transform.position.x + Random.Range(-(platformWidths[platformSelector] / 2), (platformWidths[platformSelector] / 2)), transform.position.y + 1f, transform.position.z);
                newEnemy.transform.rotation = transform.rotation;
                newEnemy.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween,
                transform.position.y, transform.position.z);
        }

	}
}
