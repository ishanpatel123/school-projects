import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.image.BufferedImage;

import javax.imageio.ImageIO;
import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;

/**
 * ---------------------------------------------------------------------------
 * File name: menuWindow.java
 * Project name: Project 5 
 * ---------------------------------------------------------------------------
 * Creator's name and email: Ishan Patel, pateli@goldmail.etsu.edu
 * Course-Section:  CSCI 1260 - 201
 * Creation Date: May 02, 2013
 * Date of Last Modification: May 02, 2013
 * ---------------------------------------------------------------------------
 */

/**
 * Window for displaying pixfiles<br>
 *
 * <hr>
 * Date created: May 02, 2013<br>
 * Date last modified: May 02, 2013<br>
 * <hr>
 * @author Ishan Patel
 */


public class menuWindow extends JFrame {
	
	private JMenuBar 		menuBar;
	private JMenu 			fileMenu,
							searchMenu, 
							helpMenu;
	private JMenuItem		newItem, 
							exitItem,
							openItem,
							saveItem,
							nameItem,
							photographerItem,
							showAllItem,
							MINMAXItem,
							sortItem,
							deleteItem,
							helpItem;
	private JPanel 			namePanel, 
							selectpixfilePanel,
							imagePanel;
	private JLabel 			namelabel, 
							photographerlabel,
							typelabel, 
							sizelabel, 
							imageLabel;
	private JTextField 		nameTextField,
							photographerTextField,
							typeTextField, 
							sizeTextField;
	
	private JList<String> nameList;
	private BufferedImage imgIcon = null;
	private	boolean listChanged = false;

	String key;		// Key to search on
	pixfile p;		// One pixfile found
	String pixfilemsg = "Photo Tracker"; // Header for JOptionPane
	pixList plist = new pixList();	           // List of pixfiles
	FileManager fmgr = new FileManager();      // File manger object



	
	public menuWindow()
	{
		super ("Photo - Tracker");
		this.setSize(700, 550);
		this.setDefaultCloseOperation (JFrame.EXIT_ON_CLOSE);
		setLayout(new BorderLayout( ));

		
		buildMenuBar( );	// Put the menubar into the frame
		
		buildNamePanel( );	// put the JList in the namePanel 
		add(namePanel, BorderLayout.WEST);

		buildselectpixfilePanel( );	// put labels and textfields in selectpixfilePanel 
		add(selectpixfilePanel,BorderLayout.CENTER );
		
		add(imagePanel,BorderLayout.SOUTH );	// put the image icon in the imagePanel
		
		setLocationRelativeTo(null);
		setVisible(true);
	}

	/**
	 * add Jlist and namePanel for all events <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013 <br>
	 * Date last modified: May 02, 2013 <br>
	 *
	 * <hr>
	 */
	
	private void buildNamePanel(){
		// Register listeners for all events for the components
		// such as JList, namePanel, etc.
		
		plist = fmgr.getFile();	//get the text file from fillmanager class
		
		String[] s = plist.getTitles();
		namePanel = new JPanel();

		nameList = new JList<String>(s);
		nameList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		
		int i = nameList.getSelectedIndex();
		nameList.setSelectedIndex(i);
		nameList.addListSelectionListener(new  handler());
		nameList.setVisibleRowCount(6);
		JScrollPane scrollpane = new JScrollPane(nameList);
		namePanel.add(scrollpane);		
		
	}
	
	/**
	 * add JList and JPanel for all TextFields and JLabel <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013 <br>
	 * Date last modified: May 02, 2013 <br>
	 *
	 * <hr>
	 */
	
	private void buildselectpixfilePanel(){
		
		// add JLebels and TextFields to JPanels
		selectpixfilePanel = new JPanel();
		
		namelabel = new JLabel("File Name");
		nameTextField = new JTextField(40);
		nameTextField.setEditable(false);
		
		photographerlabel = new JLabel("Photographer");
		photographerTextField = new JTextField(40);
		photographerTextField.setEditable(false);
 		typelabel = new JLabel("FileType");
		typeTextField =  new JTextField(10);
		typeTextField.setEditable(false);
		
		sizelabel = new JLabel("File Size (MB)");
		sizeTextField =  new JTextField(10);
		sizeTextField.setEditable(false);

		imagePanel= new JPanel();
		imageLabel = new JLabel();
		imagePanel.add(imageLabel);
		
		selectpixfilePanel.add(namelabel);
		selectpixfilePanel.add(nameTextField);

		selectpixfilePanel.add(photographerlabel);
		selectpixfilePanel.add(photographerTextField);

		selectpixfilePanel.add(typelabel);
		selectpixfilePanel.add(typeTextField);

		selectpixfilePanel.add(sizelabel);
		selectpixfilePanel.add(sizeTextField);

	}
	
	/**
	 * add JMenubar to the JFrame <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013 <br>
	 * Date last modified: May 02, 2013 <br>
	 *
	 * <hr>
	 */
	
