// Author(s): Michael Koeppl

const LEAVE_COUNT: i16 = 294+546;
const VISITORS_COUNT_START: i16 = 25000; // Number of visitors in Happel stadium

fn main() {
    let mut visitors= VISITORS_COUNT_START;

    let mut minutes_passed: i16 = 0;
    while visitors > 0 { // Loop until every visitor left
        if minutes_passed % 3 == 0 { // every three minutes...
            visitors -= LEAVE_COUNT;
            println!("{} visitors just left", LEAVE_COUNT);
        }
        if minutes_passed % 5 == 0 { // every 5 minutes...
            println!("Length of queue (number of people): {}", visitors);
            println!("Length of queue (in meters): {}", visitors/4); // x/4 = (x/2)*0.5
        }
        minutes_passed = minutes_passed + 1;
    }
    println!("Last person left {} minutes after the end of the event.", minutes_passed);
}
