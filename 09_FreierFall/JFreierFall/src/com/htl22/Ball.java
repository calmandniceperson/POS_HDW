package com.htl22;

class Ball {

    // h = (g*t^2)/2

    private static final double GRAVITY = 9.81;
    private static final double START_HEIGHT = 1.5;
    static final double TIMESTEP_IN_S = 10.0/1000.0; // 10 ms per step in seconds (0.01)
    private double currentHeight;

    void drop() {
        this.currentHeight = START_HEIGHT;
    }

    void doStep() {
        currentHeight -= (GRAVITY * Math.pow(TIMESTEP_IN_S, 2))/2;
        System.out.println(currentHeight);
    }

    boolean isOnGround() {
        return currentHeight <= 0;
    }
}