	private void buildMenuBar(){
		
		menuBar = new JMenuBar();
		buildFileMenu();
		buildSearchMenu();
		buildHelpMenu();
		menuBar.add(fileMenu);
		menuBar.add(searchMenu);
		menuBar.add(helpMenu);

		setJMenuBar(menuBar);
	}
	
	/**
	 * add JMenuItems on the fileMenu to the JMenuBar <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013 <br>
	 * Date last modified: May 02, 2013 <br>
	 *
	 * <hr>
	 */
	
	private void buildFileMenu(){
		
		// Add all the JItems to the JMenuBar for all events
		
		newItem = new JMenuItem("New");
		newItem.setMnemonic(KeyEvent.VK_N);
		newItem.addActionListener(new newListener());
		newItem.setToolTipText("Click here to enter new pixfile.");
		
		openItem = new JMenuItem("Open");
		openItem.setMnemonic(KeyEvent.VK_O);
		openItem.addActionListener(new openListener());
		
		saveItem = new JMenuItem("Save");
		saveItem.setMnemonic(KeyEvent.VK_S);
		saveItem.addActionListener(new saveListener());
		
		exitItem = new JMenuItem("Exit");
		exitItem.setMnemonic(KeyEvent.VK_X);
		exitItem.addActionListener(new ExitListener());
		exitItem.setToolTipText("Click here to exit.");
		
		fileMenu = new JMenu("File");
		fileMenu.setMnemonic(KeyEvent.VK_F);
		
		fileMenu.add(newItem);
		fileMenu.add(openItem);
		fileMenu.add(saveItem);
		fileMenu.add(exitItem);

	}
	
	/**
	 * add JMenuItems on the searchMenu to the JFrame <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013 <br>
	 * Date last modified: May 02, 2013 <br>
	 *
	 * <hr>
	 */
	
	private void buildSearchMenu(){

		nameItem = new JMenuItem("Search by Pixfile Name");
		nameItem.setMnemonic(KeyEvent.VK_B);
		nameItem.addActionListener(new nameListener());
		
		photographerItem = new JMenuItem("Search by Photographer Name");
		photographerItem.setMnemonic(KeyEvent.VK_P);
		photographerItem.addActionListener(new photographerListener());
		
		showAllItem =  new JMenuItem("Show All Pixfiles");
		showAllItem.setMnemonic(KeyEvent.VK_A);
		showAllItem.addActionListener(new showAllListener());
		
		MINMAXItem = new JMenuItem("Show smallest and largest files");
		MINMAXItem.setMnemonic(KeyEvent.VK_M);
		MINMAXItem.addActionListener(new MINMAXAllListener());
		
		sortItem = new JMenuItem("Sort the list of Pixfiles");
		sortItem.setMnemonic(KeyEvent.VK_E);
		sortItem.addActionListener(new sortListener());
		
		deleteItem = new JMenuItem("Delete");
		deleteItem.setMnemonic(KeyEvent.VK_D);
		deleteItem.addActionListener(new deleteListener());
		
		searchMenu = new JMenu("Manage");
		searchMenu.setMnemonic(KeyEvent.VK_S);
		searchMenu.add(nameItem);
		searchMenu.add(photographerItem);
		searchMenu.add(showAllItem);
		searchMenu.add(MINMAXItem);
		searchMenu.add(sortItem);
		searchMenu.add(deleteItem);
	}
	
	/**
	 * add JMenuItems on the helpMenu to the JFrame <br>        
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 *
	 * <hr>
	 */
	
	private void buildHelpMenu(){
		
		helpItem = new JMenuItem("About");
		helpItem.setMnemonic(KeyEvent.VK_Q);
		helpItem.addActionListener(new helpListener());
		
		helpMenu = new JMenu("Help");
		helpMenu.setMnemonic(KeyEvent.VK_H);
		helpMenu.add(helpItem);
		
	}
	
