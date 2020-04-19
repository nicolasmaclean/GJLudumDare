using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] stages;
    public Mouth mouth;
    public GameObject milkText;
    public int currentStage = 0;
    public Transform currentPlayer;

    void Start()
    {
        instantiatePlayer(transform);
    }

    public bool levelUp(int i)
    {
        if(currentStage + i >= stages.GetLength(0))
            return false;
        
        currentStage += i;
        instantiatePlayer(currentPlayer.transform);

        return true;
    }

    // creates the next player and transfers data
    void instantiatePlayer(Transform t)
    {
        GameObject newPlayer = Instantiate(stages[currentStage], t.position, t.rotation, transform);
        newPlayer.GetComponent<PlayerInventory>().mouth = mouth;
        newPlayer.GetComponent<PlayerInventory>().milkText = milkText;

        if(currentPlayer != null) {
            newPlayer.GetComponent<PlayerInventory>().milkCount = currentPlayer.GetComponent<PlayerInventory>().milkCount;

            DestroyImmediate(currentPlayer.gameObject);
        }

        currentPlayer = newPlayer.transform;
    }

    public bool canLevelUp()
    {
        return stages.GetLength(0)-1 > currentStage;
    }
}
