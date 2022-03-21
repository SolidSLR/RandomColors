using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Material> colorList;
    public GameObject player;

    private Vector3 randomPos;

    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {

        if(player == null){

            Debug.Log("Player sin asignar");

        }

        initPos = player.transform.position;

        StartCoroutine(SpawnPlayerCorut());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnPlayerCorut(){

        int limit = 0;

        while(limit < 6){

            yield return new WaitForSeconds(5f);

            

            if(limit > 0){

                initPos.x = Random.Range(-5f, 5f);

                initPos.z = Random.Range(-2f, 5f);
            
            }

            randomPos = new Vector3(initPos.x, initPos.y, initPos.z);

            SpawnPlayer(player);

            limit++;

        }
    }

    public void SpawnPlayer(GameObject player){ 

        GameObject newPlayer = Instantiate(player, randomPos, Quaternion.identity);

        PlayerColor(newPlayer);

        Debug.Log("Ah, hice spawn");

    }

    public void PlayerColor(GameObject newPlayer){
        
        int randNumb = Random.Range(0, colorList.Count);

        newPlayer.gameObject.GetComponent<Renderer>().material = colorList[randNumb];

        colorList.RemoveAt(randNumb);

    }

}
