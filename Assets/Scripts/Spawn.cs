using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] fruittospawn;
    public GameObject bomb;
    public int chancetospawnbomb = 10;
    private float mintime = 0.7f;
    private float maxtime = 1.5f;
    private float minforce = 10f;
    private float maxforce = 20f;
    public Transform[] spawnplaces;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFruits());
    }
    private IEnumerator spawnFruits()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(mintime, maxtime));
            Transform t = spawnplaces[Random.Range(0, spawnplaces.Length)];
            GameObject go = null;
            float rnd = Random.Range(0, 50);
            if(rnd<chancetospawnbomb)
            {
                go = bomb;
            }
            else
            {
                go = fruittospawn[Random.Range(0,fruittospawn.Length)];
            }
           
           GameObject fruit = Instantiate(go, t.transform.position, t.transform.rotation);
           fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minforce, maxforce),ForceMode2D.Impulse);
            Destroy(fruit, 5f);
        }
    }

    // Update is called once per frame
    
}
