using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CardFactory : MonoBehaviour
{
	public GameObject PrefabPlayerInstantCardBase;
	public Sprite[] cardPics;

	public TextAsset jsonFile;

	public List<GameObject> CardDictionary;

	private int cardnum = 0;



    // Start is called before the first frame update
    void Start()
	{
		Debug.Log(jsonFile.text);
		InstantCardsCollection myCards = JsonUtility.FromJson<InstantCardsCollection>(jsonFile.text);

		Debug.Log(myCards);

		foreach (PlayerInstantCardStats card in myCards.Cards)
		{
			CreateCardFromStats(card);
		}
	}

	private GameObject CreateCardFromStats(PlayerInstantCardStats stats)
    {
		GameObject myCard = Instantiate(PrefabPlayerInstantCardBase);
		myCard.name = "CardFactoryCard-"+ cardnum++;

		//GameObject mainCanvas = GameObject.Find("Main Canvas");
		//myCard.transform.SetParent(mainCanvas.transform);
		myCard.GetComponent<RectTransform>().sizeDelta = HelperNumbers.NORMAL_CARD_SCALE;

		UnityEngine.Transform textWrapper = myCard.transform.Find("TextWrapper");
		GameObject tmpLabel;

		tmpLabel = textWrapper.Find("Text-CardName").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.CardName;

		tmpLabel = textWrapper.Find("Text-TimeCost").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.TimeCost;

		tmpLabel = textWrapper.Find("Text-AlertCost").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.AlertCost;

		tmpLabel = textWrapper.Find("Text-CardClass").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.CardClass;

		tmpLabel = textWrapper.Find("Text-CardType").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.CardType;

		tmpLabel = textWrapper.Find("Text-CardSubtype").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.CardSubtype;

		tmpLabel = textWrapper.Find("Text-TargetingType").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.TargetingType;

		tmpLabel = textWrapper.Find("Text-ProgressGenerated").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.ProgressGenerated;

		tmpLabel = textWrapper.Find("Text-DamageGenerated").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.DamageGenerated;

		tmpLabel = textWrapper.Find("Text-CardDescription").gameObject;
		tmpLabel.GetComponent<TextMeshPro>().text = stats.CardDescription;

		tmpLabel = myCard.transform.Find("CardArtWrapper").Find("CardArt").gameObject;
		tmpLabel.GetComponent<SpriteRenderer>().sprite = cardPics[stats.SpriteIndex];
		tmpLabel.GetComponent<SpriteRenderer>().color = Color.white;

		myCard.SetActive(false);
		CardDictionary.Add(myCard);

		return myCard;
	}

	// Update is called once per frame
	void Update()
	{

	}

	[Serializable]
	private class InstantCardsCollection
	{
		public PlayerInstantCardStats[] Cards;
	}

	[Serializable]
	private class PlayerInstantCardStats
	{
		public string CardName;
		public string TimeCost;
		public string AlertCost;
		public string CardClass;
		public string CardType;
		public string CardSubtype;
		public string TargetingType;
		public string ProgressGenerated;
		public string DamageGenerated;
		public string CardDescription;
		public int SpriteIndex;
	}
}
