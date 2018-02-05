using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	//Chosen Char Stats
	[SerializeField] private int playerHealth;
	public int playercurrentHealth;
	[SerializeField] private int atk;
	public GameObject hand;
	public Image charPortrait;

	// Portraits
	public Sprite nevePortrait;
	public Sprite asgorPortrait;
	public Sprite dariusPortrait;

	//Which Char is it?
	public bool isNeve;
	public bool isAsgor;
	public bool isDarius;

	//Attack, Damage & Regen
	public bool underAttack;
	public bool isHealing;
	public Image healthBar;
    bool invulnerable;
    public int invulnerabilityTime;
    float internalInvulnerable;

	//Raycast
	public RaycastHit hit;
    Ray ray;


	// Use this for initialization
	void Start () {
        invulnerable = false;

		if(isNeve == true)
		{
			playerHealth = 115;
			atk = 40;
			charPortrait.sprite = nevePortrait;
			hand.transform.GetChild(0).gameObject.SetActive(true);
		}

		if(isAsgor == true)
		{
			playerHealth = 135;
			atk = 25;
			charPortrait.sprite = asgorPortrait;
			hand.transform.GetChild(2).gameObject.SetActive(true);
		}

		if(isDarius == true)
		{
			playerHealth = 125;
			atk = 35;
			charPortrait.sprite = dariusPortrait;
			hand.transform.GetChild(1).gameObject.SetActive(true);
		}

		playercurrentHealth = playerHealth;
        underAttack = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		 Debug.DrawRay(transform.position, transform.forward, Color.green);
		 healthBar.fillAmount = (float)playercurrentHealth / (float)playerHealth;

		if(Physics.Raycast(ray, out hit, 20))
         {
			 Debug.Log(hit.collider.gameObject.name);
         }

		if(Input.GetButtonDown("Fire1"))
		{
			hand.gameObject.GetComponent<Animator>().SetBool("isAttacking", true);

            try
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyAI>().enemycurrentHealth -= atk;
                }
            }
            catch { }
		}

		else
		{
			hand.gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		}

		// Health regen

		if( underAttack == false && isHealing == false && playercurrentHealth < playerHealth)
		{
		StartCoroutine(PlayerRegen());
			isHealing = true;
		}

		//Death
			if(playercurrentHealth <= 0)
			{
				GameOver();
			}

        if (invulnerable)
        {
            internalInvulnerable -= Time.deltaTime;
            if (internalInvulnerable <= 0)
                invulnerable = false;
        }
	}

	void GameOver()
	{
		//gameover
	}

	IEnumerator PlayerRegen()
	{
		while(playercurrentHealth < playerHealth)
		{
			yield return new WaitForSeconds(2);
			playercurrentHealth += 5;
		}

		if(playercurrentHealth == playerHealth)
		{
			isHealing = false;
		}
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damaging" && !invulnerable)
        {
            internalInvulnerable = invulnerabilityTime;
            invulnerable = true;
            playercurrentHealth -= 40;
        }
    }


}
