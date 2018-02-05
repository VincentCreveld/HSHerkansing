using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int axes ,arrows, spikes, additionalAxes, additionalArrows, additonalSpikes, spectres, fleshKnight;
    public int trapDifficulty, puzzlingDifficulty;
    public bool updateDifficulty;

    public List<GameObject> axesOff, arrowsOff, spikesOff, Enemies,remainingTraps;
    List<GameObject> activeTraps;
    public List<PuzzleDifficulty> puzzleDifficulty;

	// Use this for initialization
	void Start () {
        puzzleDifficulty = new List<PuzzleDifficulty>();
        activeTraps = new List<GameObject>();
        axes += additionalAxes;
        arrows += additionalArrows;
        spikes += additonalSpikes;

        TrapSetup(axes, axesOff);
        TrapSetup(arrows, arrowsOff);
        TrapSetup(spikes, spikesOff);

        EnemySetup(spectres, Enemies, true);
        EnemySetup(fleshKnight, Enemies, false);
    }

    void TrapSetup(int relevantAmount, List<GameObject> relevantList)
    {

        if (relevantAmount > 0)
        {
            if (relevantAmount >= relevantList.Count)
            {
                for(int x = 0; x < relevantList.Count; x++)
                {
                    relevantList[x].SetActive(true);
                    activeTraps.Add(relevantList[x]);
                }
            }
            else
                PickRandomTrap(relevantAmount, relevantList);
        }
    }

    void EnemySetup(int relevantAmount, List<GameObject> relevantList, bool spectre)
    {

        if (relevantAmount > 0)
        {
            if (relevantAmount >= relevantList.Count )
            {
                foreach (GameObject currentObject in relevantList)
                {
                    currentObject.SetActive(true);
                    if (spectre)
                        currentObject.GetComponent<EnemyAI>().isSpectre = true;
                    else
                        currentObject.GetComponent<EnemyAI>().isFlesh = true;
                }
            }
            else
                PickRandomEnemy(relevantAmount, relevantList, spectre);
        }
    }

    void PickRandomTrap(int relevantAmount, List<GameObject> relevantList)
    {
        int temp = Random.Range(0, relevantAmount -1);
        activeTraps.Add(relevantList[temp]);
        relevantList[temp].SetActive(true);
        relevantList.RemoveAt(temp);
        relevantAmount -= 1;
        if (relevantAmount > 0)
            PickRandomTrap(relevantAmount, relevantList);
    }

    void PickRandomEnemy(int relevantAmount, List<GameObject> relevantList, bool spectre)
    {
        int temp = Random.Range(0, relevantAmount - 1);
        relevantList[temp].SetActive(true);
        if (spectre)
        {
            relevantList[temp].GetComponent<EnemyAI>().isSpectre = true;
            relevantList[temp].GetComponent<EnemyAI>().isFlesh = false;
        }
        else
        {
            relevantList[temp].GetComponent<EnemyAI>().isFlesh = true;
            relevantList[temp].GetComponent<EnemyAI>().isSpectre = false;
        }
        Enemies.RemoveAt(temp);
        relevantAmount -= 1;
        if (relevantAmount > 0)
            PickRandomEnemy(relevantAmount, relevantList, spectre);
    }

    void AlterPuzzleDifficulty(int difficulty)
    {
        if (puzzleDifficulty.Count != 0)
            foreach (PuzzleDifficulty puzzle in puzzleDifficulty)
            {
                puzzle.difficulty = difficulty;
            }
    }

    void AlterTrapDifficulty(int difficulty)
    {
        if (activeTraps.Count != 0)
            foreach (GameObject trap in activeTraps)
            {
                if (trap.GetComponent<ArrowDifficulty>() != null)
                {
                    trap.GetComponent<ArrowDifficulty>().difficulty = difficulty;
                }
                else if (trap.GetComponent<SpikeDifficulty>() != null)
                {
                    trap.GetComponent<SpikeDifficulty>().difficulty = difficulty;
                }
                else if (trap.GetComponent<AxeDifficulty>() != null)
                {
                    trap.GetComponent<AxeDifficulty>().difficulty = difficulty;
                }

            }
    }

    void Update()
    {
        if (updateDifficulty)
        {
            AlterPuzzleDifficulty(puzzlingDifficulty);
            AlterTrapDifficulty(trapDifficulty);
            updateDifficulty = false;
        }
    }
}
