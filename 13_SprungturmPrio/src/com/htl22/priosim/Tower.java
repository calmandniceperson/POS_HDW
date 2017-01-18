package com.htl22.priosim;

import java.util.ArrayList;
import java.util.List;

/**
 * Author(s): Michael Koeppl
 */
class Tower {

    private static Tower instance;

    private Tower() {}

    static Tower getInstance() {
        if (instance == null) { instance = new Tower(); }
        return instance;
    }

    private List<Child> towerQueue = new ArrayList<>();
    private List<Child> delayQueue = new ArrayList<>();

    private int secondsSinceStart;

    List<Child> getTowerQueue() {
        return towerQueue;
    }

    List<Child> getDelayQueue() {
        return delayQueue;
    }

    int getSecondsSinceStart() {
        return secondsSinceStart;
    }

    void addStepDuration() {
        secondsSinceStart += Main.DURATION_SIM_STEP;
    }

    void simulateQueueJumping() {
        for (int i = 1; i < towerQueue.size() - 1; i++) {
            if (towerQueue.get(i+1).getAge() < towerQueue.get(i).getAge()) {
                swapChildren(i+1, i);
            }
        }
    }

    private void swapChildren(int i, int j) {
        Child c1 = towerQueue.get(i);
        Child c2 = towerQueue.get(j);
        Child temp = c1;
        c1 = c2;
        c2 = temp;
    }
}
