import java.util.Scanner;


public class Utility
{


	public static void clearScreen()
	{
		System.out.print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	
	}//end clearScreen()


	public static void freezeScreen(Scanner sam)
	{
		System.out.print("\n\t\t -- Press Enter to Continue --\n");
		sam.nextLine();
	}//end freezeScreen(Scanner)


	
	public static void myInfo(String date, String assign)
		{
			System.out.print("\n\n\tName:   Ishan Patel");
			System.out.print("\n\tClass:  CSCI 1250-201");
			System.out.print("\n\tDate:   " + date);
			System.out.println("\n\tAssign: "+ assign);
		}//end myInfo
	
}//end Utility