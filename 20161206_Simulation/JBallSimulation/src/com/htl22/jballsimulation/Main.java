package com.htl22.jballsimulation;

import java.util.Random;

/**
 * Author(s): Michael Koeppl
 */
public class Main {

    public static void main(String[] args) {
        Random rnd = new Random(System.currentTimeMillis());

        Ball b;

        int min = 40, max = 60;

        for (int i = 0; i < 5; i++) {
            b = new Ball(rnd.nextInt((max - min) + 1) + min, rnd.nextInt((max - min) + 1) + min,
                    rnd.nextInt((11-(-11)) + 1) + (-11), rnd.nextInt((11-(-11)) + 1) + (-11));
            FieldManager.getInstance().addBall(b);
        }

        FieldManager.getInstance().startSimulation();
    }
}
