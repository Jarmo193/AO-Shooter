using UnityEngine;
using System.Collections;

public class EnemyBurst : Enemy
{
    public float burstInterval = 0.33f; // aikaväli panoksilla sarjatulessa
    public int burstAmount = 3; // sarjan panosten määrä

	// Use this for initialization
	void Start ()
    {
        inverseShootDir();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    protected override void shoot() // <- yliajaa Enemy luokan shoot funktion
    {
        // base.shoot(); // <- lisää Enemy luokan shoot funktion tähän funktioon

		for(int i = 0; i < burstAmount; i++)
			Invoke ("burst", burstInterval*i);

        // oma lisäys/muutos funktioon
    }

	public void burst()
	{
		Transform bul = Instantiate(ammoType, transform.position, Quaternion.Euler(transform.eulerAngles + shootDir)) as Transform;
		bul.tag = "EnemyBullet";
	}
}
