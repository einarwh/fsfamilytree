// Statisk typing
let ten = 5 + 5;;

ten = 11;; // Ok, men false.

ten = "Foo";; // Typefeil

// Kan angi type eksplisitt hvis man ønsker.
let six : int = 3 + 3;;

// Funksjoner

let add x y = x + y;;

add 5 7;;

// Kan angi typer eksplisitt her også:
let mult (x: int) (y: int) : int = x * y;;

// Partial application
// Gi inn færre parametre enn funksjonen trenger

let add3 = add 3;;

add3 77;;

// Bare uttrykk (expressions), ingen ytringer (statements)

let varsel by = if by = "Bergen" then "Regn" else "Sol";;

varsel "Bergen";;

varsel "Oslo";;

varsel "Trondheim";;

// Lister og cons

[];; // Parametrisk polymorfi - lister kan ha hvilken som helst type.

[1; 2; 3];; // Liste av heltall

["Fie"; "Foe"; "Fum"];; // Liste av strenger

["Fie"; 4];; // Typefeil, kan ikke blande typer.

let byer = [ "Oslo"; "Bergen"; "Trondheim"; "Stavanger" ];;

// Cons-operatoren :: brukes til å bygge lister.
let land = "Norge" :: "Sverige" :: "Danmark" :: [];;

let flereByer = "Tokyo" :: byer;;

// Head & Tail av en liste

List.head byer;;
List.tail byer;;
List.head (List.tail (List.tail byer));;

// Pipe forward
// data |> funksjon = funksjon data

byer |> List.tail |> List.tail |> List.head;;

// Høyere-ordens funksjoner

List.filter (fun by -> varsel by = "Sol") byer;;
List.filter (fun by -> varsel by = "Regn") byer;;

List.map (fun by -> varsel by) byer;;
List.map (fun by -> by + ": " + varsel by) byer;;

// Algebraiske datatyper.

let par = ("Bergen", "Regn");; // Tupler

fst par;;
snd par;;

let ting = (1, ["Hello"; "World"], par);; // Tupler kan blande typer

// Sum-typer: Valg mellom ulike alternativer
type suit = Clubs | Diamonds | Hearts | Spades;;
type rank = Ace | King | Queen | Jack | Numeric of int;;
// Produkt-typer: Kombinasjon av ting.
type card = suit * rank;;

let c1 = (Ace, Spades);;
let c2 = (Numeric 7, Hearts);;
let hand1 = [(Ace, Spades); (Queen, Hearts); (Queen, Clubs); (Numeric 8, Diamonds)];;
let hand2 = [(Numeric 5, Clubs); (King, Diamonds); (Ace, Diamonds); (Queen, Spades)];;

// Pattern matching
let rank_of (c : card) = match c with (r, s) => r;;

// Pattern matching med variabel-binding.
let value_of (c : card) =
  match rank_of c with
  | Ace => 14
  | King => 13
  | Queen => 12
  | Jack => ||
  | Numeric n => n;;
 
// Rekursjon og pattern matching.
let rec count (r: rank) (h: card list) =
  match h with
    [] -> 0
  | (r', _)::h' -> if r = r' then 1 + count r h' else count r h';;
 
// Partial applikasjon igjen.
let count_queens = count Queen;;

count_queens hand1;;

count Ace hand1;;

