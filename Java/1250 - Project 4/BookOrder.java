/************************************************************************************
* -----------------------------------------------------------------------------------
* File name: BookOrder.java
* Project name: CSCI 1250 Project 3
* -----------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 11/05/2013
* Date of Last Modification: 11/05/2013
* -----------------------------------------------------------------------------------
*/ 
import java.text.DecimalFormat;

/************************************************************************************
* Class Name: BookOrdrer <br>
* Class Purpose: Simple program in Java that should  create a setter and getters for 
* author, title, quantity, costPerBook, orderDate, weight, type for BookOrder class.
* This class also contain calculated methods and invoice method for display all 
* information contained in this class.
*
* Date created: 11/05/2013 <br>
* Date last modified: 11/05/2013
* @author Ishan Patel
*/

public class BookOrder
{
	public String author; 			//author of the book
	public String title;			//title of the book
	private int quantity; 			// quantity of the book
	private double costPerBook; 	//cost of the book
	private String orderDate; 		//order date of the book
	private double weight;			//weight of the book
	private char type;				//type of the book
	
	/**  
	 * Method Name: BookOrder <br>
	 * Method Purpose: Default constructor for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return nothing
	 */	
	public BookOrder() {}//end of BookOrder
	
	/**  
	 * Method Name: BookOrder <br>
	 * Method Purpose: overload constructor of attribute author and title for 
	 * BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  author - author of the book
	 *	 @param	 title - title of the book
	 *   @return nothing
	 */
	public BookOrder(String author, String title)
	{
		setAuthor(author);
		setTitle(title);
	}//end BookOrder(String, String)

	/**  
	 * Method Name: BookOrder <br>
	 * Method Purpose: overload constructor of attribute author, title, quantity 
	 * costPerBook, orderDate, weight, type for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param author - author of the book
	 *   @param title - title of the book
	 *   @param quantity - quantity of the book
	 *   @param costPerBook - cost of the book
	 *   @param orderDate - order date of the book
	 *   @param weight - weight of the book
	 *   @param type - type of the book
	 *   @return nothing
	 */
	public BookOrder(String author, String title, int quantity,
		double costPerBook, String orderDate, double weight,char type)
	{
		setAuthor(author);
		setTitle(title);
		setQuantity(quantity);
		setCostPerBook(costPerBook);
		setOrderDate(orderDate);
		setWeight(weight);
		setType(type);
	}//end BookOrder(String,String, int, double,String, double, char)
	
	/**  
	 * Method Name: BookOrder <br>
	 * Method Purpose: copy constructor for BookOrder class<br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param bookOrder - copy all attributes of BookOrder
	 *   @return nothing
	 */
	public BookOrder(BookOrder bookOrder)
	{
		this.author = bookOrder.author;
		this.title = bookOrder.title;
		this.quantity = bookOrder.quantity;
		this.costPerBook = bookOrder.costPerBook;
		this.orderDate = bookOrder.orderDate;
		this.weight = bookOrder.weight;
		this.type = bookOrder.type;
	}//end BookOrder(BookOrder)
	/**  
	 * Method Name: setAuthor <br>
	 * Method Purpose: set the author of book for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  author - author of the book
	 *   @return nothing
	 */
	public void setAuthor(String author)
	{
		this.author = author;
	}//end setAuthor(String)
	
	/**  
	 * Method Name: setTitle <br>
	 * Method Purpose: set the title of book for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  title - title of the book
	 *   @return nothing
	 */
	public void setTitle(String title)
	{
		this.title = title;
	}//end setTitle(String)

	/**  
	 * Method Name: setQuantity <br>
	 * Method Purpose: set the quantity of book for BookOrder class.
	 * Quantity should be positive number. Negetive number will be zero <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  quantity - quantity of the book
	 *   @return nothing
	 */
	public void setQuantity(int quantity)
	{
		if(quantity >=0)
		{
			this.quantity = quantity;
		}
		else
		{
			this.quantity = 0;
		}
	}//end setQuantity(int)

	/**  
	 * Method Name: setCost <br>
	 * Method Purpose: set the cost of book for BookOrder class.
	 * costperBook should be positive number. Negetive number will be zero <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  costPerBook - cost of the book
	 *   @return nothing
	 */
	public void setCostPerBook(double costPerBook)
	{
		if(costPerBook >= 0.0)
		{
			this.costPerBook = costPerBook;
		}
		else
		{
			this.costPerBook = 00;
		}
	}//end setCost(double)
	
	/**  
	 * Method Name: setDate <br>
	 * Method Purpose: set the date of book for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  orderDate - order date of the book
	 *   @return nothing
	 */
	public void setOrderDate(String orderDate)
	{
		this.orderDate = orderDate;
	}//end setDate(String)
	
	/**  
	 * Method Name: setWeight <br>
	 * Method Purpose: set the weight of book for BookOrder class.
	 * weight should be positive number. Negetive number will be zero<br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  weight - weight of the book
	 *   @return nothing
	 */
	public void setWeight(double weight)
	{	
		if(weight >= 0.0)
		{
			this.weight = weight;
		}
		else
		{
			this.weight = 0.0;
		}		
	}//end setweight(String)
	
	/**  
	 * Method Name: setType <br>
	 * Method Purpose: set the type of shipping for BookOrder class <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  type - type of the book
	 *   @return nothing
	 */
	public void setType(char type)
	{
		this.type = type;
	}//end setType(char)

