using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

//Rewarded Ads instantiation and play the ads
public class UIGameOver : MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
	public void ShowRewardedAd()
	{
		tileCollision.r = 0;
		globalVariable.countEggs = 0;
		globalVariable.life = 0;
		timer.f1 = 4;
		globalVariable.Eggs = false;
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}
	
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			int i = Random.Range(0,2);
			if(i == 0)
			{
				globalVariable.coin = 20;
			}else
			{
				globalVariable.coin = 50;
			}

			Application.LoadLevel ("gamePlay");
			break;
		case ShowResult.Skipped:
			globalVariable.coin = 0;
			Application.LoadLevel ("gamePlay");
			break;
		case ShowResult.Failed:
			break;
		}
	}
}
