package com.htl22.gameoflife;

/**
 * Author(s): Michael Koeppl
 */
public class Field {
    private static int WIDTH = 20;
    private static int HEIGHT = 20;

    private static Field ourInstance = new Field();

    static Field getInstance() {
        return ourInstance;
    }

    private Field() {}

    // The playing field.
    private boolean[][] field = new boolean[WIDTH][HEIGHT];

    public boolean[][] getField() {
        return field;
    }

    // Fills 200 randomly selected cells.
    void fillRandom() {
        int cellCount = 0;
        for (int i = 0; i < WIDTH; i++) {
            for (int j = 0; j < HEIGHT; j++) {
                if (cellCount < 200) {
                    field[i][j] = Math.random() < 0.5;
                    if (field[i][j]) {
                        cellCount++;
                    }
                }
            }
        }
    }

    void simulate() {
        do {
            try {
                for (int i = 0; i < WIDTH; i++) {
                    for (int j = 0; j < HEIGHT; j++) {
                        int neighborCount = getNeighborCount(i, j);
                        if (field[i][j]) { // alive cell
                            if (neighborCount <= 1 || neighborCount >= 4) { // dies due to being lonely :(
                                killCell(i, j);
                            }
                        } else { // dead cell
                            if (neighborCount >= 3) {
                                reviveCell(i, j);
                            }
                        }
                    }
                }
                System.out.println(String.format("\n%s", toString()));
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        } while (true);
    }

    private int getNeighborCount(int cellIndexI, int cellIndexJ) {
        int neighborCount = 0;
        for (int i = cellIndexI-1; i <= cellIndexI+1; i++) {
            for (int j = cellIndexJ-1; j <= cellIndexJ+1; j++) {
                if ((i >= 0 && i < WIDTH) && (j >= 0 && j < HEIGHT)) { // if within field
                    if (field[i][j] && !(i == cellIndexI && j == cellIndexJ)) { // if current cell is active not the core cell
                        neighborCount++;
                    }
                }
            }
        }
        return neighborCount;
    }

    private void killCell(int i, int j) {
        field[i][j] = false;
    }

    private void reviveCell(int i, int j) {
        field[i][j] = true;
    }

    // Returns a string visualising the field.
    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();
        builder.append(getLine());
        for (int i = 0; i < WIDTH; i++) {
            for (int j = 0; j < HEIGHT; j++) {
                builder.append(String.format("| %s ", field[i][j] ? "•" : " "));
            }
            builder.append("|");
            builder.append(getLine());
        }
        return builder.toString();
    }

    // Returns a line string.
    private String getLine() {
        StringBuilder builder = new StringBuilder();
        builder.append("\n");
        for (int k = 0; k < WIDTH; k++) {
            builder.append(" -- ");
        }
        builder.append("\n");
        return builder.toString();
    }
}
