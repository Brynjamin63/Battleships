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

        Torpedoes = 25
        Gamewon = False
        ValidGuess = False
        'Fill sea with dots
        For x = 1 To 9
            For y = 1 To 9
                Sea(x, y) = "."
            Next
        Next
        'Hide ship at random position

        Ship(2, "h")
        Ship(4, "v")

    End Sub

    Sub Ship(Length As Integer, Orientation As Char)

        Randomize() ' Initialize the random number generator

        Dim ValidPlace1, ValidPlace2 As Boolean
        Dim ShipX, ShipY As Integer

        ValidPlace1 = False
        ValidPlace2 = False


        Do

            ShipX = CInt(Rnd() * 5 + 1)
            ShipY = CInt(Rnd() * 5 + 1)

            If Orientation = "h" Then
                For x = ShipY To (ShipY + (Length - 1))
                    If Sea(ShipX, x) = "." Then
                        ValidPlace1 = True
                    End If
                Next
            ElseIf Orientation = "v" Then
                For x = ShipX To (ShipX + (Length - 1))
                    If Sea(x, ShipY) = "." Then
                        ValidPlace2 = True
                    End If
                Next
            End If
        Loop Until ValidPlace1 = True And ValidPlace2 = True

        If Orientation = "h" Then
            For x = ShipY To (ShipY + (Length - 1))
                Sea(ShipX, x) = "S"
            Next
        ElseIf Orientation = "v" Then
            For x = ShipX To (ShipX + (Length - 1))
                Sea(x, ShipY) = "S"
            Next
        End If





    End Sub





End Module


