// Author(s): Michael Koeppl

package com.htl22.priosim;

public class Main {

    // Duration of phase 1 in minutes
    // The first 10 children jump one after another.
    private static final int DURATION_PHASE1 = 5;

    // Duration of phase 2 in minutes
    // 1 child is added to the queue every minute.
    private static final int DURATION_PHASE2 = 10;

    // Duration of phase 3 in minutes
    // 2 children leave every minute.
    private static final int DURATION_PHASE3 = 5;

    private static final int OVERALL_DURATION = DURATION_PHASE1 + DURATION_PHASE2 + DURATION_PHASE3;

    // Duration of a simulation step in seconds.
    static final int DURATION_SIM_STEP = 10;

    public static void main(String[] args) {

        // Fill tower queue with 10 children.
        for (int i = 0; i < 10; i++) {
            Tower.getInstance().getTowerQueue().add(new Child());
        }

        while ((Tower.getInstance().getSecondsSinceStart() / 60) < OVERALL_DURATION) {

            if (Tower.getInstance().getTowerQueue().size() > 0) {
                // Sort all children waiting to jump after the first child in line by age.
                Tower.getInstance().simulateQueueJumping();

                // Make the first child jump. The jump() method makes the instance of Child
                // remove itself from the tower queue, add itself to the delay queue and set
                // its timeLeft value to the time it takes them to jump (between 0 and 180 seconds).
                Tower.getInstance().getTowerQueue().get(0).jump();

                int timeSinceStart = Tower.getInstance().getSecondsSinceStart();
                // If within phase 2
                if ((timeSinceStart / 60) >= DURATION_PHASE1 && (timeSinceStart / 60) < (DURATION_PHASE1 + DURATION_PHASE2)) {
                    // If full minute
                    if ((timeSinceStart % 60) == 0) {
                        Tower.getInstance().getTowerQueue().add(new Child());
                    }
                } else if ((timeSinceStart / 60) >= DURATION_PHASE1 + DURATION_PHASE2) {
                    if ((timeSinceStart % 60) == 0) {
                        for (int j = 0; j < 2; j++) {
                            if (Tower.getInstance().getTowerQueue().size() > 0) {
                                Tower.getInstance().getTowerQueue().remove(Tower.getInstance().getTowerQueue().size() - 1);
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < Tower.getInstance().getDelayQueue().size(); j++) {
                Child checkedChild = Tower.getInstance().getDelayQueue().get(j);
                checkedChild.reduceTimeLeftByStepDuration();
                if (checkedChild.getTimeLeft() <= 0) {
                    // Puts the child back in the tower queue and sets the time
                    // it takes for a jump again.
                    checkedChild.getBackInLine();
                }
            }

            printQueues();

            Tower.getInstance().addStepDuration();
        }
    }

    private static void printQueues() {
        System.out.println("Tower queue");
        for (int i = 0; i < Tower.getInstance().getTowerQueue().size(); i++) {
            System.out.println(String.format("Child %d: %s", i, Tower.getInstance().getTowerQueue().get(i).toString()));
        }

        System.out.println("Delay queue");
        for (int i = 0; i < Tower.getInstance().getDelayQueue().size(); i++) {
            System.out.println(String.format("Child %d: %s", i, Tower.getInstance().getDelayQueue().get(i).toString()));
        }
    }
}