	/**  
	 * Method Name: assignValues   <br>
	 * Method Purpose: set all attributes accept author and title <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   
	 *	 @param quantity - quantity of the book
	 *   @param costPerBook - cost of the book
	 *   @param orderDate - order date of the book
	 *   @param weight - weight of the book
	 *   @param type - type of the book
	 *   @return nothing
	 */
	public void assignValues(int quantity, double costPerBook, 
	String orderDate, double weight,char type)
	{
		setQuantity(quantity);
		setCostPerBook(costPerBook);
		setOrderDate(orderDate);
		setWeight(weight);
		setType(type);
	}//end assignvalues(int,double,String,double,char)
	
	/**  
	 * Method Name: getAuthor <br>
	 * Method Purpose: get the author of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return the author of book
	 */
	public String getAuthor()
	{
		String strAuthor;
		strAuthor = this.author;
		return strAuthor;
	}//end getAuthor()
	
	/**  
	 * Method Name: getTitle <br>
	 * Method Purpose: get the title of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return title of the book
	 */
	public String getTitle()
	{
		String strTitle;
		strTitle = this.title;
		return strTitle;
	}//end getTitle()
	
	/**  
	 * Method Name: getQuantity <br>
	 * Method Purpose: get the quantity of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return quantity of the book
	 */
	public int getQuantity()
	{
		int iQuantity;
		iQuantity = this.quantity;
		return iQuantity;
	}//end getQuantity()
	
	/**  
	 * Method Name: getCost <br>
	 * Method Purpose: get the cost of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return costPerBook of the book
	 */
	public double getCostPerBook()
	{
		double dCostPerBook;
		dCostPerBook = this.costPerBook;
		return dCostPerBook;
	}//end getCost()
	
	/**  
	 * Method Name: getDate <br>
	 * Method Purpose: get the date of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return order date of the book
	 */
	public String getOrderDate()
	{
		String strOrderDate;
		strOrderDate = this.orderDate;
		return strOrderDate;
	}//end getDate()
	
	/**  
	 * Method Name: getWeight <br>
	 * Method Purpose: get the weight of book <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return weight of the book
	 */
	public Double getWeight()
	{
		double dWeight;
		dWeight = this.weight;
		return dWeight;
	}//end getWeight()
	
	/**  
	 * Method Name: getType <br>
	 * Method Purpose: get the type of shipping <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return the type of the book
	 */
	public char getType()
	{		
		if(this.type == 'r' || this.type == 'R')
		{
			type = 'R';
		}
		else if(type == 'o' || type == 'O')
		{
			type = 'O';
			}
		else if(type == 'p' || type == 'P')
		{
			type = 'P';
			}
		else if(type == 'f' || type == 'F')
		{
			type = 'F';
			}
		else if(type == 'u' || type == 'U')
		{
			type = 'U';
			}
		else if(type == 'n' || type == 'N')
		{
			type = 'N';	
		}
		return type;		
	}//end getType()
	
	/**  
	 * Method Name: adjustQuantity   <br>
	 * Method Purpose: adjust the negetive quantity to zero <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return nothing
	 */
	public void adjustQuantity(int quantity)
	{
		if(quantity <= 0)
		{
			quantity = 0;
		}
		else
		{
			this.quantity = quantity;
		}
	}//end adjustQuantity(int)

	/**  
	 * Method Name: totalweight   <br>
	 * Method Purpose: set total weight by multiplying quantity and weight of books<br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return total weight of the book
	 */
	public double totalweight()
	{		
		double dWeight;
		dWeight = this.quantity * this.weight;
		return dWeight;
	
	}//end totalweight()
	
	/**  
	 * Method Name: calcCost <br>
	 * Method Purpose: set the cost which multiplying quantity and costPerBook <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return calculated cost of the book
	 */
	public double calcCost()
	{
		double dCost;
		dCost = this.quantity * this.costPerBook;
		return dCost;
	}//end calcCost()
	
	/**  
	 * Method Name: shipping <br>
	 * Method Purpose: set the shipping rate to its type of order <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return return the total shipping cost of book
	 */
	public double shipping()
	{
		double dShipping, dShippingRate;
		
		if(type == 'R')
		{
			dShippingRate = 0.30;
		}
		else if(this.type == 'O')
		{
			dShippingRate = 0.50;
		}
		else if(this.type == 'P')
		{
			dShippingRate = 0.10;
		}
		else if(this.type == 'F')
		{
			dShippingRate = 0.25;
		}
		else if(this.type == 'U')
		{
			dShippingRate = 0.30;
		}
		else 
		{
			dShippingRate = 0.05;
		}
		
		dShipping = dShippingRate * this.weight * quantity;
		return dShipping;
	}//end shipping()

	/**  
	 * Method Name: totalCost <br>
	 * Method Purpose: total cost is depends on total cost and shipping <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return total cost of the book shipping
	 */
	public 	double totalCost()
	{
		double totalCost;
		double dShipping = shipping();
		double dCost = calcCost();
		totalCost =  dShipping + dCost;
		return totalCost;
	}//end totalCost()
	
	/**  
	 * Method Name: invoice <br>
	 * Method Purpose: display information of BookOrder class in String format <br>
	 *
	 * <hr>
	 * Date created: 11/05/2013 <br>
	 * Date last modified: 11/05/2013 <br>
	 * <hr>
	 *   @param  N/A
	 *   @return String contained all information of BookOrder class
	 */
	public String invoice()
	{
		String str;
		Proj4 p = new Proj4();
		str = "The" + p.f();
		return str;
	}
	
}