package com.htl22.jballsimulation;

/**
 * Author(s): Michael Koeppl
 */
class Ball {

    private Position currentPosition;
    private int speed, direction;

    Ball(int startX, int startY, int speed, int direction) {
        this.currentPosition = new  Position(startX, startY);
        this.speed = speed;
        this.direction = direction;
    }

    /*
     * Returns true, if the ball hit the wall, false otherwise.
     */
    boolean move(int ballId) {
        this.currentPosition.setX(this.currentPosition.getX() + speed);
        this.currentPosition.setY(this.currentPosition.getY() + direction);
        System.out.println(String.format("Ball %d:\n\tx: %d\n\ty: %d", ballId, this.currentPosition.getX(), this.currentPosition.getY()));
        return this.currentPosition.getX() >= 100 || this.currentPosition.getX() <= 0 ||
                this.currentPosition.getY() >= 100 || this.currentPosition.getY() <= 0;
    }
}
