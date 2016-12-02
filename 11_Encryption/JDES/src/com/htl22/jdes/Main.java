package com.htl22.jdes;

import java.io.IOException;

/*
 * Author(s): Michael Koeppl
 */

public class Main {

    private static final String USAGE_STRING = "Usage: [-e (--encrypt), -d (--decrypt)] <file> <key (min. length: 8)>";

    public static void main(String[] args) {

        // Check if all list of parameters is long enough to contain all required parameters.
        if (args.length < 3) {
            System.out.println(USAGE_STRING);
            return;
        }

        // Get out the command part, the file path and the key given by the user.
        String command = args[0];
        String filePath = args[1];
        String key = args[2];

        try {
            if (command.equals("-e") || command.equals("--encrypt")) { // Encryption selected
                DES.encrypt(key, filePath);
            } else if (command.equals("-d") || command.equals("--decrypt")) { // Decryption selected
                DES.decrypt(key, filePath);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
