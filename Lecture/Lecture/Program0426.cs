using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program0426
    {

        public static int[] suits = { 1, 2, 3, 4 };//花色 1=梅花,2=方塊,3=愛心,4=黑桃
        public static string[] card_suits_name = { "梅花", "方塊", "愛心", "黑桃" };
        public static int[] cardnum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };//數字等於牌號
        public static string[] card_cardnum_name = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static int[] card_sent = new int[52];
        //儲存牌型的數字
        public static int[] twopairs = new int[2] { -1, -1 };
        public static int threepairs = -1;
        public static int fourpairs = -1;
        public static int straight = -1;
        //牌型，cardType對應cardTypeName
        public static int[] cardType = { 1, 2, 3, 4, 5, 6, 7, 8 };
        public static string[] cardTypeName = { "同花順", "鐵支", "葫蘆", "三條", "順子", "兩對", "一對", "王八" };


        static void Main(string[] args)
        {
            initCards();

            int[,] myHand = new int[5, 2];  //my card
            //draw 5 cards for each player
            for (int i = 0; i < 5; i++)
            {
                int[] tempHand = GiveCard();
                myHand[i, 0] = tempHand[0];
                myHand[i, 1] = tempHand[1];

                Console.WriteLine("My " + (i + 1) + " Card : " + PrintHandCard(myHand, i));
            }
            //myHand = new int[5, 2] { { 3, 9 }, { 4, 10 }, { 4, 11 }, { 4, 12 }, { 4, 13 } };

            Console.WriteLine();
            int[] myHandSize = CheckPairs(myHand);
            Console.WriteLine();

            int[,] opponentHand = new int[5, 2];    //opponent's card
            for (int j = 0; j < 5; j++)
            {
                int[] tempHand = GiveCard();
                opponentHand[j, 0] = tempHand[0];
                opponentHand[j, 1] = tempHand[1];

                Console.WriteLine("Opponent " + (j + 1) + " Card : " + PrintHandCard(opponentHand, j));
            }

            Console.WriteLine();
            int[] opponentHandSize = CheckPairs(opponentHand);
            Console.WriteLine();

            CompareCard(myHandSize, opponentHandSize, myHand, opponentHand);

            //CompareCards(mycard, ACard);

            //myHand = new int[5, 2] { { 1, 1}, { 1, 2}, { 1, 3}, { 1, 4}, { 1, 5} };

            Console.WriteLine("==========");
            PrintSentCard();

            Console.ReadLine();

        }

        //比較兩副手牌誰大誰小
        public static void CompareCard(int[] myHandSize, int[] opponentHandSize, int[,] myHand, int[,] opponentHand)
        {
            if (myHandSize[0] < opponentHandSize[0])
            {
                Console.WriteLine("My card is bigger than opponent card.");
            }
            else if (myHandSize[0] == opponentHandSize[0])
            {
                if (myHandSize[1] > opponentHandSize[1])
                {
                    Console.WriteLine("My card is bigger than opponent card.");
                }
                else if (myHandSize[1] == opponentHandSize[1])
                {
                    if (myHandSize[0] == 8)
                    {
                        int myColor = 0;
                        int opponentColor = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            if (myHandSize[1] == myHand[i, 1])
                            {
                                myColor = myHand[i, 0];
                            }
                            if (opponentHandSize[1] == opponentHand[i, 1])
                            {
                                opponentColor = opponentHand[i, 0];
                            }
                        }

                        if (myColor > opponentColor)
                        {
                            Console.WriteLine("My card is bigger than opponent card.");
                        }
                        else
                        {
                            Console.WriteLine("Opponent card is bigger than my card.");
                        }
                    }
                    else if (myHandSize[0] == 7)
                    {
                        int[] tempmyHandSize = new int[2];
                        tempmyHandSize[0] = myHandSize[1];
                        tempmyHandSize[1] = myHandSize[2];
                        Array.Sort(tempmyHandSize);

                        int[] tempopponentHandSize = new int[2];
                        tempopponentHandSize[0] = tempopponentHandSize[1];
                        tempopponentHandSize[1] = tempopponentHandSize[2];
                        Array.Sort(tempopponentHandSize);

                        if (tempmyHandSize[1] > tempopponentHandSize[1])
                        {
                            Console.WriteLine("My card is bigger than opponent card.");
                        }
                        else if (tempmyHandSize[1] == tempopponentHandSize[1])
                        {
                            int[] myColor = new int[2] { 0, 0 };
                            int[] opponentColor = new int[2] { 0, 0 };

                            for (int i = 0; i < 5; i++)
                            {
                                if (tempmyHandSize[1] == myHand[i, 1])
                                {
                                    if (myColor[0] == 0)
                                    {
                                        myColor[0] = myHand[i, 1];
                                    }
                                    else
                                    {
                                        myColor[1] = myHand[i, 1];
                                    }
                                }

                                if (tempopponentHandSize[1] == opponentHand[i, 1])
                                {
                                    if (opponentColor[0] == 0)
                                    {
                                        opponentColor[0] = opponentHand[i, 1];
                                    }
                                    else
                                    {
                                        opponentColor[1] = opponentHand[i, 1];
                                    }
                                }
                            }

                            Array.Sort(myColor);
                            Array.Sort(opponentColor);

                            if (myColor[1] > opponentColor[1])
                            {
                                Console.WriteLine("My card is bigger than opponent card.");
                            }
                            else
                            {
                                Console.WriteLine("Opponent card is bigger than my card.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opponent card is bigger than my card.");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Opponent card is bigger than my card.");
                }
            }
            else
            {
                Console.WriteLine("Opponent card is bigger than my card.");
            }
        }

        //將手牌由小到大做排序
        public static int[] SortHandNumber(int[,] myHand)
        {
            int[] tempHand = new int[5];
            for (int i = 0; i < 5; i++)
            {
                tempHand[i] = myHand[i, 1];
            }

            for (int j = 0; j < 4; j++)
            {
                for (int k = j + 1; k > 0; k--)
                {
                    if (tempHand[k - 1] > tempHand[k])
                    {
                        int tempNum = tempHand[k];
                        tempHand[k] = tempHand[k - 1];
                        tempHand[k - 1] = tempNum;
                    }
                }
            }

            return tempHand;
        }

        //判斷是否為順子
        public static int CheckStraight(int[,] myHand)
        {
            int result = 0;
            //Array.Sort(tempHand);
            int[] myHandNumber = SortHandNumber(myHand);

            if (myHandNumber[4] - myHandNumber[3] == 1 && myHandNumber[3] - myHandNumber[2] == 1 && myHandNumber[2] - myHandNumber[1] == 1 && myHandNumber[1] - myHandNumber[0] == 1)
            {
                Console.WriteLine("手牌為順子。");
                result = 1;
            }
            else
            {
                Console.WriteLine("手牌不為順子。");
                result = 0;
            }
            return result;
        }

        public static int myHander;
        public static int opponentHander;

        //印出牌型，回傳result
        public static int[] CheckPairs(int[,] myHand)
        {
            twopairs = new int[] { -1, -1 };
            threepairs = -1;
            fourpairs = -1;
            straight = -1;

            //pairCheck為牌型判斷依據
            int[] pairCheck = CheckHowManyPairs(myHand);
            int[] result = new int[3];
            //result[0] = 牌型, result[1] = 數字, result[2] = 如是兩對則是第二個對子，否則為0。
           
            if (pairCheck[1] == 1)
            {
                if (pairCheck[0] == 1)
                {
                    Console.WriteLine("牌型為 " + pairCheck[0] + " 個葫蘆。");
                    Console.WriteLine(card_cardnum_name[threepairs] + "葫蘆配" + card_cardnum_name[twopairs[0]] + "一對。");
                    result[0] = 3;
                    result[1] = threepairs;
                    result[2] = 0;
                    return result;
                }
                else
                {
                    Console.WriteLine("牌型為 " + pairCheck[1] + " 個三條。");
                    Console.WriteLine("三條" + card_cardnum_name[threepairs] + "。");
                    result[0] = 4;
                    result[1] = threepairs;
                    result[2] = 0;
                    return result;
                }
                
            }
            else if (pairCheck[0] != 0)
            {
                Console.WriteLine("牌型為 " + pairCheck[0] + " 個對子。");
                if (pairCheck[0] == 1)
                {
                    Console.WriteLine(card_cardnum_name[twopairs[0]] + "一對。");
                    result[0] = 7;
                    result[1] = twopairs[0];
                    result[2] = 0;
                    return result;
                }
                else
                {
                    Console.WriteLine(card_cardnum_name[twopairs[0]] + "和" + card_cardnum_name[twopairs[1]] + "兩對。");
                    result[0] = 6;
                    result[1] = twopairs[0];
                    result[2] = twopairs[1];
                    return result;
                }

            }
            else if (pairCheck[2] == 1)
            {
                Console.WriteLine("牌型為 " + pairCheck[2] + " 個四條。");
                Console.WriteLine(card_cardnum_name[fourpairs] + "鐵支。");
                result[0] = 2;
                result[1] = fourpairs;
                result[2] = 0;
                return result;
            }
            else if (pairCheck[3] == 1)
            {
                Console.WriteLine("牌型為 " + pairCheck[3] + " 個順子。");
                int straightColor = CheckStraightColor(myHand);
                int[] myHandNumber = SortHandNumber(myHand);

                string numString = "";
                if (straightColor != 0)
                {
                    Console.WriteLine("而且還是" + card_suits_name[straightColor - 1] + "同花順!");
                    foreach (int num in myHandNumber)
                    {
                        numString += card_cardnum_name[num - 1] + " ";
                    }
                    Console.WriteLine(numString.Trim() + "順子。");

                    result[0] = 1;
                    result[1] = myHandNumber[4];
                    result[2] = 0;
                    return result;
                }

                foreach (int num in myHandNumber)
                {
                    numString += card_cardnum_name[num - 1] + " ";
                }
                Console.WriteLine(numString.Trim() + "順子。");

                result[0] = 5;
                result[1] = myHandNumber[4];
                result[2] = 0;
                return result;
            }
            else
            {
                Console.WriteLine("什麼牌型也沒有。");
                int[] myHandNumber = SortHandNumber(myHand);
                Console.WriteLine("最大的為" + card_cardnum_name[myHandNumber[4]]);
                result[0] = 8;
                result[1] = myHandNumber[4];
                result[2] = 0;
                return result;
            }
        }

        public static int CheckStraightColor(int[,] myHand)
        {
            int[] myHandNumber = SortHandNumber(myHand);
            if (myHand[0, 0] == myHand[1, 0] && myHand[0, 0] == myHand[2, 0] && myHand[0, 0] == myHand[3, 0] && myHand[0, 0] == myHand[4, 0])
            {
                return myHand[0, 0];
            }
            return 0;
        }

        //判斷牌型
        public static int[] CheckHowManyPairs(int[,] myHand)
        {
            int[] myHandNumber = SortHandNumber(myHand);

            //牌型 { 對子, 三條, 四條, 順子 } 
            int[] pairCheck = new int[4] { 0, 0, 0, 0 };

            int straightResult = CheckStraight(myHand);
            if (straightResult == 1)
            {
                pairCheck[3] = 1;
                return pairCheck;
            }

            int count = 0;
            
            //以撲克牌數字2~A為順序來比對手牌，若有發現手牌也有該數字則count+1，最後更新至pairCheck
            //count = 2為對子、3為三條、4為鐵支
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (myHandNumber[j] == i)
                    {
                        count++;
                    }

                }
                if (count == 2)
                {
                    pairCheck[0]++;
                    //因為有一個對子或兩個對子，所以twopairs宣告為陣列，twopairs[0]為第一個對子的數字，twopairs[1]為第二個對子。
                    if (twopairs[0] == -1)
                    {
                        twopairs[0] = i;
                    }
                    else
                    {
                        twopairs[1] = i;
                    }
                }
                else if (count == 3)
                {
                    pairCheck[1]++;
                    threepairs = i;
                }
                else if (count == 4)
                {
                    pairCheck[2]++;
                    fourpairs = i;
                }
                count = 0;
            }
            return pairCheck;
        }

        public static Random random = new Random();
        //清除發過的牌 將其記錄為0
        public static void initCards()
        {
            for (int i = 0; i < card_sent.Length; i++)
            {
                card_sent[i] = 0;
            }
        }
        //PRINT 全部發過的牌
        public static void PrintSentCard()
        {
            int[] tempcard = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (card_sent[(i * 13) + j] == 1)
                    {
                        tempcard[0] = i;
                        tempcard[1] = j;
                        Console.WriteLine("SHOW SENT:" + PrintACard(tempcard));
                    }
                    
                }
            }
        }


        public static int[] GiveCard()//定義int陣列;給一張隨機花色的數字
        {
            int[] newcard = new int[2];

            newcard[0] = random.Next(0, 4);
            newcard[1] = random.Next(0, 13);

            if (card_sent[((newcard[0]) * 13) + newcard[1]] == 0)
            {
                card_sent[((newcard[0]) * 13) + newcard[1]] = 1;
            }
            else
            {
                return GiveCard();
            }

            //newcard[0]++;
            //newcard[1]++;

            return newcard;
        }
        //顯示這張卡片的數字與花色
        public static string PrintACard(int[] ACard)
        {
            return card_suits_name[ACard[0]] + " " + card_cardnum_name[ACard[1]];
        }

        //印出牌的數字和花色
        public static string PrintHandCard(int[,] ACard, int choose)
        {
            return card_suits_name[ACard[choose, 0]] + " " + card_cardnum_name[ACard[choose, 1]];
        }

        //比對兩張牌誰大誰小
        public static void CompareCards(int[] myCard, int[] ACard)
        {
            string myCardString = card_suits_name[myCard[0] - 1] + " " + card_cardnum_name[myCard[1] - 1];
            string ACardString = card_suits_name[ACard[0] - 1] + " " + card_cardnum_name[ACard[1] - 1];

            if (myCard[1] > ACard[1])
            {
                Console.WriteLine(myCardString + " > " + ACardString);
                Console.WriteLine("Ya I Win!!!");
            }
            else if (myCard[1] == ACard[1])
            {
                if (myCard[0] > ACard[0])
                {
                    Console.WriteLine(myCardString + " > " + ACardString);
                    Console.WriteLine("Ya I Win!!!");
                }
                else
                {
                    Console.WriteLine(ACardString + " > " + myCardString);
                    Console.WriteLine("No I Lose!!!");
                }
            }
            else
            {
                Console.WriteLine(ACardString + " > " + myCardString);
                Console.WriteLine("No I Lose!!!");
            }

        }

    }
}
