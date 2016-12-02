package com.htl22;

class Ball {
    private static final double GRAVITY = 9.81;
    private static final double START_HEIGHT = 1.5;
    private static final double TIME_STEP_IN_S = 10.0/1000.0;

    private double currentMs;
    private double travelledDistance;

    Ball() {
        this.currentMs = TIME_STEP_IN_S;
    }

    void drop() {
        while (!isOnGround()) {
            this.doStep();
        }
    }

    private void doStep() {
        travelledDistance = (GRAVITY * Math.pow(currentMs, 2)) /2;
        currentMs += TIME_STEP_IN_S;
        System.out.println(this.toString());
    }

    private boolean isOnGround() {
        return travelledDistance >= START_HEIGHT;
    }

    @Override
    public String toString() {
        return String.format("Steps: %d, Time: %fms, Meter: %f\n", (int)(currentMs/TIME_STEP_IN_S), currentMs*1000, this.travelledDistance);
    }
}
