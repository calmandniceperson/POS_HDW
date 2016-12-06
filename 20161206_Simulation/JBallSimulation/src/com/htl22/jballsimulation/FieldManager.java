package com.htl22.jballsimulation;

import java.util.ArrayList;
import java.util.List;

/**
 * Author(s): Michael Koeppl
 */
class FieldManager {
    private static FieldManager ourInstance = new FieldManager();

    static FieldManager getInstance() {
        return ourInstance;
    }

    private FieldManager() {
    }

    private List<Ball> ballList = new ArrayList<>();

    void addBall(Ball b) {
        this.ballList.add(b);
    }

    void startSimulation() {
        final boolean[] hitWall = {false};
        while (!hitWall[0]) {
            ballList.forEach((b) -> {
                if (!hitWall[0]) {
                    // move() returns true if the ball hit the wall.
                    if (b.move(this.ballList.indexOf(b))) {
                        System.out.println(String.format("Ball %s hit the wall!", this.ballList.indexOf(b)));
                        hitWall[0] = true;
                    }
                }
            });
        }
    }
}
