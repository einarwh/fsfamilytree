datatype suit = Hearts | Diamonds | Spades | Clubs;;
datatype rank = Ace | King | Queen | Jack | NumericCard of int;;
datatype card = Card of rank * suit;;

val c1 = Card (Ace, Spades);;
val c2 = Card (NumericCard 7, Hearts);;

fun rank_of c = case c of Card (r, s) => r;;

fun value_of c =
  case rank_of c of
    Ace => 14
  | King => 13
  | Queen => 12
  | Jack => 11
  | NumericCard n => n;;

fun count (r : rank) (hand : card list) =
  case hand of 
    [] => 0
  | (Card (r', _))::cs' =>
    if r = r' then 1 + count r cs' else count r cs';;

val count_queens = count Queen;;