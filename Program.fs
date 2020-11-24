// Learn more about F# at http://fsharp.org

open System

//-------------------------------------------------------------------
//                             ASSIGNMENT
//-------------------------------------------------------------------
//mutable
let mutable x = 4
x <-5

//imutable
let y = "oi"


//-------------------------------------------------------------------
//                              TYPES
//-------------------------------------------------------------------
//static and strong, can be implicit or explicit
let z = 1
let z2:int = 1


//-------------------------------------------------------------------
//                              LAMBDA
//-------------------------------------------------------------------
let multiplyByTwo(x) = x*2
let decreaseOne(x) = x-1

//this operations are the same thing
let op(x: int) =  multiplyByTwo(x)  +  decreaseOne(x)
let op2(x: int) =  (fun y -> y * 2) x +  (fun y -> y - 1) x


//-------------------------------------------------------------------
//                              PIPELINES
//-------------------------------------------------------------------
module BasicFunctions =
  let square x = x * x
  let negate x = x * -1
  let print x = printfn "The number is: %d" x
  let squareNegateThenPrint x = x |> square |> negate |> print
  squareNegateThenPrint 5


//-------------------------------------------------------------------
//                              RECURSION
//-------------------------------------------------------------------
let rec factorial x =
  match x with
  | x when x<1 -> 1
  | _          -> x * factorial (x - 1)


//-------------------------------------------------------------------
//                              TUPLES
//-------------------------------------------------------------------
module Tuples =
 let myTuple = (1, 2)
 let swapTuple (a, b) = (b, a)
 printfn "%A" (swapTuple (1,2)) //(2, 1)


//-------------------------------------------------------------------
//                              RECORDS
//-------------------------------------------------------------------
type Person = { Name : string; Age : int }
let augusto = { Name = "Augusto"; Age = 23 }
let otsugua = { augusto with Name = "Otsugua"; Age = 32  }

//allow pattern matching
let isInvertedAugusto person =
    match person with
     | { Name = "Otsugua" } -> true
     | _ -> false


//-------------------------------------------------------------------
//                              LISTS
//-------------------------------------------------------------------
let list1 = [ "a"; "b" ]
let list2 = "c" :: list1
let list3 = list1 @ list2  


//-------------------------------------------------------------------
//                              ARRAYS
//-------------------------------------------------------------------
let array1 = [| "a"; "b" |]
let first = array1.[0] 


//-------------------------------------------------------------------
//                CREATION AND HIGH ORDER IN COLLECTIONS
//-------------------------------------------------------------------

let arr = List.init 5 (fun i -> 2 * i + 1)
let arr1 = [ 1..2..9 ]
let arr2 = [ for i in 0..4 -> 2 * i + 1 ]

let result = List.fold (fun x y -> x + y) 0 [1; 2; 3] //result = 6
let result1 = List.reduce (fun x y -> x + y) [1; 2; 3] //result = 6
let result2 = Array.map (fun x -> x * x) [| 0..9 |]    //result = [|0; 1; 4; 9; 16; 25; 36; 49; 64; 81|]
let result3 = List.iter (printfn "%i") [ 0..9 ]


//-------------------------------------------------------------------
//                             CLASSES
//-------------------------------------------------------------------
type MyClass1(number)=
    do printfn "%d" number
    let number = number

    new() = MyClass1(0) //another constructor
    
    member self.AddOne(x:int) = //declaring a normal member
        x+1

    abstract member PrintMessage : unit -> unit //declaring a member that can be overriden
    default self.PrintMessage() =
        printf "MyClass1: %d" number

type MyClass2(number)=
    inherit MyClass1(number)
    let number = number
    override self.PrintMessage() = // override method
        printf "MyClass2: %d" number


//-------------------------------------------------------------------
//                           EXCEPTIONS
//-------------------------------------------------------------------
exception NotOdd of int
exception HigherThan10 of int
    
let oddAndLessThan10(x:int) =
    try
        try
            if x >= 10 then
                raise (HigherThan10(x))
            if x % 2 = 0 then
                raise (NotOdd(x))
        with
            | NotOdd (y) -> printfn "Instead of odd number, received: %d" y
            | HigherThan10 (y) -> printfn "Istead of number less than 10, received: %d" y
    finally
        printf "Okay, there was an error, but we can continue"
        

[<EntryPoint>]
let main argv =
    let myClassNew = MyClass1(5)
    let myClassNew = MyClass1()
    0 // return an integer exit code
