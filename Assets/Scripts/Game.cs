using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Cards> deck = new List<Cards>();
    public List<Cards> opponent1Cards = new List<Cards>();
    public List<Cards> opponent2Cards = new List<Cards>();
    public List<Cards> opponent3Cards = new List<Cards>();
    public List<Cards> playerCards = new List<Cards>();
    public Sprite[] cards;
    public GameObject playerCard1;


    CardType type;
    

    public void FindCardType(int i)
    {
        
        if (i < 13)
        {
            type = CardType.Club;
        }
        else if (i > 12 && i < 26)
        {
            type = CardType.Diamond;
        }
        else if (i > 25 && i < 38)
        {
            type = CardType.Heart;
        }
        else if (i > 38)
        {
            type = CardType.Spade;
        }
       
    }

    public void CreateDeck()
    {

        for(int i=0; i<52; i++)
        {
            FindCardType(i);

            Cards cardInstance = new Cards
            {
                card = cards[i],
                point = (i%13)+2,
                cardType = type,
        
            };


           deck.Add(cardInstance);

        }
        
    }

    public void DistributeCards() //YENI *************************
    {
        System.Random random = new System.Random();
        
        for(int i=0; i < 4; i++)
        {
            int startingIndex = Random.Range(0, deck.Count);

            int playerIndex = random.Next(startingIndex);
            playerCards.Add(deck[playerIndex]);
            deck.RemoveAt(playerIndex);

            int opponent1Index=random.Next(startingIndex);
            opponent1Cards.Add(deck[opponent1Index]);
            deck.RemoveAt(opponent1Index);

            int opponent2Index = random.Next(startingIndex);
            opponent1Cards.Add(deck[opponent2Index]);
            deck.RemoveAt(opponent2Index);

            int opponent3Index = random.Next(startingIndex);
            opponent1Cards.Add(deck[opponent3Index]);
            deck.RemoveAt(opponent3Index);
       
           
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        CreateDeck();
        DistributeCards();


        playerCard1.GetComponent<SpriteRenderer>().sprite = playerCards[0].card;
        Instantiate(playerCard1, playerCard1.transform.position, transform.rotation);
        Debug.Log(playerCards[0].card);

       



    }

    // Update is called once per frame
    void Update()
    {


    }
}
