

import java.util.Random;

public class Player extends Participant
{

	private String name;					// The name the player wishes to be called
	private double health;					// The health of the player. If this reaches 0, the player is dead
	private Weapon weapon;
	private boolean alive;

	private 	   final double HIT_CHANCE = 90;	// The chance for the player to hit. 10 = a 10% chance to hit an enemy.
	private 	   final int DEFAULT_DAMAGE = 5; // sets the default damage to 5
	private static final String	DEFAULT_NAME	= "Ishan"; // sets the default name to 'Ishan'
	private static final double	DEFAULT_HEALTH	= 100; // sets the default health to 100

	
	public Player() // sets a default  player
	{
		this(DEFAULT_NAME, DEFAULT_HEALTH, null, true);
	}

	
	public Player (String name, double health) // allows a player to be created with a name and health
	{
		this(name, health, null, true);
	}


	
	public Player(String name, double health, Weapon weapon, boolean alive)
	{
		setName(name);  // sets the name
		setHealth(health);  // sets the health
		setWeapon(weapon);  // sets the weapon
		setAlive(alive);  // boolean value for whether the play is alive
	}

	
	public void setAlive(boolean alive)
	{
		this.alive = alive;		
	}

	
	public Player (Player player)
	{
		this(player.getName( ), player.getHealth( ), player.getWeapon( ), player.isAlive( ));
	}


	
	public int attack()
	{
		Random rand = new Random();  // creates an object of the Random Class called rand

		int attackRoll = rand.nextInt(100) + 1; // attackRoll is a random number from 1 to 100

		if(attackRoll <= HIT_CHANCE) // if the attackRoll is in the range of "hits"
		{
			return DEFAULT_DAMAGE + (weapon != null? weapon.getDamage( ): 0); // returns default damagage plus any extra damage from weapons
		}

		else
		{
			return 0; // if the attack misses, return zero
		}
	}

	
	public void takeDamage(int damage)
	{
		setHealth(getHealth() - damage); // subtracts the parameter damage from the objects health
	}

	public String getName ( )
	{
		return name;  // returns the name of the player
	}

	public double getHealth ( )
	{
		return health; // retuns the health of the player
	}

	
	public void setName (String name)
	{
		this.name = name; // sets the name of the player
	}

	public void setHealth (double health)
	{
		this.health = health;  // sets the health of the player
	}

	
	public Weapon getWeapon()
	{
		return (weapon != null? weapon.take(): null);  // returns the players weapon if one exists
	}

	
	public void setWeapon(Weapon weapon)
	{
		if (weapon != null)
			this.weapon = weapon.take( ); // if the weapon isn't null, copy it 
		else
			this.weapon = null;  // else, set it to null
	}


	public String toString()  // returns everything as a string
	{

		return "Player " + getName() + " has " + getHealth()  ;
	}

	public boolean isAlive()
	{
		return alive;
	}

}