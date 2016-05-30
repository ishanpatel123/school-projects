/************************************************************************************
* -----------------------------------------------------------------------------------
* File name: Advisee.java
* Project name: CSCI 1250 Project 5
* -----------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 11/28/2013
* Date of Last Modification: 11/28/2013
* -----------------------------------------------------------------------------------
*/ 

/***************************************************************************
* Class Name: Advisee <br>
* Class Purpose: Advisee <br>
*
* <hr>
* Date created: 11/24/2012 <br>
* Date last modified: 12/5/2012
* @author Ishan Patel
*/
public class Advisee
{
	//**********************CLASS ATTRIBUTES********************
	private String name;			//To hold the student's name
	private String studentID;		//To hold the students's ID
	private String concentration;	//To hold student's concentration
	private int numOfHours;			//To hold student's number of hrs
	private String advisor;			//To hold student's advisor name
	private boolean majorSheet;		//To hold value if student has filed a major sheet
	private boolean intentToGrad;	//To hold value if student has filed intent to grad
	
	//**********************CLASS METHODS***********************
	//------------------	CONSTRUCTORS	--------------------
	public Advisee()
	{
		//initialize all calss attributes to default values
		setName("XXX XXXXX");
		setStudentID("XXXXXXXX");
		setConcentration("XX");
		setNumOfHours(0);
		setAdvisor("XXX XXXXX");
		setMajorSheet(false);
		setIntentToGrad(false);
	}//end Advisee()
	
	public Advisee(String strName, String ID, String conc, int numhours, 
					String strAdvisor, boolean ms, boolean graduate)
	{
		//initialize all calss attributes to values passed in
		setName(strName);
		setStudentID(ID);
		setConcentration(conc);
		setNumOfHours(numhours);
		setAdvisor(strAdvisor);
		setMajorSheet(ms);
		setIntentToGrad(graduate);
	}//end Advisee(String, String, String, int, String, boolean, boolean)
	
	public Advisee(Advisee a1)
	{
		//create all copy attributes and assign them to a1
		name = a1.name;
		studentID = a1.studentID;
		concentration = a1.concentration;
		numOfHours = a1.numOfHours;
		advisor = a1.advisor;
		majorSheet = a1.majorSheet;
		intentToGrad = a1.intentToGrad;
		
	}//end Advisee(Advisee)
	
	//------------------	SETTERS		------------------------
	/**  
	 * Method Name: setName <br>
	 * Method Purpose: accepts an argument for the student's name. <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date last modified: 11/28/2013 <br>
	 * <hr>
	 *   @param  n1 String representing student's name
	 *   @return nothing
	*/ 
	public void setName(String strName)
	{
		name = strName;
	}//end setName(String)

	/**
	 * Method Name: setStudentID <br>
	 * Method Purpose: accepts an arguement for the student's id.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param stuID String representing student's id
	 * @return nothing
	*/	
	public void setStudentID(String stuID)
	{
		studentID = stuID;
	}//end setStudentID(String)

	/**
	 * Method Name: setConcentraion <br>
	 * Method Purpose:accepts an arguement for the 
	 *  				student's concentration.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param con String representing student's concentration
	 * @return nothing
	*/	
	public void setConcentration(String concentration)
	{
		if(concentration.equals("CS"))
		{
			this.concentration = "CS";
		}
		else if(concentration.equals("IS"))
		{
			this.concentration = "IS";
		}
		else if(concentration.equals("IT"))
		{
			this.concentration = "IT";
		}
		else
		{
			this.concentration = "XX";
		}
	}//end setConcentration

	/**
	 * Method Name: setNumOfHours <br>
	 * Method Purpose: accepts an argument for
	 * 					the student's completed hours
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param numhrs String representing student's hours
	 * @return nothing
	*/	
	public void setNumOfHours(int numhrs)
	{
		numOfHours = numhrs;
	}//end setNumOfHours(int)
	
	/**
	 * Method Name: setAdvisor <br>
	 * Method Purpose:  accepts an arguement for
	 *					  the student's advisor.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param adv String representing student's advisor
	 * @return nothing
	*/
	public void setAdvisor(String adv)
	{
		advisor = adv;
	}//end setAdvisor(adv)

	/**
	 * Method Name: setMajorSheet <br>
	 * Method Purpose:  accepts an argument if the
	 *					  student has filed a major sheet.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  mjr boolean representing if the student 
	 *			has filed a major sheet or not.
	 * @return nothing
	*/
	public void setMajorSheet(boolean mjr)
	{
		majorSheet = mjr;
	}//end setMajorSheet(boolean)
	
	/**
	 * Method Name: setIntentToGrad <br>
	 * Method Purpose:  accepts an argument if the
	 *					  student has filed a intent to grad.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  graduate boolean representing if the student 
	 *			has filed a intent to graduate.
	 * @return nothing
	*/
	public void setIntentToGrad(boolean graduate)
	{
		intentToGrad = graduate;
	}//end setIntentToGrad(boolean)
	
	//------------------	GETTERS		------------------------
	/**
	 * Method Name: getName <br>
	 * Method Purpose:  return the student's name.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's name
	*/
	public String getName()
	{
		String strName;
		strName = name;
		return strName;
	}//end getName()
	
	/**
	 * Method Name: getStudentID <br>
	 * Method Purpose:  return the student's id.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's id
	*/	
	public String getStudentID()
	{
		String strId;
		strId = studentID;
		return strId;
	}//end getStudentID()
	
	/**
	 * Method Name: getConcentration <br>
	 * Method Purpose:  return the student's concentration.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's concentration
	*/	
	public String getConcentration()
	{
		String strConcentration;
		strConcentration = concentration;
		return strConcentration;
	}//end getConcentration()
	
