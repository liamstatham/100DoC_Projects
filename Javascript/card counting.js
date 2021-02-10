var count = 0;

function cc(card) {
  // Only change code below this line
  var result;
  switch(card) {
    case 2:
    case 3:
    case 4:
    case 5:
    case 6:
      count = count + 1;
      break;
    case 7:
    case 8:
    case 9:
      break;
    case 10:
    case 'J':
    case 'Q':
    case 'K':
    case 'A':
      count = count - 1;
      break;
  }
  if (count <= 0) {
    result = count + " Hold";
  }
  else if (count >= 1) {
    result =  count + " Bet";
  }

  return result;
  // Only change code above this line
}

cc(2); cc(3); cc(7); cc('K'); cc('A');
