import javax.swing.JOptionPane;

public class proj1
{
	public static void main(String[] args)
	{
		final int LIMIT = 3;
		photo[] pho = new photo[LIMIT];
		
		getPixfile(pho);
		
		for(int i = 0; i < pho.length; i++)
		{
		JOptionPane.showMessageDialog(pho[i]);
		}
	}

	private static void getPixfile(photo[] array)
	{
				photo ph = new photo();
				String photographer = JOptionPane.showInputDialog("Name of photographer: ");
				String typefile = JOptionPane.showInputDialog("Type of file: ","jpeg");
				String size = JOptionPane.showInputDialog("Size of the file in megabytes: ",0.0);
				double dsize = Double.parseDouble(size);
				ph.setfilename(filename);
				ph.setphotographer(photographer);
				ph.settypefile(typefile);
				ph.setsize(dsize);			
		array[i] = new photo(ph);	
	}
}