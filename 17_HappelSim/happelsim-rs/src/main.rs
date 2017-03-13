// Author(s): Michael Koeppl

const VISITORS_COUNT_START: i16 = 25000; // Number of visitors in Happel stadium
const LEAVE_COUNT: i16 = VISITORS_COUNT_START / 60;
const LEAVE_COUNT_TUBE: i16 = 294+546;

fn main() {
    let mut visitors_left = VISITORS_COUNT_START;
    let mut queue_count: i16 = 0;
    let mut minutes_passed: i16 = 0;

    loop {
        // Every minute (every iteration) 25000/60 people leave the stadium
        // and head for the subway. Only if there are still people left in the
        // stadium, people from the stadium are added to the queue.
        visitors_left -= LEAVE_COUNT;
        if visitors_left > 0 {
            queue_count += LEAVE_COUNT;
        }

        // Every 3 minutes a train arrives and 294+546 people leave.
        // We ignore the first minute because otherwise the loop ends
        // after the first iteration.
        if minutes_passed != 0 && minutes_passed % 3 == 0 {
            queue_count -= LEAVE_COUNT_TUBE;
        }

        if queue_count <= 0 {
            break;
        }

        // Every 5 minutes, we print the current queue and
        // its length in meters.
        // First minute ignored again.
        if minutes_passed != 0 && minutes_passed % 5 == 0 {
            println!("{} people are currently in the queue", queue_count);
            println!("The queue is currently {}m long", queue_count / 4); // queue_count/4 = (queue_count/2)*0.5
        }
        minutes_passed = minutes_passed + 1;
    }

    println!("The last person left after {} minutes", minutes_passed);
}
