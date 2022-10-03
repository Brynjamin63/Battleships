Module Module1
    Dim Sea(9, 9) As Char
    Dim TryX, TryY, hits As Integer
    Dim Torpedoes As Integer
    Dim Gamewon, ValidGuess, Overlap As Boolean
    Dim PlayAgain As Char
    Dim name As String

    Sub main()
        Do
            Console.Clear()
            SetupGame() ' Call the procedure to set up the game
            'Console.WriteLine("Please enter your name: ")
            'name = Console.ReadLine
            Console.WriteLine("Welcome to battleships " & name & "!")
            Console.WriteLine("An enemy ship is hidden somewhere at sea.")
            Console.WriteLine("You only have ten torpedoes to find it")
            Do
                Console.WriteLine()
                DrawGrid() 'Call the procedure to draw the current state of the game
                Console.WriteLine()
                Console.WriteLine("You have " & Torpedoes & " torpedoes left.")
                Console.WriteLine("Enter the row and column to aim your torpedoes")
                Console.Write("Row? ")
                TryX = Console.ReadLine
                Console.Write("Column? ")
                TryY = Console.ReadLine

                ValidGuess = False

                While ValidGuess = False
                    If Sea(TryX, TryY) = "M" Or Sea(TryX, TryY) = "X" Then
                        Console.WriteLine("You have already shot here! Please enter again")
                        Console.WriteLine("Row? ")
                        TryX = Console.ReadLine
                        Console.WriteLine("Column? ")
                        TryY = Console.ReadLine
                    Else
                        ValidGuess = True
                    End If
                End While

                If Sea(TryX, TryY) = "." Then Sea(TryX, TryY) = "M"
                If Sea(TryX, TryY) = "S" Then
                    Sea(TryX, TryY) = "X"
                    hits = hits + 1
                End If
                If Sea(TryX, TryY) = "S" Then
                    Sea(TryX, TryY) = "X"
                    hits = hits + 1
                End If

                Torpedoes = Torpedoes - 1
                If hits = 8 Then
                    Gamewon = True
                End If
            Loop Until Torpedoes = 0 Or GameWon = True
            If Gamewon = True Then
                Console.WriteLine()
                DrawGrid()
                Console.WriteLine()
                Console.WriteLine("Congratulations! You sank the enemy ship!")
            Else
                Console.WriteLine()
                DrawGrid()
                Console.WriteLine()
                Console.WriteLine("Unfortunatly you have run out of time and you have lost the battle :-(")
            End If
            Console.WriteLine()
            Console.WriteLine("Do you want to play again (y/n)")
            PlayAgain = Console.ReadLine
        Loop Until PlayAgain = "n"
    End Sub

    Sub DrawGrid()
        Dim x, y As Integer
        Console.WriteLine("  123456789")
        For x = 1 To 9
            Console.Write(x & " ")
            For y = 1 To 9
                If Sea(x, y) = "S" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("S")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "S" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("S")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "M" Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Write("m")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "X" Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("x")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "." Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write(".")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
            Next
            Console.WriteLine()
        Next
    End Sub

    Sub SetupGame()
        Dim z, m As Integer
        Dim Ship1Y, Ship1X, Ship2Y, Ship2X As Integer
        Torpedoes = 25
        Gamewon = False
        ValidGuess = False
        Overlap = False
        'Fill sea with dots
        For x = 1 To 9
            For y = 1 To 9
                Sea(x, y) = "."
            Next
        Next
        'Hide ship at random position
        Randomize() ' Initialize the random number generator


        Ship1X = CInt(Rnd() * 5 + 1)
        Ship1Y = CInt(Rnd() * 8 + 1)

        For z = Ship1X To (Ship1X + 2)
            Sea(Ship1X, z) = "S"
        Next

        Do
            Ship2X = CInt(Rnd() * 8 + 1)
            Ship2Y = CInt(Rnd() * 4 + 1)

            For m = Ship2Y To (Ship2Y + 4)
                If Sea(Ship2X, m) = "S" Then
                    Overlap = True
                End If
            Next
        Loop Until Overlap = False

        For m = Ship2Y To (Ship2Y + 4)
            Sea(m, Ship2Y) = "S"
        Next
        Ship(7, "h")

    End Sub

    Sub Ship(Length As Integer, Orientation As Char)





    End Sub





End Module