	/**
	 * Method Name: getNumOfHours <br>
	 * Method Purpose:  return the student's completed hours.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's completed hours
	*/		
	public int getNumOfHours()
	{
		int iNumOfHours;
		iNumOfHours = numOfHours;
		return iNumOfHours;
	}//end getNumOfHours()
	
	/**
	 * Method Name: getAdvisor <br>
	 * Method Purpose:  return the student's advisor.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's advisor
	*/			
	public String getAdvisor()
	{
		String strAdvisor;
		strAdvisor = advisor;
		return strAdvisor;
	}//end getAdvisor()
	
	/**
	 * Method Name: getmajorSheet <br>
	 * Method Purpose:  return the value for student's major sheet.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's major sheet value
	*/		
	public boolean getMajorSheet()
	{
		boolean blnMajorSheet;
		blnMajorSheet = majorSheet;
		return blnMajorSheet;
	}//end getMajorSheet()
	
	/**
	 * Method Name: getIntentToGrad <br>
	 * Method Purpose:  return the value for student's 
	 *					intent to graduate form.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's intent to grad form value
	*/		
	public boolean getIntentToGrad()
	{
		boolean blnIntentToGrad;
		blnIntentToGrad = intentToGrad;
		return blnIntentToGrad;
	}//end getIntentToGrad()
	
	//-----------------	OTHER CLASS METHODS --------------------
	/**
	 * Method Name: getClassification <br>
	 * Method Purpose:  get student's classification
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return student's classification
	*/	
	public String getClassification()
	{
		String classification = "";
		
		if(numOfHours >= 90)
			classification = "Senior";
		else if(numOfHours >= 60 && numOfHours <= 89)
			classification = "Junior";
		else if(numOfHours >= 30 && numOfHours <= 59)
			classification = "Sophomore";
		else
			classification = "Freshman";
			
		return classification;
	}//end getClassification()
	
	/**
	 * Method Name: metGraduationRequirements <br>
	 * Method Purpose: determine if the student met
	 * 					all requirements for graduation.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return a value if student has met graduation requrements
	*/
	public boolean metGraduationRequirements()
	{
		boolean gradRequirements = false;
		
		int hours = getNumOfHours();
		boolean intentToGrad = getIntentToGrad();
		boolean stuMajor = getMajorSheet();					
		if(hours >= 120 && intentToGrad == true && stuMajor == true) 
			gradRequirements = true;
		
		return gradRequirements;
	}//end metGraduationRequirements()

	/**
	 * Method Name: clearedToGraduateMsg <br>
	 * Method Purpose: displays a message if the student
	 *					is cleared to graduate or not.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 * @param  nothing
	 * @return a message if the student is cleared to graduate or not
	*/
	public String clearedToGraduateMsg()
	{
		String clearedmsg = "";
		String creditmsg = "";
		String intentmsg = "";
		String majormsg = "";
		int hours;
		boolean metGradRequirements;
		boolean credit;
		boolean intent;
		boolean major;
		
		//calls method to assign the value
		hours = getNumOfHours();
		metGradRequirements = metGraduationRequirements();
		intent = getIntentToGrad();
		major = getMajorSheet();
		
		if(hours >= 120)
			credit = true;		
		else 						
			credit = false;
			
		if(credit == false)
			 creditmsg = " Not enough hours.";	
		else creditmsg = "";						
 
		if(intent == false)
			 intentmsg = " Not filed intent to graduate.";	
		else intentmsg = "";									
 
		if(major == false)
			 majormsg = " Not completed major sheet.";		
		else majormsg = "";									
 
		if(metGradRequirements == false)		
			clearedmsg = ("No -" + creditmsg + intentmsg + majormsg); 
		else
			clearedmsg = ("Yes - all requirements have been met");
		return clearedmsg;
	
	}//end clearedToGraduateMsg()

	/**
	 * Method Name: equals <br>
	 * Method Purpose: to determine if the objects are
	 *					equal or not.
	 *  <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 *  @param Advisee2 Advisee representing objects equality
	 *  @return a status if the objects are equal or not
	*/
	public boolean equals(Advisee Advisee2)
	{
		boolean status;
		
		if (name.equals(Advisee2.name)&&
			studentID.equals(Advisee2.studentID)&&
			concentration.equals(Advisee2.concentration)&&
			numOfHours == Advisee2.numOfHours&&
			advisor.equals(Advisee2.advisor)&&
			majorSheet == Advisee2.majorSheet&&
			intentToGrad == Advisee2.intentToGrad)
			
			status = true;	//yes, the objects are equal
		else
			status = false;	//no, the objects are not equal
			
			return status;
	}//end equals()

	/**
	 * Method Name: toString <br>
	 * Method Purpose: create a string containing all
	 *						the advisee's information for output.
	 * <br>
	 *
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date Last modified: 12/28/2013 <br>
	 *
	 * <hr>
	 *  @return string containing the advisee's information
	*/
	public String toString()
	{
		String classification = "";
		String clearedToGraduate = "";
		classification = getClassification();
		clearedToGraduate = clearedToGraduateMsg();
		//display all the information
		String str = "Advisee Information"
					+ "\n --------------------------------------------\n"
					+ "\n Name:  " + this.name
					+ "\n id:  " + this.studentID
					+ "\n\n Advisor:  " + this.advisor
					+ "\n\n Concentration:  " + this.concentration
					+ "\n Completed Hours:  " + this.numOfHours
					+ "\n Classification:  " + classification
					+ "\n Cleared for graduation:  " + clearedToGraduate;
					
		return str;
	}//end toString()
}//end Advisee class