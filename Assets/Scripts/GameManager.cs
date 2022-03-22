using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static List<Color> colorList = new List<Color>() {

        Color.black, 
        Color.blue, 
        Color.clear, 
        Color.cyan, 
        Color.gray, 
        Color.green, 
        Color.grey, 
        Color.magenta, 
        Color.white, 
        Color.yellow
        
        };

    private static List<int> usedPos = new List<int>();

    public GameObject player;

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

        while(limit < colorList.Count){

            yield return new WaitForSeconds(1f);

            if(limit > 0){

                initPos.x = Random.Range(-5f, 5f);

                initPos.z = Random.Range(-2f, 5f);
            
            }

            Vector3 randomPos = new Vector3(initPos.x, initPos.y, initPos.z);

            SpawnPlayer(randomPos);

            limit++;

        }
    }

    public void SpawnPlayer(Vector3 randomPos){ 

        GameObject newPlayer = Instantiate(player, randomPos, Quaternion.identity);

        PlayerColor(newPlayer);

        Debug.Log("Ah, hice spawn "+newPlayer.gameObject.GetComponent<Renderer>().material.color);

    }

    public void PlayerColor(GameObject newPlayer){
        
        newPlayer.gameObject.GetComponent<Renderer>().material.color = colorList[GenerateNumber()];

        //colorList.RemoveAt(randNumb);

    }

    public int GenerateNumber(){

        int randNumb = Random.Range(0, colorList.Count);

        while(usedPos.Contains(randNumb)){

            randNumb = Random.Range(0, colorList.Count);

        }

        usedPos.Add(randNumb);

        return randNumb;
    }
}