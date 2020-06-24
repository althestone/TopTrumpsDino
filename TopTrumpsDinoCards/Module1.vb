Imports System.CodeDom
Imports  System.IO
Module Module1
    Structure Dino
        dim DinoName as String
        Dim Eating as String
        dim Height as Double
        dim Weight as Double
        dim Length as Double
        dim KillRate as Integer
        dim Intel as Integer
        dim Age as Integer
    End Structure
    Sub Main()
        dim n as new Random
        dim categories (7) as string
       dim deck = generateCards(n,categories)
        dim shuffledDeck = Shuffle(deck,n)
        dim p1Hand(29) as Dino
        dim p2Hand(29) as Dino
        GenHands(p1Hand,p2Hand,deck)
        playGame(p1Hand,p2Hand,n,categories)
    
    End Sub
    sub playGame(hand1() as Dino, hand2() as Dino, n as Random, categories() as String)
        dim p1Pointer = 0
        dim p2Pointer = 0
        dim p1Cards = 15
        dim p2Cards = 15
        dim player = n.Next(1,3)
        dim playCard as Dino
        dim nonPlayCard as Dino
        while p1Cards <> 0 or p2Cards <>0
            if player = 1
                playcard = hand1(p1Pointer)
                nonPlayCard = hand2(p2Pointer)
                Else 
                    playcard = hand2(p2Pointer)
                    nonPlayCard = hand1(p1Pointer)
            End If
            showCard(playcard,categories)
            Console.WriteLine("Player " & Player & " pick your category")
            showCats(categories)
            Console.Write("Enter your chosen category: ")
            dim pResponse as Integer
            pResponse = Console.ReadLine()
            dim val as Double
            dim Oval as Double
            Select Case pResponse
               case 1,2
                        Console.WriteLine("Not a playable value")
                   case 3
                        val = playCard.Height
                        Oval = nonplayCard.Height

                    case 4
                        val = playCard.Weight
                        Oval = nonplayCard.Weight
                    case 5
                        val = playCard.Length
                        Oval = nonplayCard.Length
                    case 6
                        val = playCard.KillRate
                        Oval = nonplayCard.Length
                    case 7 
                        val = playCard.Intel
                        Oval = nonplayCard.Intel
                    case 8
                        val = playcard.Age
                        Oval = nonplayCard.Age
             End Select
           
            Console.WriteLine("{0} for {1} has a value of {2}",categories(pResponse-1),playcard.DinoName,val)
            Console.WriteLine("{0} for opponent's card which is a {1} has a value of {2}",categories(pResponse-1),nonplaycard.DinoName,oval)

            Console.ReadLine()
        End While
    End sub
    sub showCats(categories())
        for i = 1 to categories.length
            Console.WriteLine(i & ": " & categories(i-1))    
        Next
    End sub
    sub showCard(dino as Dino, categories() as string)
        Console.WriteLine(categories(0) & ": " & dino.DinoName)
        Console.WriteLine(categories(1) & ": " & dino.Eating)
        Console.WriteLine(categories(2) & ": " & dino.Height)
        Console.WriteLine(categories(3) & ": " & dino.Weight)
        Console.WriteLine(categories(4) & ": " & dino.Length)
        Console.WriteLine(categories(5) & ": " & dino.KillRate)
        Console.WriteLine(categories(6) & ": " & dino.Intel)
        Console.WriteLine(categories(7) & ": " & dino.Age)

    End sub
    function generateCards(n as Random, byref categories() as string) as Dino()
        
        dim fileToRead as new StreamReader("C:\vbtextfiles\dinosaurs.txt")
         categories = fileToRead.Readline.Split(",")
        
        dim cards(29) as Dino
        dim pointer = 0
        Do
            dim currentCardData = fileToRead.ReadLine().Split(",")
            cards(pointer).DinoName = currentCardData(0)
            cards(pointer).Eating = currentCardData(1)
            cards(pointer).Height =currentCardData(2)
            cards(pointer).Weight = currentCardData(3)
            cards(pointer).length = currentCardData(4)
            cards(pointer).KillRate = currentCardData(5)
            cards(pointer).intel = currentCardData(6)
            cards(pointer).age = currentCardData(7)
            pointer +=1
        Loop until fileToRead.EndOfStream
        Return cards
    End function
    sub GenHands(hand1() as Dino, hand2() as Dino, deck() as dino)
        dim pointer = 0
        for i = 0 to deck.Length-2 step 2
            hand1(pointer) = deck(i)
            hand2(pointer) = deck(i+1)
            pointer +=1
        Next
        
    End sub
    Function Shuffle(deck() as Dino, n as Random) As Dino()
       dim sdeck = deck
        dim temp as Dino
        for i = 1 to 1000
            dim a = n.Next(0,deck.Length)
            dim b = n.Next(0,deck.Length)
            temp = sdeck(a)
            sdeck(a) = sdeck(b)
            sdeck(b) = temp
            
        Next
        Return sdeck
    End Function
End Module
