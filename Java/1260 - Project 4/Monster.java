import java.util.Random;


public class Monster
{
	private static final int	HEALTH	= 20;  // default health of a monster
	private static final String	NAME	= "monster";  // default name of a monster
	private static final int	DAMAGE	= 5;  // default damage of a monster

	private int health;  // holds health of a monster
	private final int HIT_CHANCE = 20; // hit chance of monsters

	private String name;  // holds name of a monster
	private int damage;  // holds damage of a monster



	
	public Monster()
	{
		this(NAME, HEALTH, DAMAGE); // creates a monster witih default name, health, and damage
	}

	
	public Monster(String name, int health, int damage)
	{
		setHealth(health); // sets health of monster
		setName(name); // sets the name of monster
		setDamage(damage); // sets the damage of monster
	}

	public Monster(Monster monster)
	{
		this(monster.getName( ), monster.getHealth( ), monster.getDamage( ));
	}

	
	public int getHealth()
	{
		return health; // returns the health of a monster
	}

	
	public void setHealth(int health)
	{
		this.health = health; // sets the health of a monster
	}

	
	public String getName()
	{
		return name; // returns the name of a monster
	}

	public void setName(String name)
	{
		this.name = name; // sets the name of a monster
	}

	
	public int getDamage()
	{
		return damage;  // returns the damage done by a monster
	}

	
	public void setDamage(int damage)
	{
		this.damage = damage; // sets the damage done by a monster
	}

	
	public int attack()
	{
		Random rand = new Random();  // object of the Random class named rand

		int attackRoll = rand.nextInt(100) + 1;  // attackRoll is a random number between 1 and 100

		if (attackRoll < HIT_CHANCE + 1) // if attackroll is less than 80 
		{
			return damage;  // return damage
		}
		else
			return 0; // if it is a miss, return zero
	}

	
	public void takeDamage(int damage)
	{
		setHealth(getHealth() - damage);  // subtracts the damage from the health of the monster
	}

	public String toString()
	{
		return " Monster was hit points  :" + getHealth();  // "monster with 100 hp"
	}

}
