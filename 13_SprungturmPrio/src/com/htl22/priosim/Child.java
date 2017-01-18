package com.htl22.priosim;

import java.util.concurrent.ThreadLocalRandom;

/**
 * Author(s): Michael Koeppl
 */
class Child {

    private static final int AGE_MAX = 12;
    private static final int AGE_MIN = 4;

    private static final int DURATION_MAX = 180;
    private static final int DURATION_MIN = 0;

    private int age;
    private int jumpDurationInSeconds;
    private int timeLeft;

    Child() {
        this.age = ThreadLocalRandom.current().nextInt(AGE_MIN, AGE_MAX + 1);
        this.jumpDurationInSeconds = ThreadLocalRandom.current().nextInt(DURATION_MIN, DURATION_MAX + 1);
    }

    int getAge() {
        return age;
    }

    int getTimeLeft() {
        return timeLeft;
    }

    void reduceTimeLeftByStepDuration() {
        timeLeft -= Main.DURATION_SIM_STEP;
    }

    void jump() {
        timeLeft = jumpDurationInSeconds;
        Tower.getInstance().getTowerQueue().remove(this);
        Tower.getInstance().getDelayQueue().add(this);
    }

    void getBackInLine() {
        Tower.getInstance().getDelayQueue().remove(this);
        Tower.getInstance().getTowerQueue().add(this);
        jumpDurationInSeconds = ThreadLocalRandom.current().nextInt(DURATION_MIN, DURATION_MAX + 1);
    }

    @Override
    public String toString() {
        return String.format("Age: %s\tJump duration: %s\tTime left in delay queue: %s\n",
                age, jumpDurationInSeconds, timeLeft);
    }
}
