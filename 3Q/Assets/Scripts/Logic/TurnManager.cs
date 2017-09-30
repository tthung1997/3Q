using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

// this class will take care of switching turns and counting down time until the turn expires
public class TurnManager : MonoBehaviour {

    // PUBLIC FIELDS
    //public CardAsset CoinCard;

    // for Singleton Pattern
    public static TurnManager Instance;

    // PRIVATE FIELDS
    // reference to a timer to measure 
    // TODO private RopeTimer timer;


    // PROPERTIES
    private Player _whoseTurn;
    public Player whoseTurn
    {
        get
        {
            return _whoseTurn;
        }

        set
        {
			//Debug.Log ("Start new turn");
            _whoseTurn = value;
            // TODO timer.StartTimer();

            GlobalSettings.Instance.EnableEndTurnButtonOnStart(_whoseTurn);

            TurnMaker tm = whoseTurn.GetComponent<TurnMaker>();
            // player`s method OnTurnStart() will be called in tm.OnTurnStart();
            tm.OnTurnStart();
            if (_whoseTurn.PArea.HPortrait.HeroPortraitObject.transform.rotation == Quaternion.Euler(Vector3.zero))
            {
                _whoseTurn.DrawACard();
                _whoseTurn.DrawACard();
                if (tm is PlayerTurnMaker)
                {
                    whoseTurn.HighlightPlayableCards();
                }
                // remove highlights for opponent.
                whoseTurn.otherPlayer.HighlightPlayableCards(true);
                //Debug.Log ("Finish starting new turn");
            }
            else
            {
                Sequence s = DOTween.Sequence();
                s.Insert(0f, _whoseTurn.PArea.HPortrait.HeroPortraitObject.transform.DORotate(Vector3.zero, GlobalSettings.Instance.CardTransitionTime));
                EndTurn();
            }
        }
    }


    // METHODS
    void Awake()
    {
        Instance = this;
        // TODO timer = GetComponent<RopeTimer>();
    }

    void Start()
    {
        OnGameStart();
    }

    public void OnGameStart()
    {
        //Debug.Log("In TurnManager.OnGameStart()");

        CardLogic.CardsCreatedThisGame.Clear();
        //CreatureLogic.CreaturesCreatedThisGame.Clear();

        foreach (Player p in Player.Players)
        {
            //p.ManaThisTurn = 0;
            //p.ManaLeft = 0;
            p.LoadCharacterInfoFromAsset();
            p.TransmitInfoAboutPlayerToVisual();
            p.PArea.PDeck.CardsInDeck = p.deck.cards.Count;
            // move both portraits to the center
            //p.PArea.Portrait.transform.position = p.PArea.InitialPortraitPosition.position;
        }
		/*
        Sequence s = DOTween.Sequence();
        s.Append(Player.Players[0].PArea.Portrait.transform.DOMove(Player.Players[0].PArea.PortraitPosition.position, 1f).SetEase(Ease.InQuad));
        s.Insert(0f, Player.Players[1].PArea.Portrait.transform.DOMove(Player.Players[1].PArea.PortraitPosition.position, 1f).SetEase(Ease.InQuad));
        s.PrependInterval(3f);
        s.OnComplete(() =>
            {*/
                // determine who starts the game.
                int rnd = Random.Range(0,2);  // 2 is exclusive boundary
                // Debug.Log(Player.Players.Length);
                Player whoGoesFirst = Player.Players[rnd];
                // Debug.Log(whoGoesFirst);
                Player whoGoesSecond = whoGoesFirst.otherPlayer;
                // Debug.Log(whoGoesSecond);
         
                // draw 4 cards for first player and 5 for second player
                int initDraw = 3;
                for (int i = 0; i < initDraw; i++)
                {            
                    // second player draws a card
                    whoGoesSecond.DrawACard(true);
                    // first player draws a card
                    whoGoesFirst.DrawACard(true);
                }
                // add one more card to second player`s hand
                whoGoesSecond.DrawACard(true);
                whoGoesFirst.Role = 1;
                whoGoesSecond.Role = 0;
                //new GivePlayerACoinCommand(null, whoGoesSecond).AddToQueue();
                //TODO whoGoesSecond.GetACardNotFromDeck(CoinCard);
                new StartATurnCommand(whoGoesFirst).AddToQueue();
            //});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            EndTurn();
    }

    // FOR TEST PURPOSES ONLY
    public void EndTurnTest()
    {
        // TODO timer.StopTimer();
        // TODO timer.StartTimer();
    }

    public void EndTurn()
    {
		//Debug.Log ("In EndTurn");
        // stop timer
        // TODO timer.StopTimer();
        // send all commands in the end of current player`s turn
        whoseTurn.OnTurnEnd();

        new StartATurnCommand(whoseTurn.otherPlayer).AddToQueue();
		//Debug.Log ("Finish EndTurn");
    }

    public void StopTheTimer()
    {
        // TODO timer.StopTimer();
    }

}

