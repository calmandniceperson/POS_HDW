package com.htl22.gameoflife;

public class Main {

    public static void main(String[] args) {
        Field.getInstance().fillRandom();
        Field.getInstance().simulate();
    }
}
