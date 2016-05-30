using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Count time. If time runs out, game over
public class CountdownTimer_CSHARP : MonoBehaviour 
{
	public static float Seconds = 0;
	public static float Minutes = 3;
	public Text cT;

	void Start(){
	}

	void Update()
	{
		if(Seconds <= 0)
		{
			Seconds = 59;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				cT.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}
		
		if(Mathf.Round(Seconds) <= 9)
		{
			cT.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}
		else
		{
			cT.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}
	}
}