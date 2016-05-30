
public abstract class Participant {
    
	private int playerX;	// The players x location in the dungeon.
	Player player;
	private Participant[] rooms = new Participant[6];;
	
	public void enterDungeon(Player player)
	{
		playerX = 0;

		rooms[playerX].setPlayer(player);
	}
	
	public void setPlayer(Player player)
	{
		this.player = (new Player(player)); // copyies a player to the Player
	}
	
	public Player getPlayer()
	{
		return (new Player(player)); // returns a player
	}
}
