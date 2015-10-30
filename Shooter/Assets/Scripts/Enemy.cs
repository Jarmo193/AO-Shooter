using UnityEngine;
using System.Collections;

// vihollisen pääluokan runko, ei mitään kiveen hakattua
public class Enemy : MonoBehaviour
{
    public Transform ammoType; // mitä ammuksia vihollinen ampuu
	public int weaponCooldown = 90; // ampumisen aikaväli freimeinä
	public int bulletAmount = 1; // panosten määrä per laukaus
	public float bulletSpread = 5.0f; // ammusten väli

    /* ie. forward, down, player, behind(miinoja varten) */
    public string shootDirection;

    protected Vector3 shootDir = Vector3.zero;

	private int cooldown;

	// Use this for initialization
	void Start ()
    {
		cooldown = weaponCooldown;
		inverseShootDir ();
    }

    protected void inverseShootDir()
    {
        shootDir += new Vector3(0, 0, 180);
        if(shootDir.z > 360)
            shootDir -= new Vector3(0, 0, 360);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		cooldown++;
		if(weaponCooldown <= cooldown)
        {
            shoot();
			cooldown = 0;
        }
	}

    protected virtual void shoot() // <- virtual sana override komentoa varten lapsi luokissa
	{
		/*
		// spread = ammusten väli
		_global.multiShotPlayer = function(Name:String, spd:Number, Dir:Number, Spread:Number, Amount:Number):Void
		{
			var obj:Object = {x:0,y:0};
			player.player_mc.localToGlobal(obj);
			
			for(var temp = (-Amount/2); temp < (Amount/2); temp++)
			{
				_global.McBul[_global.bulAmount] = allBullets.createNew(Name, spd, obj.x, obj.y, (Dir + (temp*Spread) + (Spread/2)));
			}
		}
		*/
		if(bulletAmount > 1)
		{
			for(float temp = (float)((float)-bulletAmount/2); temp < (float)((float)bulletAmount/2); temp++)
			{
				Transform bul = Instantiate(ammoType, transform.position, Quaternion.Euler(transform.eulerAngles + shootDir + new Vector3(0, 0, (temp*bulletSpread) + (bulletSpread/2)))) as Transform;
				bul.tag = "EnemyBullet";
			}
		}
		else
		{
	        Transform bul = Instantiate(ammoType, transform.position, Quaternion.Euler(transform.eulerAngles + shootDir)) as Transform;
	        bul.tag = "EnemyBullet";
		}
    }
}
