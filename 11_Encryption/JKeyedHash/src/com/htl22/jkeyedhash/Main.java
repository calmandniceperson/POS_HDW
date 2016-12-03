package com.htl22.jkeyedhash;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        // Initialize scanner to read input.
        Scanner scan = new Scanner(System.in);

        // Get input text.
	    System.out.print("Enter your text: ");
	    String inputString = scan.nextLine();

	    // Get key.
	    System.out.print("Enter a key: ");
	    String keyString = scan.nextLine();

	    // Hashes the string with HmacSHA1/HmacSHA256/HmacMD5 with the provided key and prints both versions.
	    Hasher.hashAll(inputString, keyString);
    }
}
