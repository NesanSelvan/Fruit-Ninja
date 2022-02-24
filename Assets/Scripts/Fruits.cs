using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject slicedfruit;
    private GameManager m_gm;
    private void Start()
    {
        m_gm = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void createslicedfruit()
    {
        GameObject inst = Instantiate(slicedfruit, transform.position, transform.rotation);
        Rigidbody[] rbsliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rbsliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 100), transform.position, 5f);
        }
       
        Destroy(inst, 5f);
        Destroy(gameObject);
        m_gm.playslicedsound();
        m_gm.Increasescore(3);
    }
 
    // Update is called once per frame
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            Debug.Log("Null");
            return;
        }
        
            createslicedfruit();
            Debug.Log("Cutting object");
        
    }
   
}
