package com.htl22;

public class Main {

    public static void main(String[] args) {
        Ball b = new Ball();

        b.drop();
        int i = 0;
        while (!b.isOnGround()) {
            b.doStep();
            i++;
        }
        System.out.println(String.format("Steps: %d; Time: %fms",  i, i*Ball.TIMESTEP_IN_S));
    }
}
