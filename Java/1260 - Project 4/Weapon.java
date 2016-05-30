
public abstract class Weapon
{
	private static final String	DEFAULT_NAME	= "weapon";	// The default name
	private static final int	DEFAULT_DAMAGE	= 0;	// The default damage
	protected String name;		// The name of the weapon, to be displayed to the user.
	protected int damage;	// The damage modifier of the weapon.



	
	public Weapon()
	{
		this(DEFAULT_NAME, DEFAULT_DAMAGE);  // no arg constructor creates a weapon of default name and damage
	}

	

	public Weapon (String name, int damage) // allows creation of weapon with name and damage as parameters
	{
		setName(name); // sets the name of the weapon
		setDamage(damage); // sets the damage of the weapon
	}

	
	public abstract Weapon take(); // abstract method take().


	
	public String getName()
	{
		return name; // returns the name of the weapon
	}


	
	public void setName(String name)
	{
		this.name = name; // sets the name
	}


	
	public abstract void setDamage(int damage); // abstact method to set the damage


	
	public abstract int getDamage(); // abstract method to return the damage of a weapon

	public String toString() // returns a string of the damage and name of the weapon
	{
		return "+" + getDamage() + " " + getName();
	}
}