	/**
	 * Class handles action events for the textfields and images<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class handler implements ListSelectionListener{
		
		public void valueChanged(ListSelectionEvent e) {
			int i = nameList.getSelectedIndex(); 
			ScalePhoto s = new ScalePhoto();
			 p = plist.get(i);
			 nameTextField.setText(p.getName());
			 photographerTextField.setText(p.getPhotographer());
			 typeTextField.setText(p.getType());
			 sizeTextField.setText(Double.toString(p.getFileSize()));
			 if(p.getType().equalsIgnoreCase("png")){
			 imageLabel.setIcon(s.getPhotoIcon(p.getName() + ".png" ,300));
			 } 
			 else if (p.getType().equalsIgnoreCase("jpeg")){
				 imageLabel.setIcon(s.getPhotoIcon(p.getName() + ".jpg" ,300));
			 }else if (p.getType().equalsIgnoreCase("gif")){
				 imageLabel.setIcon(s.getPhotoIcon(p.getName() + ".gif" ,300));
			 }else{
				 imageLabel.setIcon(s.getPhotoIcon(p.getName() + "." + p.getType(),300));
			 }
		}
	}
		
	/**
	 * Class handles to add new pixfile to Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class newListener implements ActionListener{
			
			public void actionPerformed(ActionEvent e) {
				  // Gather all information using JOptionPane
				   // Get the photograph name, photographer's name, file type,
				   // and file size
				   String name = JOptionPane.showInputDialog(null, "" + "Enter pixfile name: ", 
				                                      pixfilemsg, JOptionPane.QUESTION_MESSAGE);
				   String photog = JOptionPane.showInputDialog(null, "" + "Enter photographer's name: ", 
				                                      pixfilemsg, JOptionPane.QUESTION_MESSAGE);
				   String type = JOptionPane.showInputDialog(null, "Enter file type: ", 
				                                      pixfilemsg, JOptionPane.QUESTION_MESSAGE);
				   double size = Double.parseDouble(JOptionPane.showInputDialog(null, "Enter file size: ", 
				                                      pixfilemsg, JOptionPane.QUESTION_MESSAGE));
				
				   // Create a new pixfile object
				   p = new pixfile(name, photog, type, size);
				   // Add the new pixfile to the list
				   plist.addPix (p);
				   listChanged = true;
			}
	}
	
	/**
	 * Class handles to open the text file for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class openListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			plist = fmgr.getFile ( );
		}
	}
	
	/**
	 * Class handles to save the text file for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class saveListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			fmgr.saveFile(plist);
		}
	}
	
	/**
	 * Class handles to exit the Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class ExitListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			if ( listChanged) {
				fmgr.saveFile (plist);
			}
			JOptionPane.showMessageDialog(null , "--- Thanks for using the Patel Photo Tracker program v.2 ---",
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
				
			System.exit(0);
		}
	}
	
	/**
	 * Class handles to search a name field for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class nameListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			key = JOptionPane.showInputDialog(null, "Search for what pixfile?", 
					pixfilemsg, JOptionPane.QUESTION_MESSAGE);
			// Search the list
			p = plist.searchByName (key);
			// Was the key found?
			if ( p == null ) {
				// No - show an error message
				JOptionPane.showMessageDialog(null, "Pixfile " + key + " not found.",
					pixfilemsg, JOptionPane.ERROR_MESSAGE);
			} else {
				// Yes - show the pixfile data
				JOptionPane.showMessageDialog (null, "Found: " + p.toString ( ), 
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
			}
		}
	}
	
	/**
	 * Class handles to search a photographer name field for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class photographerListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			// Get the search key
			key = JOptionPane.showInputDialog(null, "Search for what photographer?", 
				pixfilemsg, JOptionPane.QUESTION_MESSAGE);
			// Search the list
			p = plist.searchByPhotographer(key);
			// Was the key found?
			if ( p == null ) {
				// No - display an error message
				JOptionPane.showMessageDialog(null, key + " not found.",
					pixfilemsg, JOptionPane.ERROR_MESSAGE);
			} else {
				// Yes - show the pixfile data
				JOptionPane.showMessageDialog (null, "Found: " + p.toString ( ), 
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
			}
		}
	}
	
	/**
	 * Class handles to show All pixfiles for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class showAllListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			// Display one stringified list
			String msg = String.format("%-20s %-20s %-10s %10s %10s %10s\n", 
					"Name", "Photographer", "Type","Size", "Cost", "Download");
			JOptionPane.showMessageDialog (null, msg 
					+ plist.toString ( ),
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
		}
	}
	
	/**
	 * Class handles to show min and max pixfiles for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class MINMAXAllListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			// Get the largest and smallest.
			JOptionPane.showMessageDialog (null, "Largest Pixfile:\n" + 
					plist.findMax ( ).toString ( ) +
				    "***************\n" +
					"\n\nSmallest Pixfile:\n" + plist.findMin ( ).toString ( ),
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
		}
	}	
	
	/**
	 * Class handles to sort the list for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class sortListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			// Just sort the list, do nothing else
			plist.sort ( );
			JOptionPane.showMessageDialog(null, "List was successfully sorted",
				pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
			
			listChanged = true;
		}
	}
	
	/**
	 * Class handles help message to show about for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class helpListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			JOptionPane.showMessageDialog(null, "You can use this program to see, add, delete or\n search any photoraghs",
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
		}
	}
	
	/**
	 * Class handles to delete one pixfile from the list for Photo tracker<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private class deleteListener implements ActionListener{
		
		public void actionPerformed(ActionEvent e) {
			// Remove one pixfile
			// Get the search key
			key = JOptionPane.showInputDialog(null, "Delete which Pixfile?", 
				pixfilemsg, JOptionPane.QUESTION_MESSAGE);
			// Search the list
			boolean removed = plist.remove(key);
			if (removed)
			{
				JOptionPane.showMessageDialog(null, key + " successfully removed",
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
			} else {
				JOptionPane.showMessageDialog(null, key + " not found",
					pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
			}
			
			listChanged = true;
		}
	}
	
	/**
	 * Set  the Image Icon to the JFrame<br>
	 *
	 * <hr>
	 * Date created: May 02, 2013<br>
	 * Date last modified: May 02, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
	
	private void setImageIcon( ) {
		try{
			imgIcon = ImageIO.read(getClass().getResource("images.png"));
			setIconImage(imgIcon);
		}catch(Exception e){
			
		}
	}
	
}
